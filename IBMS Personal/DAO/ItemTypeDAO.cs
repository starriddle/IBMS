using IBMS_Personal.Entity;
using IBMS_Personal.Util;
using System.Collections.Generic;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace IBMS_Personal.DAO
{
	internal class ItemTypeDAO
	{

		internal List<ItemType> List()
		{
			string sql = "SELECT * FROM item_type ORDER BY id";
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql);
			List<ItemType> result = new List<ItemType>();
			while (reader.Read())
			{
				result.Add(ItemType.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}

		internal ItemType Insert(ItemType itemType)
		{
			string sql = "INSERT INTO item_type (id, name, flag, family) VALUES (@id, @name, @flag, @family) RETURNING *";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@name", itemType.Name },
				{ "@flag", itemType.Flag },
				{ "@family", itemType.Family }
			};
			if (itemType.Id == 0)
			{
				parameters.Add("@id", null);
			}
			else
			{
				parameters.Add("@id", itemType.Id);
			}
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, parameters);
			ItemType result = null;
			if (reader.Read())
			{
				result = ItemType.ConvertFrom(reader);
			}
			reader.Close();
			return result;
		}

		internal int DeleteById(long id)
		{
			string sql = "DELETE FROM item_type WHERE id = @id";
			Dictionary<string, object> paremeters = new Dictionary<string, object>
			{
				{ "@id", id }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, paremeters);
		}
	}
}
