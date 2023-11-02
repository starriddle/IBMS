using IBMS_Personal.Entity;
using IBMS_Personal.Util;
using System.Collections.Generic;
using System.Data.SQLite;

namespace IBMS_Personal.DAO
{
	internal class ItemChapterDAO
	{

		internal List<ItemChapter> ListByTypeId(long typeId)
		{
			string sql = string.Format("SELECT * FROM item_chapter WHERE type_id = @typeId ORDER BY id");
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@typeId", typeId }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, paremeters);
			List<ItemChapter> result = new List<ItemChapter>();
			while (reader.Read())
			{
				result.Add(ItemChapter.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}

		internal ItemChapter Insert(ItemChapter chapter)
		{
			string sql = "INSERT INTO item_chapter (type_id, name) VALUES (@typeId, @name) RETURNING *";
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@typeId", chapter.TypeId },
				{ "@name", chapter.Name }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, paremeters);
			ItemChapter result = null;
			if (reader.Read())
			{
				result = ItemChapter.ConvertFrom(reader);
			}
			reader.Close();
			return result;
		}

		internal int DeleteById(long id)
		{
			string sql = "DELETE FROM item_chapter WHERE id = @id";
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@id", id }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, paremeters);
		}
	}
}
