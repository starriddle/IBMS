using System;
using System.Data.SQLite;

namespace IBMS_Personal.Entity
{
	/// <summary>
	/// 模拟考试记录
	/// </summary>
	public class ExamLog
	{

		/// <summary>
		/// 记录编号
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 考试开始时间
		/// </summary>
		public DateTime StartTime { get; set; }

		/// <summary>
		/// 得分
		/// </summary>
		public double Score { get; set; }

		/// <summary>
		/// 实际考试时间
		/// </summary>
		public TimeSpan Duration { get; set; }

		/// <summary>
		/// 卷面总分
		/// </summary>
		public double TotalScore { get; set; }

		/// <summary>
		/// 设计考试时间
		/// </summary>
		public TimeSpan TotalTime { get; set; }

		/// <summary>
		/// 试卷结构
		/// </summary>
		public string Structure { get; set; }

		/// <summary>
		/// 将数据行转换为实例
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static ExamLog ConvertFrom(SQLiteDataReader reader)
		{
			return new ExamLog
			{
				Id = reader.GetInt64(0),
				StartTime = DateTime.Parse(reader.GetString(1)),
				Score = reader.GetDouble(2),
				Duration = TimeSpan.Parse(reader.GetString(3)),
				TotalScore = reader.GetDouble(4),
				TotalTime = TimeSpan.Parse(reader.GetString(5)),
				Structure = reader.GetString(6)
			};
		}
	}
}
