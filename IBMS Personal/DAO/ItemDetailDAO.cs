using IBMS_Personal.Entity;
using IBMS_Personal.Util;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace IBMS_Personal.DAO
{
	internal class ItemDetailDAO
	{

		internal ItemDetail SelectById(long id)
		{
			string sql = "SELECT * FROM item_detail WHERE id = @id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@id", id }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, parameters);
			ItemDetail item = null;
			if (reader.Read())
			{
				item = ItemDetail.ConvertFrom(reader);
			}
			reader.Close();
			return item;
		}

		internal List<ItemDetail> ListByParentId(long parentId)
		{
			string sql = "SELECT * FROM item_detail WHERE parent_id = @pid ORDER BY id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@pid", parentId }
			};
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql, parameters);
			List<ItemDetail> result = new List<ItemDetail>();
			while (reader.Read())
			{
				result.Add(ItemDetail.ConvertFrom(reader));
			}
			reader.Close();
			return result;
		}

		/// <summary>
		/// 插入 ItemDetail 对象
		/// 字段列表(id, parent_id, number, answer, question, first, second, third, fourth, fifth, sixth)
		/// </summary>
		/// <param name="detail"></param>
		/// <returns></returns>
		internal ItemDetail Insert(ItemDetail detail)
		{
			StringBuilder sql = new StringBuilder("INSERT INTO item_detail VALUES (@id, @pid, @num, @an, @qu, @1st, @2nd, @3rd, @4th, @5th, @6th) RETURNING *");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@id", detail.Id },
				{ "@pid", detail.ParentId },
				{ "@num", detail.Number },
				{ "@an", detail.Answer },
				{ "@qu", detail.Question }
			};
			List<string> keys = new List<string>() { "@1st", "@2nd", "@3rd", "@4th", "@5th", "@6th" };
			for (int i = 0; i< detail.Number; i++)
			{
				parameters.Add(keys[i], detail.Options[i]);
			}
			for (int i = detail.Number; i < keys.Count; i++)
			{
				parameters.Add(keys[i], null);
			}
			SQLiteDataReader reader = SQLiteUtil.get().ExcuteReader(sql.ToString(), parameters);
			ItemDetail result = null;
			if (reader.Read())
			{
				result = ItemDetail.ConvertFrom(reader);
			}
			reader.Close();
			return result;
		}

		internal int Update(ItemDetail detail)
		{
			StringBuilder sql = new StringBuilder("UPDATE item_detail SET parent_id = @pid, number = @num, answer = @an, question = @qu ");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@pid", detail.ParentId },
				{ "@num", detail.Number },
				{ "@an", detail.Answer },
				{ "@qu", detail.Question }
			};

			List<string> columns = new List<string>() { "first", "second", "third", "fourth", "fifth", "sixth" };
			List<string> keys = new List<string>() { "@1st", "@2nd", "@3rd", "@4th", "@5th", "@6th" };
			for (int i = 0; i < detail.Number; i++)
			{
				sql.Append(" , ").Append(columns[i]).Append(" = ").Append(keys[i]).Append(" ");
				parameters.Add(keys[i], detail.Options[i]);
			}
			sql.Append(" WHERE id = @id");
			parameters.Add("@id", detail.Id);
			return SQLiteUtil.get().ExecuteNonQuery(sql.ToString(), parameters);
		}

		internal int DeleteById(long id)
		{
			string sql = "DELETE FROM item_detail WHERE id = @id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@id", id }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
		}

		internal int DeleteByParentId(long parentId)
		{
			string sql = "DELETE FROM item_detail WHERE parent_id = @pid";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@pid", parentId }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
		}
	}
}
