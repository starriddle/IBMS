using IBMS_Personal.Util;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace IBMS_Personal.Entity
{
	/// <summary>
	/// 试题详情
	/// </summary>
	public class ItemDetail
	{

		/// <summary>
		/// 试题编号
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 父题编号
		/// 默认：0 (非扩展题+父题，无上级父题)
		/// </summary>
		public long ParentId { get; set; }

		/// <summary>
		/// 选择题 选项个数，
		/// 默认：0 (扩展父题+非选择题，没有选项)
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// 参考答案，
		/// 默认：null (扩展父题，没有答案)，
		/// 判断题：T/F，
		/// 选择题：ABCDEF，
		/// 其他题型：文本答案
		/// </summary>
		public string Answer { get; set; }

		/// <summary>
		/// 题目
		/// </summary>
		public string Question { get; set; }

		private List<string> options = new List<string>();

		/// <summary>
		/// 选择题 选项列表
		/// </summary>
		public List<string> Options
		{
			get { return options; }
			set { options = value; }
		}

		public ItemDetail AddOption(string option)
		{
			options.Add(option);
			return this;
		}

		/// <summary>
		/// 数据行转换为实例
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static ItemDetail ConvertFrom(SQLiteDataReader reader)
		{
			ItemDetail detail = new ItemDetail();

			detail.Id = reader.GetInt64(0);
			detail.ParentId = reader.GetInt64(1);
			detail.Number = reader.GetInt32(2);
			detail.Answer = (reader.IsDBNull(3)) ? null : reader.GetString(3);
			detail.Question = (reader.IsDBNull(4)) ? null : reader.GetString(4);
			for (int i = 0; i < detail.Number; i++)
			{
				detail.AddOption((reader.IsDBNull(5 + i)) ? null : reader.GetString(5 + i));
			}
			return detail;
		}

		public ItemDetail ShuffleOptions()
		{
			if (Number == 0) return this;
			List<string> newOptions = CollectionUtil.Shuffle(Options);
			List<char> newAnswer = new List<char>();
			for (int i = 0; i < Answer.Length; i++)
			{
				newAnswer.Add((char)('A' + newOptions.IndexOf(Options[Answer[i] - 'A'])));
			}
			newAnswer.Sort();

			Options = newOptions;
			Answer = "";
			for (int i = 0; i < newAnswer.Count; i++)
			{
				Answer += newAnswer[i];
			}
			return this;
		}

		public StringBuilder ToFormatString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Question);
			for (int i = 0; i < Number; i++)
			{
				sb.Append("\n\t").Append((char)('A' + i)).Append(".\t").Append(Options[i]);
			}
			return sb;
		}

		public ItemDetail Copy()
		{
			ItemDetail detail = new ItemDetail();
			detail.Id = Id;
			detail.ParentId = ParentId;
			detail.Number = Number;
			detail.Answer = Answer;
			detail.Question = Question;
			foreach (string option in Options)
			{
				detail.AddOption(option);
			}
			return detail;
		}
	}
}
