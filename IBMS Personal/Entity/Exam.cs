using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.Entity
{
	internal class Exam
	{
		public DateTime StartTime { get; set; }

		public TimeSpan Duration { get; set; }

		public int TotalScore { get; set; }

		public int TotalCount { get; set; }

		private List<ExamModule> modules = new List<ExamModule>();

		public List<ExamModule> Modules { get => modules; set => modules = value; }

		public Exam AddModule(ExamModule module)
		{
			Modules.Add(module);
			return this;
		}

		public string ToPaperString()
		{
			StringBuilder sb = new StringBuilder("模拟考试试卷");
			for (int i = 0; i < modules.Count; i++)
			{
				ExamModule module = modules[i];
				sb.AppendFormat("\n\n--------\n第{0}部分 ", i + 1).Append(module.ToPaperString());
			}
			sb.Append("\n\n--------\n（卷尾）");
			return sb.ToString();
		}


		public class ExamModule
		{
			public ItemType ItemType { get; set; }

			public int Score { get; set; }

			private List<ExamItem> items = new List<ExamItem>();

			public List<ExamItem> Items { get => items; set => items = value; }

			public ExamModule AddItem(ExamItem addItem)
			{
				Items.Add(addItem);
				return this;
			}

			public ExamModule AddItems(List<ExamItem> addItems)
			{
				Items.AddRange(addItems);
				return this;
			}

			public string ToPaperString()
			{
				StringBuilder sb = new StringBuilder(ItemType.Name);
				foreach (ExamItem item in items)
				{
					sb.Append("\n\n").Append(item.ToPaperString());
				}
				return sb.ToString();
			}

			public override string ToString()
			{
				bool finished = true;
				foreach (ExamItem item in items)
				{
					if (item.Item.Flag == ItemExtendFlag.PARENT)
					{
						if (item.Children.Any(child => string.IsNullOrWhiteSpace(child.Answer)))
						{
							finished = false;
							break;
						}
					}
					else if (string.IsNullOrWhiteSpace(item.Answer))
					{
						finished = false;
						break;
					}
				}
				return ItemType.Name + (finished ? " Y" : "");
			}
		}
	}
}
