using IBMS_Personal.DAO;
using IBMS_Personal.Entity;
using IBMS_Personal.Util;
using System.Collections.Generic;
using static IBMS_Personal.Entity.Exam;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.Service
{
	internal class ExamService
	{
		internal Exam GetExam(ExamSetting setting)
		{
			Exam exam = new Exam() { TotalCount = 0};
			int startIndex = 1;
			foreach (ExamSetting.ExamModuleSetting moduleSetting in setting.GetModules())
			{

				ExamModule module = new ExamModule();
				module.ItemType = moduleSetting.ItemType;
				module.Score = moduleSetting.Score;
				foreach (KeyValuePair<ItemChapter, int> pair in moduleSetting.Chapters)
				{
					module.AddItems(GetExamItems(pair.Key, pair.Value));
					exam.TotalCount += pair.Value;
				}
				module.Items = CollectionUtil.Shuffle(module.Items);
				foreach (ExamItem item in module.Items)
				{
					item.Index = startIndex;
					if(item.Item.Flag == ItemExtendFlag.PARENT)
					{
						foreach (ExamItem child in item.Children)
						{
							child.Index = startIndex;
							startIndex++;
						}
					}
					else
					{
						startIndex++;
					}
				}
				exam.AddModule(module);
			}
			return exam;
		}

		/// <summary>
		/// 根据章节、试题数量，获取考试试题内容
		/// 此处逻辑后续需要完善，如乱序后[2，1，3，1，2，3]，获取 5，就会失败
		/// </summary>
		/// <param name="chapter"></param>
		/// <param name="total"></param>
		/// <returns></returns>
		internal List<ExamItem> GetExamItems(ItemChapter chapter, int total)
		{
			List<ExamItem> result = new List<ExamItem>();
			int resultCount = 0;
			List<Item> items = Services.ItemService.GetItemsByChapterWithFlag(chapter, ItemExtendFlag.CHILD, false);
			items = CollectionUtil.Shuffle(items);
			for (int i = 0; i < items.Count; i++)
			{
				int newNumber = items[i].Flag == ItemExtendFlag.UNEXTEND ? 1 : items[i].Number;
				if(resultCount + newNumber > total)
				{
					continue;
				}
				ExamItem examItem = new ExamItem(items[i], DAOs.ItemDetailDao.SelectById(items[i].Id).ShuffleOptions());
				if (items[i].Flag == ItemExtendFlag.PARENT)
				{
					List<Item> childItems = DAOs.ItemDao.ListByParentId(items[i].Id);
					List<ItemDetail> childItemDetails = DAOs.ItemDetailDao.ListByParentId(items[i].Id);
					for (int childIndex = 0; childIndex < childItems.Count; childIndex++)
					{
						examItem.AddChild(new ExamItem(childItems[childIndex], childItemDetails[childIndex].ShuffleOptions()));
					}
				}
				result.Add(examItem);
				resultCount += newNumber;
				if (result.Count == total)
				{
					break;
				}
			}
			if (resultCount < total)
			{
				throw new IBMSException(string.Format("组装章节[{0}]试题失败，需要数量{1}，实际数量{2}！", chapter.Name, total, resultCount));
			}
			return result;
		}

		internal void AddExamLog(Exam exam, ExamSetting setting)
		{
			ExamLog log = new ExamLog
			{
				StartTime = exam.StartTime,
				Score = exam.TotalScore,
				Duration = exam.Duration,
				TotalScore = setting.TotalScore,
				TotalTime = setting.TotalTime,
				Structure = setting.Show()
			};
			int count = DAOs.ExamLogDao.InsertWithoutId(log);
			if (count != 1)
			{
				throw new IBMSException("插入数据失败，原因未知");
			};
		}

		internal int CountLogs()
		{
			return DAOs.ExamLogDao.Count();
		}

		internal List<ExamLog> GetExamLogsByPage(int pageIndex, int pageSize)
		{
			return DAOs.ExamLogDao.SelectByPage(pageIndex, pageSize);
		}
	}
}
