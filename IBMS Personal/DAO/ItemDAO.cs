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
			string sql = "SELECT count(1) FROM item WHERE type_id = @tid";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@tid", typeId }
			};
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql, parameters));
		}

		internal List<Item> ListByTypeId(long typeId)
		{
			string sql = " SELECT * FROM item WHERE type_id = @tid ORDER BY id ";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@tid", typeId }
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
			string sql = "SELECT count(1) FROM item WHERE chapter_id = @cid";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@cid", chapterId }
			};
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql, parameters));
		}

		internal List<Item> ListByChapterId(long chapterId)
		{
			string sql = " SELECT * FROM item WHERE chapter_id = @cid ORDER BY id ";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@cid", chapterId }
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
			StringBuilder sql = new StringBuilder("SELECT count(1) FROM item WHERE type_id = @tid ");
			sql.Append(" AND flag ").Append(flag ? " = " : " != ").Append(" @flag");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@tid", typeId },
				{ "@flag", extendFlag }
			};
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql.ToString(), parameters));
		}

		internal List<Item> ListByTypeIdAndFlag(long typeId, int extendFlag, bool flag)
		{
			StringBuilder sql = new StringBuilder("SELECT * FROM item WHERE type_id = @tid ");
			sql.Append(" AND flag ").Append(flag ? " = " : " != ").Append(" @flag ").Append(" ORDER BY id");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@tid", typeId },
				{ "@flag", extendFlag }
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
			StringBuilder sql = new StringBuilder("SELECT count(1) FROM item WHERE chapter_id = @cid ");
			sql.Append(" AND flag ").Append(flag ? " = " : " != ").Append(" @flag");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@cid", chapterId },
				{ "@flag", extendFlag }
			};
			return Convert.ToInt32(SQLiteUtil.get().ExecuteScalar(sql.ToString(), parameters));
		}

		internal List<Item> ListByChapterIdAndFlag(long chapterId, int extendFlag, bool flag)
		{
			StringBuilder sql = new StringBuilder("SELECT * FROM item WHERE chapter_id = @cid ");
			sql.Append(" AND flag ").Append(flag ? " = " : " != ").Append(" @flag ").Append(" ORDER BY id");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@cid", chapterId },
				{ "@flag", extendFlag }
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
			string sql = "SELECT * FROM item WHERE parent_id = @pid ORDER BY id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@pid", parentId }
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
			string sql = "INSERT INTO item (id, type_id, chapter_id, flag, number, parent_id) VALUES (@id, @tid, @cid, @flag, @num, @pid) RETURNING *";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@tid", item.TypeId },
				{ "@cid", item.ChapterId },
				{ "@flag", item.Flag },
				{ "@num", item.Number },
				{ "@pid", item.ParentId }
			};
			if (item.Id == 0)
			{
				parameters.Add("@id", null);
			}
			else
			{
				parameters.Add("@id", item.Id);
			}
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

		internal int DeleteByParentId(long parentId)
		{
			string sql = "DELETE FROM item WHERE parent_id = @pid";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@pid", parentId }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
		}

		internal int Update(Item item)
		{
			string sql = "Update item SET type_id = @tid, chapter_id = @cid, flag = @flag, number = @num, parent_id = @pid, correct = @co, total = @to WHERE id = @id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@tid", item.TypeId },
				{ "@cid", item.ChapterId },
				{ "@flag", item.Flag },
				{ "@num", item.Number },
				{ "@pid", item.ParentId },
				{ "@co", item.Correct },
				{ "@to", item.Total },
				{ "@id", item.Id }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
		}

		internal int UpdatePracticeLog(Item item)
		{
			string sql = "Update item SET correct = @co, total = @to WHERE id = @id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@co", item.Correct },
				{ "@to", item.Total },
				{ "@id", item.Id }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
		}
	}
}
