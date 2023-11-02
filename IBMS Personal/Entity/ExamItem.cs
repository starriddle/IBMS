using System.Collections.Generic;
using System.Text;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.Entity
{
	internal class ExamItem
	{
		public ExamItem(Item item, ItemDetail detail)
		{
			Item = item;
			Detail = detail;
			Answer = string.Empty;
		}

		/// <summary>
		/// 考试试题编号，从 1 开始
		/// </summary>
		public int Index { get; set; }

		public Item Item { get; set; }

		public ItemDetail Detail { get; set; }

		private List<ExamItem> children = new List<ExamItem>();

		public List<ExamItem> Children { get { return children; } set { children = value; } }

		public ExamItem AddChild(ExamItem child)
		{
			Children.Add(child);
			return this;
		}

		public string Answer { get; set; }

		public int ResultFlag { get; set; }

		public int ResultScore { get; set; }

		internal string ToPaperString()
		{
			StringBuilder sb = new StringBuilder();

			if (Item.Flag == ItemExtendFlag.CHILD) sb.Append("\t");
			if (Item.Flag != ItemExtendFlag.PARENT) sb.Append(Index).Append(". ");
			sb.Append(Detail.Question);
			char optionFlag = 'A';
			foreach (string option in Detail.Options)
			{
				sb.Append("\n\t");
				if (Item.Flag == ItemExtendFlag.CHILD) sb.Append("\t");
				sb.Append(optionFlag).Append(". ").Append(option);
				optionFlag++;
			}
			foreach (ExamItem child in Children)
			{
				sb.Append("\n\n").Append(child.ToPaperString());
			}
			return sb.ToString();
		}

		public override string ToString()
		{
			return Index.ToString()+ (string.IsNullOrWhiteSpace(Answer) ? "" : " Y");
		}
	}
}
