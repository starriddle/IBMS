using IBMS_Personal.Entity;
using IBMS_Personal.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace IBMS_Personal.DAO
{
	internal class ItemDAO
	{

		internal int CountByTypeId(long typeId)
		{
			string sql = "SELECT count(1) FROM item WHERE type_id = @typeId";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@typeId", typeId }
			};
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql, parameters));
		}

		internal List<Item> ListByTypeId(long typeId)
		{
			string sql = " SELECT * FROM item WHERE type_id = @typeId ORDER BY id ";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@typeId", typeId }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, parameters);
			List<Item> result = new List<Item>();
			while (reader.Read())
			{
				result.Add(Item.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}

		internal int CountByChapterId(long chapterId)
		{
			string sql = "SELECT count(1) FROM item WHERE chapter_id = @chapterId";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@chapterId", chapterId }
			};
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql, parameters));
		}

		internal List<Item> ListByChapterId(long chapterId)
		{
			string sql = " SELECT * FROM item WHERE chapter_id = @chapterId ORDER BY id ";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@chapterId", chapterId }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, parameters);
			List<Item> result = new List<Item>();
			while (reader.Read())
			{
				result.Add(Item.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}

		internal int CountByTypeIdAndFlag(long typeId, int extendFlag, bool flag)
		{
			StringBuilder sql = new StringBuilder("SELECT count(1) FROM item WHERE type_id = @typeId ");
			sql.Append(" AND flag ").Append(flag ? " = " : " != ").Append(" @extendFlag");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@typeId", typeId },
				{ "@extendFlag", extendFlag }
			};
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql.ToString(), parameters));
		}

		internal List<Item> ListByTypeIdAndFlag(long typeId, int extendFlag, bool flag)
		{
			StringBuilder sql = new StringBuilder("SELECT * FROM item WHERE type_id = @typeId ");
			sql.Append(" AND flag ").Append(flag ? " = " : " != ").Append(" @extendFlag ").Append(" ORDER BY id");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@typeId", typeId },
				{ "@extendFlag", extendFlag }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql.ToString(), parameters);
			List<Item> result = new List<Item>();
			while (reader.Read())
			{
				result.Add(Item.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}

		internal int CountByChapterIdAndFlag(long chapterId, int extendFlag, bool flag)
		{
			StringBuilder sql = new StringBuilder("SELECT count(1) FROM item WHERE chapter_id = @chapterId ");
			sql.Append(" AND flag ").Append(flag ? " = " : " != ").Append(" @extendFlag");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@chapterId", chapterId },
				{ "@extendFlag", extendFlag }
			};
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql.ToString(), parameters));
		}

		internal List<Item> ListByChapterIdAndFlag(long chapterId, int extendFlag, bool flag)
		{
			StringBuilder sql = new StringBuilder("SELECT * FROM item WHERE chapter_id = @chapterId ");
			sql.Append(" AND flag ").Append(flag ? " = " : " != ").Append(" @extendFlag ").Append(" ORDER BY id");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@chapterId", chapterId },
				{ "@extendFlag", extendFlag }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql.ToString(), parameters);
			List<Item> result = new List<Item>();
			while (reader.Read())
			{
				result.Add(Item.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}

		internal List<Item> ListByParentId(long parentId)
		{
			string sql = "SELECT * FROM item WHERE parent_id = @parentId ORDER BY id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@parentId", parentId }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, parameters);
			List<Item> result = new List<Item>();
			while (reader.Read())
			{
				result.Add(Item.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}

		internal Item Insert(Item item)
		{
			string sql = "INSERT INTO item (type_id, chapter_id, flag, number, parent_id) VALUES (@tid, @cid, @flag, @num, @pid) RETURNING *";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@tid", item.TypeId },
				{ "@cid", item.ChapterId },
				{ "@flag", item.Flag },
				{ "@num", item.Number },
				{ "@pid", item.ParentId }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, parameters);
			Item result = null;
			if (reader.Read())
			{
				result = Item.ConvertFrom(reader);
			}
			reader.Close();
			return result;
		}

		internal int DeleteById(long id)
		{
			string sql = "DELETE FROM item WHERE id = @id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@id", id }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
		}

		internal int Update(Item item)
		{
			string sql = "Update item SET type_id = @typeId, chapter_id = @chapterId, flag = @flag, number = @number, parent_id = @parentId, correct = @correct, total = @total WHERE id = @id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@typeId", item.TypeId },
				{ "@chapterId", item.ChapterId },
				{ "@flag", item.Flag },
				{ "@number", item.Number },
				{ "@ParentId", item.ParentId },
				{ "@correct", item.Correct },
				{ "@total", item.Total },
				{ "@id", item.Id }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
		}

		internal int UpdatePracticeLog(Item item)
		{
			string sql = "Update item SET correct = @correct, total = @total WHERE id = @id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@correct", item.Correct },
				{ "@total", item.Total },
				{ "@id", item.Id }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
		}
	}
}
