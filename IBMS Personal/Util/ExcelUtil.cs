using IBMS_Personal.Entity;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.Util
{
	public static class ExcelUtil
	{

		public class ChapterSheet
		{
			public string SheetName { get; set; }

			public ItemChapter Chapter { get; set; }
		}

		public abstract class ContentConverter
		{
			public ItemDetail Convert(IRow row, int extendFlag)
			{
				string question = GetCellStringValue(row, 2);
				if (question == null && extendFlag != ItemExtendFlag.CHILD)
				{
					throw new IBMSException("第[C]列 内容为空，要求：非扩展子题 必须有问题");
				}
				string answer = GetCellStringValue(row, 3);
				if (answer == null && extendFlag != ItemExtendFlag.PARENT)
				{
					throw new IBMSException("第[D]列 内容为空，要求：非扩展父题 必须有参考答案");
				}
				if (answer != null && extendFlag == ItemExtendFlag.PARENT)
				{
					throw new IBMSException("第[D]列 内容不为空，要求：扩展父题 不能有参考答案");
				}
				ItemDetail detail = FillOptions(row, extendFlag);
				detail.Question = question;
				detail.Answer = answer;
				return detail;
			}

			public abstract ItemDetail FillOptions(IRow row, int extendFlag);
		}

		public class UnChoiceQuestionConverter : ContentConverter
		{
			public override ItemDetail FillOptions(IRow row, int extendFlag)
			{
				return new ItemDetail();
			}
		}

		public class ChoiceQuestionConverter : ContentConverter
		{
			public override ItemDetail FillOptions(IRow row, int extendFlag)
			{
				List<string> options = new List<string>();
				for (int i = 4; i < 10; i++)
				{
					string option = GetCellStringValue(row, i);
					if (option == null)
					{
						break;
					}
					options.Add(option);
				}
				if (options.Count == 0 && extendFlag != ItemExtendFlag.PARENT)
				{
					throw new IBMSException("第[E]列开始 内容为空，要求：选择题 非扩展父题 必须有选项");
				}
				if (options.Count > 0 && extendFlag == ItemExtendFlag.PARENT)
				{
					throw new IBMSException("第[E]列开始 内容不为空，要求：选择题 扩展父题 不能有选项");
				}
				return new ItemDetail() { Options = options, Number = options.Count };
			}
		}

		private static Dictionary<int, ContentConverter> converters = InitConverters();

		private static Dictionary<int, ContentConverter> InitConverters()
		{
			ChoiceQuestionConverter choiceConverter = new ChoiceQuestionConverter();
			UnChoiceQuestionConverter unChoiceConverter = new UnChoiceQuestionConverter();
			return new Dictionary<int, ContentConverter>()
			{
				{ItemTypeFamily.TF, unChoiceConverter },
				{ItemTypeFamily.SC, choiceConverter },
				{ItemTypeFamily.MC, choiceConverter },
				{ItemTypeFamily.EQ, unChoiceConverter },
			};
		}


		/// <summary>
		/// 从文件路径获取 workbook 对象
		/// </summary>
		/// <param name="excelPath"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static IWorkbook OpenWorkBook(string excelPath)
		{
			FileStream excelStream = new FileStream(excelPath, FileMode.Open, FileAccess.Read);
			IWorkbook workbook;
			if (".xls".Equals(Path.GetExtension(excelPath).ToLower()))
			{
				workbook = new HSSFWorkbook(excelStream);
			}
			else if (".xlsx".Equals(Path.GetExtension(excelPath).ToLower()))
			{
				workbook = new XSSFWorkbook(excelStream);
			}
			else
			{
				throw new Exception("文件格式异常！");
			}
			return workbook;
		}

		/// <summary>
		/// 从 workbook 工作表 menu 获取 题型+章节数据
		/// </summary>
		/// <param name="workbook"></param>
		/// <returns></returns>
		/// <exception cref="IBMSException"></exception>
		public static Dictionary<ItemType, List<ChapterSheet>> GetSubjectStructureFromWorkBook(IWorkbook workbook)
		{
			Dictionary<ItemType, List<ChapterSheet>> result = new Dictionary<ItemType, List<ChapterSheet>>();
			ISheet sheet = workbook.GetSheet(MAIN_SHEET_NAME) ?? throw new IBMSException("找不到目录表[" + MAIN_SHEET_NAME + "]");
			// 循环获取题型数据
			for (int i = 0; ; i++)
			{
				IRow row1 = sheet.GetRow(i * 3);
				IRow row2 = sheet.GetRow(i * 3 + 1);
				IRow row3 = sheet.GetRow(i * 3 + 2);

				string typeName = GetCellStringValue(row1, 0);
				if (typeName == null) break;

				try
				{
					int family = int.Parse(GetCellStringValue(row2, 0, false));
					int flag = int.Parse(GetCellStringValue(row3, 0, false));
					if (result.Keys.Any(itemType => itemType.Name.Equals(typeName)))
					{
						throw new IBMSException("题型名称重复");
					}
					if (!ItemTypeFamily.values.Contains(family) || !ItemTypeFlag.values.Contains(flag)
						|| (flag == ItemTypeFlag.SUBJECTIVE && family != ItemTypeFamily.EQ))
					{
						throw new IBMSException("属性设置错误");
					}
					ItemType type = new ItemType() { Name = typeName, Family = family, Flag = flag };
					result.Add(type, new List<ChapterSheet>());

					// 循环获取章节数据
					for (int j = 1; ; j++)
					{
						string chapterName = GetCellStringValue(row2, j);
						if (chapterName == null) break;
						try
						{
							string sheetName = GetCellStringValue(row3, j, false);
							if (result[type].Any(itemSheet => itemSheet.Chapter.Name.Equals(chapterName)))
							{
								throw new IBMSException("章节名称重复");
							}
							if (workbook.GetSheet(sheetName) == null)
							{
								throw new IBMSException("章节表[" + sheetName + "] 不存在");
							}
							if (result.Values.Any(itemSheets => itemSheets.Any(itemSheet => itemSheet.SheetName.Equals(sheetName))))
							{
								throw new IBMSException("章节表[" + sheetName + "] 名称重复");
							}
							result[type].Add(new ChapterSheet() { SheetName = sheetName, Chapter = new ItemChapter() { Name = chapterName } });
						}
						catch (Exception ex)
						{
							throw new IBMSException("章节[" + chapterName + "] 设置异常：\n" + ex.Message, ex);
						}
					}
				}
				catch (Exception ex)
				{
					throw new IBMSException("题型[" + typeName + "] 设置异常：\n" + ex.Message, ex);
				}
			}
			return result;
		}

		public static List<ItemContent> GetItemContentsFromWorkBook(IWorkbook workBook, Dictionary<ItemType, List<ChapterSheet>> structure)
		{
			List<ItemContent> result = new List<ItemContent>();
			foreach (KeyValuePair<ItemType, List<ChapterSheet>> pair in structure)
			{
				foreach (ChapterSheet chapterSheet in pair.Value)
				{
					try
					{
						List<ItemContent> contents = GetItemContentsFromChapterSheet(workBook, pair.Key, chapterSheet);
						result.AddRange(contents);
					}
					catch(Exception ex)
					{
						throw new IBMSException("题型[" + pair.Key.Name + "] 章节[" + chapterSheet.Chapter.Name + "] 章节表[" + chapterSheet.SheetName + "] 试题读取异常：\n" + ex.Message, ex);
					}
				}
			}
			return result;
		}

		private static List<ItemContent> GetItemContentsFromChapterSheet(IWorkbook workBook, ItemType type, ChapterSheet chapterSheet)
		{
			ISheet sheet = workBook.GetSheet(chapterSheet.SheetName) ?? throw new IBMSException("章节表不存在");
			List<ItemContent> result = new List<ItemContent>();
			ItemContent parent = null;
			for (int i = 1; ; i++)
			{
				IRow row = sheet.GetRow(i);
				if (GetCellStringValue(row, 0) == null) break;
				try
				{
					bool success = int.TryParse(GetCellStringValue(row, 1, false), out int extendFlag);
					if (!success || extendFlag < 0)
					{
						throw new IBMSException("第[" + GetColumnName(1) + "]列 内容不符合规范，要求：非负整数");
					}
					Item item = new Item()
					{
						Id = i,
						TypeId = type.Id,
						ChapterId = chapterSheet.Chapter.Id,
						Flag = extendFlag > 1 ? ItemExtendFlag.PARENT : extendFlag,
						Number = extendFlag > 1 ? extendFlag : 0
					};
					ItemDetail detail = converters[type.Family].Convert(row, item.Flag);
					ItemContent content = new ItemContent(item, detail);
					if (item.Flag == ItemExtendFlag.CHILD)
					{
						if (parent == null)
						{
							throw new IBMSException("扩展子题没有对应父题");
						}
						parent.AddChild(content);
						if (parent.Item.Number == parent.Children.Count)
						{
							parent = null;
						}
					}
					else
					{
						if (parent != null)
						{
							long lastId = parent.Item.Id;
							throw new IBMSException("第[" + (lastId + 1) + "]行 扩展父题的子题数量不足");
						}
						result.Add(content);
						if (item.Flag == ItemExtendFlag.PARENT)
						{
							parent = content;
						}
					}
				}
				catch (Exception ex)
				{
					throw new IBMSException("第[" + (i + 1) + "]行 试题数据读取异常：\n" + ex.Message, ex);
				}
			}
			return result;
		}

		/// <summary>
		/// 读取指定单元格的内容，并以字符串形式返回。
		/// row 或 cell 不存在，或 CellType 为 Blank 时 返回 null；
		/// CellType 为 String / Numeric 时 返回其字符串形式(字符串为 null / empty / 空白字符组成，也返回 null)；
		/// CellType 为其他类型时 产生异常。
		/// </summary>
		/// <param name="row"></param>
		/// <param name="cellnum"></param>
		/// <returns>
		/// row 或 cell 不存在，或 CellType 为 Blank 时 返回 null；CellType 为 String / Numeric 时 返回其字符串形式
		/// </returns>
		/// <exception cref="IBMSException">当 CellType 为其他类型时 产生异常</exception>
		public static string GetCellStringValue(IRow row, int cellnum)
		{
			if (row == null) return null;
			ICell cell = row.GetCell(cellnum);
			if (cell == null || cell.CellType == CellType.Blank) return null;
			string value;
			switch (cell.CellType)
			{
				case CellType.String:
					value = cell.StringCellValue;
					break;
				case CellType.Numeric:
					value = cell.NumericCellValue.ToString();
					break;
				default:
					throw new IBMSException("第[" + (row.RowNum + 1) + "]行 第[" + GetColumnName(cellnum) + "]列 单元格读取异常");
			}
			return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
		}

		/// <summary>
		/// 调用 GetCellStringValue(IRow, int) 获取单元格字符串内容。特别地，如果 nullable 为 false，则字符串为 null 时报错
		/// </summary>
		/// <param name="row"></param>
		/// <param name="cellnum"></param>
		/// <param name="nullable"></param>
		/// <returns></returns>
		/// <exception cref="IBMSException"></exception>
		/// <see cref="GetCellStringValue(IRow, int)">GetCellStringValue(IRow, int)</see>
		public static string GetCellStringValue(IRow row, int cellnum, bool nullable)
		{
			string value = GetCellStringValue(row, cellnum);
			if (!nullable && value == null)
			{
				throw new IBMSException("第[" + (row.RowNum + 1) + "]行 第[" + GetColumnName(cellnum) + "]列 单元格为空");
			}
			return value;
		}

		public static string GetColumnName(int columnNum)
		{
			StringBuilder columnName = new StringBuilder();
			while (columnNum >=0)
			{
				columnName.Insert(0, (char)(columnNum % 26 + 'A'));
				columnNum = columnNum / 26 - 1;
			}
			return columnName.ToString();
		}

		internal static void SaveSubjectStructureToWorkBook(IWorkbook workBook, Dictionary<ItemType, List<ChapterSheet>> structure)
		{
			ISheet sheet = workBook.CreateSheet(MAIN_SHEET_NAME);
			// 循环题型数据
			for (int i = 0; i < structure.Count; i++)
			{
				IRow row1 = sheet.CreateRow(i * 3);
				IRow row2 = sheet.CreateRow(i * 3 + 1);
				IRow row3 = sheet.CreateRow(i * 3 + 2);

				ItemType type = structure.ElementAt(i).Key;
				row1.CreateCell(0).SetCellValue(type.Name);
				row2.CreateCell(0).SetCellValue(type.Family.ToString());
				row3.CreateCell(0).SetCellValue(type.Flag.ToString());

				List<ChapterSheet> chapterSheets = structure.ElementAt(i).Value;
				// 循环章节数据
				for (int j = 0; j < chapterSheets.Count; j++)
				{
					ChapterSheet chapterSheet = chapterSheets[j];
					row2.CreateCell(j + 1).SetCellValue(chapterSheet.Chapter.Name);
					row3.CreateCell(j + 1).SetCellValue(chapterSheet.SheetName);
				}
			}
		}

		internal static void SaveItemContentsToWorkBook(IWorkbook workBook, Dictionary<string, List<ItemContent>> contents)
		{
			foreach (string sheetName in contents.Keys)
			{
				ISheet sheet = workBook.CreateSheet(sheetName);

			}
		}

		internal static void SaveSubjectDataToWorkBook(IWorkbook workBook, Dictionary<ItemType, Dictionary<ChapterSheet, List<ItemContent>>> data)
		{
			ISheet mainSheet = workBook.CreateSheet(MAIN_SHEET_NAME);
			// 循环题型
			for (int i = 0; i < data.Count; i++)
			{
				IRow row1 = mainSheet.CreateRow(i * 3);
				IRow row2 = mainSheet.CreateRow(i * 3 + 1);
				IRow row3 = mainSheet.CreateRow(i * 3 + 2);

				ItemType type = data.ElementAt(i).Key;
				row1.CreateCell(0).SetCellValue(type.Name);
				row2.CreateCell(0).SetCellValue(type.Family.ToString());
				row3.CreateCell(0).SetCellValue(type.Flag.ToString());

				// 循环章节
				Dictionary<ChapterSheet, List<ItemContent>> typeData = data.ElementAt(i).Value;
				for (int j = 0; j < typeData.Count; j++)
				{
					ChapterSheet chapterSheet = typeData.ElementAt(j).Key;
					row2.CreateCell(j + 1).SetCellValue(chapterSheet.Chapter.Name);
					row3.CreateCell(j + 1).SetCellValue(chapterSheet.SheetName);

					// 保存章节试题
					ISheet sheet = workBook.CreateSheet(chapterSheet.SheetName);
					FillTitleRow(sheet.CreateRow(0));

					// 循环试题
					List<ItemContent> contents = typeData.ElementAt(j).Value;
					int rownum = 1;
					foreach (ItemContent content in contents)
					{
						if (content.Item.Flag == ItemExtendFlag.PARENT)
						{
							FillItemRow(sheet.CreateRow(rownum++), content.Detail, content.Item.Number);
							foreach (ItemContent child in content.Children)
							{
								FillItemRow(sheet.CreateRow(rownum++), child.Detail, child.Item.Flag);
							}
						}
						else
						{
							FillItemRow(sheet.CreateRow(rownum++), content.Detail, content.Item.Flag);
						}
					}
				}
			}
		}

		private static void FillTitleRow(IRow titleRow)
		{
			titleRow.CreateCell(0).SetCellValue("序号");
			titleRow.CreateCell(1).SetCellValue("扩展标记");
			titleRow.CreateCell(2).SetCellValue("问题");
			titleRow.CreateCell(3).SetCellValue("答案");
			titleRow.CreateCell(4).SetCellValue("选项1");
			titleRow.CreateCell(5).SetCellValue("选项2");
			titleRow.CreateCell(6).SetCellValue("选项3");
			titleRow.CreateCell(7).SetCellValue("选项4");
			titleRow.CreateCell(8).SetCellValue("选项5");
			titleRow.CreateCell(9).SetCellValue("选项6");
		}

		private static void FillItemRow(IRow itemRow, ItemDetail detail, int extendFlag)
		{
			itemRow.CreateCell(0).SetCellValue(itemRow.RowNum.ToString());
			itemRow.CreateCell(1).SetCellValue(extendFlag.ToString());
			itemRow.CreateCell(2).SetCellValue(detail.Question);
			itemRow.CreateCell(3).SetCellValue(detail.Answer);
			switch (detail.Number)
			{
				case 6:
					itemRow.CreateCell(9).SetCellValue(detail.Options[5]);
					goto case 5;
				case 5:
					itemRow.CreateCell(8).SetCellValue(detail.Options[4]);
					goto case 4;
				case 4:
					itemRow.CreateCell(7).SetCellValue(detail.Options[3]);
					goto case 3;
				case 3:
					itemRow.CreateCell(6).SetCellValue(detail.Options[2]);
					goto case 2;
				case 2:
					itemRow.CreateCell(5).SetCellValue(detail.Options[1]);
					goto case 1;
				case 1:
					itemRow.CreateCell(4).SetCellValue(detail.Options[0]);
					break;
				default:
					break;
			}
		}

		internal static IWorkbook CreateWorkBook(string excelPath)
		{
			IWorkbook workbook;
			if (".xls".Equals(Path.GetExtension(excelPath).ToLower()))
			{
				workbook = new HSSFWorkbook();
			}
			else if (".xlsx".Equals(Path.GetExtension(excelPath).ToLower()))
			{
				workbook = new XSSFWorkbook();
			}
			else
			{
				throw new Exception("文件格式异常！");
			}
			return workbook;
		}
	}
}
