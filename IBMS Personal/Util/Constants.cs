using System;
using System.IO;

namespace IBMS_Personal.Util
{
	public class Constants
	{

		/// <summary>
		/// 默认父级ID 0
		/// </summary>
		public const long DEFAULT_PARENT_ID = 0;

		/// <summary>
		/// 科目备份表格文件 入口工作表名称
		/// </summary>
		public const string MAIN_SHEET_NAME = "menu";

		public class DB
		{
			/// <summary>
			/// 数据基本目录
			/// </summary>
			public static readonly string BASE_PATH = Path.Combine(Environment.CurrentDirectory, "data");

			/// <summary>
			/// 主数据库(科目索引)模板文件名称
			/// </summary>
			public const string MAIN_SAMPLE = "main.db";

			/// <summary>
			/// 科目数据库(科目内容)模板文件名称
			/// </summary>
			public const string SUBJECT_SAMPLE = "item.db";

			/// <summary>
			/// 主数据库(科目索引)文件名称
			/// </summary>
			public const string MAIN_NAME = "subject";

			/// <summary>
			/// 科目数据库(科目内容)别名
			/// </summary>
			//public const string SUBJECT_ALIAS = "subject";

			/// <summary>
			/// 试题 数据库别名
			/// </summary>
			//public const string ITEM_ALIAS = "item";

			/// <summary>
			/// 试题 数据库文件名称
			/// </summary>
			//public const string ITEM_NAME = "item";

			/// <summary>
			/// 记录 数据库别名
			/// </summary>
			//public const string HISTORY_ALIAS = "history";

			/// <summary>
			/// 记录 数据库文件名称
			/// </summary>
			//public const string HISTORY_NAME = "history";
		}

		/// <summary>
		/// 科目/分类 标记
		/// </summary>
		public class SubjectFlag
		{
			/// <summary>
			/// 分类标记
			/// </summary>
			public const int GROUP = 0;

			/// <summary>
			/// 科目标记
			/// </summary>
			public const int SUBJECT = 1;
		}

		/// <summary>
		/// 题型 主观/客观 标记
		/// </summary>
		public class ItemTypeFlag
		{
			/// <summary>
			/// 客观题
			/// </summary>
			public const int OBJECTIVE = 0;
			/// <summary>
			/// 主观题
			/// </summary>
			public const int SUBJECTIVE = 1;

			/// <summary>
			///  所有值
			/// </summary>
			public static readonly int[] values = { OBJECTIVE, SUBJECTIVE };
		}
		
		/// <summary>
		/// 题型分类
		/// </summary>
		public class ItemTypeFamily
		{
			/// <summary>
			/// 判断题
			/// </summary>
			public const int TF = 0;

			/// <summary>
			/// 单选题
			/// </summary>
			public const int SC = 1;

			/// <summary>
			/// 多选题
			/// </summary>
			public const int MC = 2;

			/// <summary>
			/// 问答题
			/// </summary>
			public const int EQ = 3;

			public static readonly int[] values = { TF, SC, MC, EQ };
		}

		/// <summary>
		/// 试题扩展标记
		/// </summary>
		public class ItemExtendFlag
		{
			/// <summary>
			/// 非扩展题
			/// </summary>
			public const int UNEXTEND = 0;

			/// <summary>
			/// 扩展题 子题
			/// </summary>
			public const int CHILD = 1;

			/// <summary>
			/// 扩展题 父题
			/// </summary>
			public const int PARENT = 2;

			/// <summary>
			/// 包括所有扩展标记类型
			/// </summary>
			public const int ALL = 3;

		}

		/// <summary>
		/// 试题练习顺序
		/// </summary>
		public class ItemOrder
		{

			/// <summary>
			/// 编号顺序
			/// </summary>
			public const int ORIGINAL = 0;

			/// <summary>
			/// 答题次数
			/// </summary>
			public const int TOTAL = 1;

			/// <summary>
			/// 答对次数
			/// </summary>
			public const int CORRECT = 2;

			/// <summary>
			/// 答题正确率
			/// </summary>
			public const int PRECISION = 3;

			/// <summary>
			/// 随机顺序
			/// </summary>
			public const int RANDOM = 4;

			public static readonly string[] names = { "原始次序", "答题次数", "答对次数", "答题正确率", "随机顺序" };
		}

		/// <summary>
		/// 考试试题答案结果
		/// </summary>
		public class ExamResultFlag
		{
			/// <summary>
			/// 错误
			/// </summary>
			public const int WRONG = 0;

			/// <summary>
			/// 正确
			/// </summary>
			public const int RIGHT = 1;

			/// <summary>
			/// 部分正确
			/// </summary>
			public const int PART = 2;
		}

		/// <summary>
		/// 试题查看模式
		/// </summary>
		public class ItemViewMode
		{
			/// <summary>
			/// 试题练习信息查看模式
			/// </summary>
			public const int PRACTICE = 0;

			/// <summary>
			/// 试题查看模式
			/// </summary>
			public const int DETAIL = 1;

			/// <summary>
			/// 试题编辑模式
			/// </summary>
			public const int UPDATE = 2;

			/// <summary>
			/// 试题创建模式
			/// </summary>
			public const int CREATE = 3;

			public static readonly string[] titles = { "练习详情", "试题详情", "试题编辑", "新建试题" };
		}
	}
}
