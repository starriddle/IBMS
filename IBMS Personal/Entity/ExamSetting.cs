using System;
using System.Collections.Generic;
using System.Text;

namespace IBMS_Personal.Entity
{
	internal class ExamSetting
	{
		public TimeSpan TotalTime { get; set; }

		public int TotalScore { get; set; }

		private List<ExamModuleSetting> modules = new List<ExamModuleSetting>();

		public List<ExamModuleSetting> GetModules()
		{
			return modules;
		}

		public ExamSetting AddModule(ExamModuleSetting module)
		{
			modules.Add(module);
			return this;
		}

		public ExamSetting RemoveModule()
		{
			modules.RemoveAt(modules.Count - 1);
			return this;
		}

		public int CountModules()
		{
			return modules.Count;
		}

		public int CountScore()
		{
			int total = 0;
			foreach (ExamModuleSetting module in modules)
			{
				total += module.CountScore();
			}
			return total;
		}

		public string Show()
		{
			StringBuilder sb = new StringBuilder();
			bool start = true;
			foreach (var module in modules)
			{
				if (start) { start = false; }
				else { sb.Append("\n"); }
				sb.Append(module.ToString());
			}
			return sb.ToString();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder()
				.AppendFormat("时间: {0} 分钟, 总分: {1} 分\n模块：\n", TotalTime.Hours * 60 + TotalTime.Minutes, TotalScore)
				.Append(Show());
			return sb.ToString();
		}

		internal class ExamModuleSetting
		{
			public ItemType ItemType { get; set; }

			public int Score { get; set; }

			public Dictionary<ItemChapter, int> Chapters { get; set; }

			public ExamModuleSetting(ItemType itemType, int score)
			{
				ItemType = itemType;
				Score = score;
				Chapters = new Dictionary<ItemChapter, int>();
			}

			public ExamModuleSetting AddChapter(ItemChapter chapter, int number)
			{
				Chapters.Add(chapter, number);
				return this;
			}

			public int CountScore()
			{
				int number = 0;
				foreach (KeyValuePair<ItemChapter, int> pair in Chapters)
				{
					number += pair.Value;
				}
				return number * Score;
			}

			public override string ToString()
			{
				StringBuilder sb = new StringBuilder().AppendFormat("题型: {0}, 分值: {1}, 选题: [", ItemType.Name, Score);
				bool start = true;
				foreach (KeyValuePair<ItemChapter, int> pair in Chapters)
				{
					if (start) { start = false; }
					else { sb.Append(", "); }
					sb.AppendFormat("{0}({1})", pair.Key.Name, pair.Value);
				}
				sb.Append("]");
				return sb.ToString();
			}
		}
	}
}
