using IBMS_Personal.DAO;
using IBMS_Personal.Entity;
using IBMS_Personal.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using static IBMS_Personal.Util.Constants;
using static IBMS_Personal.Util.ExcelUtil;

namespace IBMS_Personal.Service
{
	public class FileService
	{
		/// <summary>
		/// 从文件导入科目试题数据
		/// </summary>
		/// <param name="fileName"></param>
		/// <exception cref="NotImplementedException"></exception>
		internal void ImportFrom(string filePath)
		{
			// 1. 打开文件
			IWorkbook workBook;
			try
			{
				workBook = ExcelUtil.OpenWorkBook(filePath);
			}
			catch (Exception ex)
			{
				throw new IBMSException("文件打开异常：\n" + ex.Message, ex);
			}

			// 2. 获取 科目 题型-章节 结构信息
			Dictionary<ItemType, List<ChapterSheet>> structure;
			try
			{
				structure = ExcelUtil.GetSubjectStructureFromWorkBook(workBook);
			}
			catch (Exception ex)
			{
				throw new IBMSException("从文件获取科目结构出现异常：\n" + ex.Message, ex);
			}

			// 3. 开启事务，保存结构信息中新的题型和章节
			SQLiteTransaction tx1 = SQLiteUtil.get().BeginTransaction();
			try
			{
				SaveSubjectStructure(structure);
				tx1.Commit();
			}
			catch (Exception ex)
			{
				tx1.Rollback();
				throw new IBMSException("保存科目结构到数据库出现异常：\n" + ex.Message, ex);
			}

			// 4. 获取试题内容
			List<ItemContent> contents;
			try
			{
				contents = ExcelUtil.GetItemContentsFromWorkBook(workBook, structure);
			}
			catch (Exception ex)
			{
				throw new IBMSException("从文件获取试题信息出现异常：\n" + ex.Message, ex);
			}

			// 5. 开启事务，保存试题内容到数据库
			SQLiteTransaction tx2 = SQLiteUtil.get().BeginTransaction();
			try
			{
				SaveSubjectItemContents(contents);
				tx2.Commit();
			}
			catch (Exception ex)
			{
				tx2.Rollback();
				throw new IBMSException("保存试题信息到数据库出现异常：\n" + ex.Message, ex);
			}
		}

		private void SaveSubjectItemContents(List<ItemContent> contents)
		{
            foreach (ItemContent content in contents)
			{
				Item item = DAOs.ItemDao.Insert(content.Item);
				content.Detail.Id = item.Id;
				DAOs.ItemDetailDAO.Insert(content.Detail);
				foreach (ItemContent child in content.Children)
				{
					child.Detail.ParentId = child.Item.ParentId = item.Id;
					child.Detail.Id = DAOs.ItemDao.Insert(child.Item).Id;
					DAOs.ItemDetailDAO.Insert(child.Detail);
				}
			}
        }

		/// <summary>
		/// 根据从文件中获取的 题型-(表名-章节) 结构，将题型和章节信息保存到数据库，忽略已存在的题型、章节信息
		/// </summary>
		/// <param name="structure"></param>
		/// <exception cref="NotImplementedException"></exception>
		private void SaveSubjectStructure(Dictionary<ItemType, List<ChapterSheet>> structure)
		{
			List<ItemType> oldTypes = DAOs.ItemTypeDao.List();

			// 循环新题型
			foreach (var pair in structure)
			{
				ItemType newType = pair.Key;
				List<ItemChapter> oldChapters = new List<ItemChapter>();

				// 新题型检查
				bool typeExist = false;
				foreach (ItemType oldType in oldTypes)
				{
					// 新题型名称已存在
					if (oldType.Name.Equals(newType.Name))
					{
						// 题型设置不一致，报错
						if (oldType.Family != newType.Family || oldType.Flag != newType.Flag)
						{
							throw new IBMSException("题型[" + oldType.Name + "] 已存在，但设置不一致！");
						}
						// 题型设置一致，新题型已存在，使用已有数据
						oldChapters = DAOs.ItemChapterDao.ListByTypeId(oldType.Id);
						newType.Id = oldType.Id;
						typeExist = true;
						break;
					}
				}
				// 新题型不存在，则创建题型
				if (!typeExist)
				{
					newType.Id = DAOs.ItemTypeDao.Insert(newType).Id;
				}

				// 循环新章节
				foreach (ChapterSheet chapterSheet in pair.Value)
				{
					ItemChapter newChapter = chapterSheet.Chapter;
					newChapter.TypeId = newType.Id;

					// 新章节检查
					bool chapterExist = false;
					foreach (ItemChapter oldChapter in oldChapters)
					{
						// 新章节已存在，使用已有数据
						if (oldChapter.Name.Equals(newChapter.Name))
						{
							newChapter.Id = oldChapter.Id;
							chapterExist = true;
							break;
						}
					}
					// 新章节不存在，新建章节
					if (!chapterExist)
					{
						newChapter.Id = DAOs.ItemChapterDao.Insert(newChapter).Id;
					}
				}
			}
		}

		/// <summary>
		/// 导出科目试题数据到文件
		/// </summary>
		/// <param name="fileName"></param>
		/// <exception cref="NotImplementedException"></exception>
		internal void ExportTo(string filePath)
		{

			// 1. 查询数据库 获取 结构信息 和 试题内容
			Dictionary<ItemType, Dictionary<ChapterSheet, List<ItemContent>>> data;
			try
			{
				data = GetSubjectData();
			}
			catch (Exception ex)
			{
				throw new IBMSException("从数据库获取科目信息出现异常：\n" + ex.Message, ex);
			}
			if (data.Count == 0)
			{
				throw new IBMSException("当前科目无有效试题数据，不需要导出！");
			}

			// 2. 创建 Excel 文件
			IWorkbook workBook;
			try
			{
				workBook = ExcelUtil.CreateWorkBook(filePath);
			}
			catch(Exception ex)
			{
				throw new IBMSException("创建文件异常：\n" + ex.Message, ex);
			}

			// 3. 写入 科目 结构信息 和 试题数据 到文件

			try
			{
				ExcelUtil.SaveSubjectDataToWorkBook(workBook, data);
			}
			catch (Exception ex)
			{
				throw new IBMSException("保存科目信息到文件出现异常：\n" + ex.Message, ex);
			}

			// 4. 保存文件
			;
			try
			{
				workBook.Write(new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite));
			}
			catch (Exception ex)
			{
				throw new IBMSException("文件保存异常：\n" + ex.Message, ex);
			}
		}

		private Dictionary<ItemType, Dictionary<ChapterSheet, List<ItemContent>>> GetSubjectData()
		{
			Dictionary<ItemType, Dictionary<ChapterSheet, List<ItemContent>>> data =
					new Dictionary<ItemType, Dictionary<ChapterSheet, List<ItemContent>>>();

			List<ItemType> types = DAOs.ItemTypeDao.List();
            foreach (ItemType type in types)
			{
				Dictionary<ChapterSheet, List<ItemContent>> typeData = new Dictionary<ChapterSheet, List<ItemContent>>();
				List<ItemChapter> chapters = DAOs.ItemChapterDao.ListByTypeId(type.Id);
                foreach (ItemChapter chapter in chapters)
                {
					List<ItemContent> contents = new List<ItemContent>();
					List<Item> items = DAOs.ItemDao.ListByChapterIdAndFlag(chapter.Id, ItemExtendFlag.CHILD, false);
                    foreach (Item item in items)
                    {
						ItemDetail detail = DAOs.ItemDetailDAO.SelectById(item.Id);
						if (detail == null) continue;
						ItemContent content = new ItemContent(item, detail);
						if (item.Flag == ItemExtendFlag.PARENT)
						{
							if (item.Number < 2) continue;
							List<Item> childItems = DAOs.ItemDao.ListByParentId(item.Id);
                            foreach (Item childItem in childItems)
                            {
								ItemDetail childDetail = DAOs.ItemDetailDAO.SelectById(childItem.Id);
								if (childDetail == null) continue;
								content.AddChild(new ItemContent(childItem, childDetail));
                            }
							if (item.Number != content.Children.Count) continue;
                        }
						contents.Add(content);
                    }
					if (contents.Count == 0) continue;
					ChapterSheet chapterSheet = new ChapterSheet()
					{
						Chapter = chapter,
						SheetName = type.Id + "_" + chapter.Id
					};
					typeData.Add(chapterSheet, contents);
                }
				if (typeData.Count == 0) continue;
				data.Add(type, typeData);
            }
			return data;
        }
	}
}
