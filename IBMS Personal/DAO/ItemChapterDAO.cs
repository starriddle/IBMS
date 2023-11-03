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
			string sql = string.Format("SELECT * FROM item_chapter WHERE type_id = @tid ORDER BY id");
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@tid", typeId }
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
			string sql = "INSERT INTO item_chapter (id, type_id, name) VALUES (@id, @tid, @name) RETURNING *";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@tid", chapter.TypeId },
				{ "@name", chapter.Name }
			};
			if (chapter.Id == 0)
			{
				parameters.Add("@id", null);
			}
			else
			{
				parameters.Add("@id", chapter.Id);
			}
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, parameters);
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
