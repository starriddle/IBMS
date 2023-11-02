using IBMS_Personal.Entity;
using IBMS_Personal.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace IBMS_Personal.DAO
{
	internal class SubjectDAO
	{

		internal int CountByParentId(long parentId)
		{
			string sql = "SELECT COUNT(1) FROM subject WHERE parent_id = @parentId";
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@parentId", parentId }
			};
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql, paremeters));
		}

		internal List<Subject> ListByParentId(long parentId)
		{
			string sql = "SELECT * FROM subject WHERE parent_id = @parentId ORDER BY id";
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@parentId", parentId }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, paremeters);
			List<Subject> result = new List<Subject>();
			while (reader.Read())
			{
				result.Add(Subject.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}

		internal Subject Insert(Subject subject)
		{
			string sql = "INSERT INTO subject (parent_id, flag, name) VALUES (@parentId, @flag, @name) RETURNING *";
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@parentId", subject.ParentId },
				{ "@flag", subject.Flag },
				{ "@name", subject.Name }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, paremeters);
			Subject result = null;
			if (reader.Read())
			{
				result = Subject.ConvertFrom(reader);
			}
			return result;
		}

		internal int DeleteById(long id)
		{
			string sql = "DELETE FROM subject WHERE id = @id";
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@id", id }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, paremeters);
		}
	}
}
