using IBMS_Personal.Entity;
using IBMS_Personal.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace IBMS_Personal.DAO
{
	internal class ExamLogDAO
	{
		internal int Count()
		{
			string sql = "SELECT count(1) FROM exam_log";
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql));
		}

		internal int InsertWithoutId(ExamLog log)
		{
			string sql = "INSERT INTO exam_log (start_time, score, duration, total_score, total_time, structure) VALUES (@startTime, @score, @duration, @totalScore, @totalTime, @structure)";
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@startTime", log.StartTime.ToString() },
				{ "@score", log.Score },
				{ "@duration", log.Duration.ToString() },
				{ "@totalScore", log.TotalScore },
				{ "@totalTime", log.TotalTime.ToString() },
				{ "@structure", log.Structure }
			};
			int count = SQLiteUtil.get().ExecuteNonQuery(sql, paremeters);
			return count;
		}

		internal List<ExamLog> SelectByPage(int pageIndex, int pageSize)
		{
			List<ExamLog> result = new List<ExamLog>();
			string sql = "SELECT * FROM exam_log ORDER BY id LIMIT @limit OFFSET @offset";
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@limit", pageSize },
				{ "@offset", pageIndex * pageSize }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, paremeters);
			while (reader.Read())
			{
				result.Add(ExamLog.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}
	}
}
