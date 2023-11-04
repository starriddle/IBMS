using IBMS_Personal.DAO;
using IBMS_Personal.Entity;
using IBMS_Personal.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.Service
{
	internal class ContentService
	{

		internal List<ItemContent> GetSimpleContentList(ItemChapter chapter, int order)
		{
			List<ItemContent> simpleList = GetSimpleContentList(chapter, ItemExtendFlag.CHILD, false);
			simpleList = SortContentListByOrder(simpleList, order);
			return simpleList;
		}

		internal List<ItemContent> GetSimpleContentListForPractice(PracticeSetting setting)
		{
			List<ItemContent> simpleList = GetSimpleContentList(setting.ItemChapter, ItemExtendFlag.CHILD, false);
			simpleList = SortContentListByOrder(CollectionUtil.Shuffle(simpleList), setting.PracticeOrder);
			return simpleList;
		}

		private List<ItemContent> GetSimpleContentList(ItemChapter chapter, int extendFlag, bool flag)
		{
			List<Item> items = Services.ItemService.GetItemsByChapterWithFlag(chapter, extendFlag, flag);
			List<ItemContent> simpleList = items.Select(item =>
			{
				ItemContent simpleContent = new ItemContent(item);
				if (item.Flag == ItemExtendFlag.PARENT)
				{
					List<Item> children = DAOs.ItemDao.ListByParentId(item.Id);
					foreach (Item child in children)
					{
						simpleContent.AddChild(new ItemContent(child));
					}
				}
				return simpleContent;
			}).ToList();
			return simpleList;
		}

		/// <summary>
		/// 按指定排序方式重新排序
		/// </summary>
		/// <param name="list">列表</param>
		/// <param name="order">顺序</param>
		/// <param name="idOrder">顺序一致的元素是否按编号排序</param>
		/// <returns></returns>
		private List<ItemContent> SortContentListByOrder(List<ItemContent> list, int order)
		{
			switch (order)
			{
				case ItemOrder.ORIGINAL:
					return list.OrderBy(itemContent => itemContent.Item.Id).ToList();
				case ItemOrder.TOTAL:
					return list.OrderBy(itemContent => itemContent.Item.Total).ToList();
				case ItemOrder.CORRECT:
					return list.OrderBy(itemContent => itemContent.Item.Correct).ToList();
				case ItemOrder.PRECISION:
					return list.OrderBy(itemContent =>
					{
						if (itemContent.Item.Correct == 0) return -itemContent.Item.Total;
						return 1.0 * itemContent.Item.Correct / itemContent.Item.Total;
					}).ToList();
				default:
					break;
			}
			return list;
		}

		internal List<ItemContent> GetDetailedContentList(List<ItemContent> simpleList)
		{
			return GetDetailedContentList(simpleList, false);
		}

		internal List<ItemContent> GetDetailedContentList(List<ItemContent> simpleList, bool shuffleOptions)
		{
			return simpleList.Select(simpleContent => GetDetailedContent(simpleContent, shuffleOptions)).ToList();
		}

		internal ItemContent GetDetailedContent(ItemContent simpleContent)
		{
			return GetDetailedContent(simpleContent, false);
		}

		internal ItemContent GetDetailedContent(ItemContent simpleContent, bool shuffleOptions)
		{
			ItemContent result = simpleContent.SimplyCopy();

			ItemDetail detail = DAOs.ItemDetailDao.SelectById(result.Item.Id);
			if (shuffleOptions) detail.ShuffleOptions();
			result.Detail = detail;

			if (result.Item.Flag == ItemExtendFlag.PARENT)
			{
				List<ItemDetail> details = DAOs.ItemDetailDao.ListByParentId(result.Item.Id);
				for (int i = 0; i < details.Count; i++)
				{
					if (shuffleOptions) details[i].ShuffleOptions();
					result.Children[i].Detail = details[i];
				}
			}
			return result;
		}

		internal bool UpdatePracticeLog(ItemContent content)
		{
			SQLiteTransaction transaction = SQLiteUtil.get().BeginTransaction();
			try
			{
				foreach (ItemContent child in content.Children)
				{
					DAOs.ItemDao.UpdatePracticeLog(child.Item);
				}
				DAOs.ItemDao.UpdatePracticeLog(content.Item);
				transaction.Commit();
				return true;
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw ex;
			}
		}

		internal bool DeleteContent(ItemContent content)
		{
			SQLiteTransaction transaction = SQLiteUtil.get().BeginTransaction();
			try
			{
				int count1, count2;
				foreach (ItemContent child in content.Children)
				{
					count1 = DAOs.ItemDao.DeleteById(child.Item.Id);
					count2 = DAOs.ItemDetailDao.DeleteById(child.Item.Id);
					if (count1 != 1 || count2 != 1)
					{
						string message = string.Format("删除试题失败：id={0}, parentId={1}", child.Item.Id, child.Item.ParentId);
						throw new Exception(message);
					}
				}
				count1 = DAOs.ItemDao.DeleteById(content.Item.Id);
				count2 = DAOs.ItemDetailDao.DeleteById(content.Item.Id);
				if (count1 != 1 || count2 != 1)
				{
					string message = string.Format("删除试题失败：id={0}", content.Item.Id);
					throw new Exception(message);
				}
				transaction.Commit();
				return true;
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw ex;
			}
		}

		internal ItemContent UpdateContent(ItemContent content)
		{
			SQLiteTransaction transaction = SQLiteUtil.get().BeginTransaction();
			try
			{
				DAOs.ItemDao.Update(content.Item);
				DAOs.ItemDetailDao.Update(content.Detail);
				DAOs.ItemDao.DeleteByParentId(content.Item.Id);
				DAOs.ItemDetailDao.DeleteByParentId(content.Item.Id);
				foreach (ItemContent child in content.Children)
				{
					child.Item = child.Item.Id == 0 ? DAOs.ItemDao.InsertWithoutId(child.Item) : DAOs.ItemDao.InsertWithId(child.Item);
					child.Detail.Id = child.Item.Id;
					child.Detail = DAOs.ItemDetailDao.Insert(child.Detail);
				}
				transaction.Commit();
				return content;
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw ex;
			}
		}

		internal ItemContent CreateContent(ItemContent content)
		{
			SQLiteTransaction transaction = SQLiteUtil.get().BeginTransaction();
			try
			{
				content.Item = DAOs.ItemDao.InsertWithoutId(content.Item);
				content.Detail.Id = content.Item.Id;
				content.Detail = DAOs.ItemDetailDao.Insert(content.Detail);
				foreach (ItemContent child in content.Children)
				{
					child.Item.ParentId = child.Detail.ParentId = content.Item.Id;
					child.Item = DAOs.ItemDao.InsertWithoutId(child.Item);
					child.Detail.Id = child.Item.Id;
					child.Detail = DAOs.ItemDetailDao.Insert(child.Detail);
				}
				transaction.Commit();
				return content;
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				throw ex;
			}
		}
	}
}
