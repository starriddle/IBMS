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
			string sql = "INSERT INTO exam_log (id, start_time, score, duration, total_score, total_time, structure) VALUES (@id, @st, @score, @dt, @ts, @tt, @str)";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@st", log.StartTime.ToString() },
				{ "@score", log.Score },
				{ "@dt", log.Duration.ToString() },
				{ "@ts", log.TotalScore },
				{ "@tt", log.TotalTime.ToString() },
				{ "@str", log.Structure }
			};
			if (log.Id == 0)
			{
				parameters.Add("@id", null);
			}
			else
			{
				parameters.Add("@id", log.Id);
			}
			int count = SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
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
