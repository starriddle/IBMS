using IBMS_Personal.Entity;
using IBMS_Personal.Util;
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
			string sql = "SELECT * FROM item_detail WHERE parent_id = @parentId ORDER BY id";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@parentId", parentId }
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
		internal int Insert(ItemDetail detail)
		{
			StringBuilder sql = new StringBuilder("INSERT INTO item_detail VALUES (@id, @parentId, @number, @answer, @question, @first, @second, @third, @fourth, @fifth, @sixth)");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@id", detail.Id },
				{ "@parentId", detail.ParentId },
				{ "@number", detail.Number },
				{ "@answer", detail.Answer },
				{ "@question", detail.Question }
			};
			List<string> keys = new List<string>() { "@first", "@second", "@third", "@fourth", "@fifth", "@sixth" };
			for (int i = 0; i< detail.Number; i++)
			{
				parameters.Add(keys[i], detail.Options[i]);
			}
			for (int i = detail.Number; i < keys.Count; i++)
			{
				parameters.Add(keys[i], null);
			}
			return SQLiteUtil.get().ExecuteNonQuery(sql.ToString(), parameters);
		}

		internal int Update(ItemDetail detail)
		{
			StringBuilder sql = new StringBuilder("UPDATE item_detail SET parent_id = @parentId, number = @number, answer = @answer, question = @question ");
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@parentId", detail.ParentId },
				{ "@number", detail.Number },
				{ "@answer", detail.Answer },
				{ "@question", detail.Question }
			};
			switch (detail.Number)
			{
				case 6:
					sql.Append(" , sixth = @sixth ");
					parameters.Add("@sixth", detail.Options[5]);
					goto case 5;
				case 5:
					sql.Append(" , fifth = @fifth ");
					parameters.Add("@fifth", detail.Options[4]);
					goto case 4;
				case 4:
					sql.Append(" , fourth = @fourth ");
					parameters.Add("@fourth", detail.Options[3]);
					goto case 3;
				case 3:
					sql.Append(" , third = @third ");
					parameters.Add("@third", detail.Options[2]);
					goto case 2;
				case 2:
					sql.Append(" , second = @second ");
					parameters.Add("@second", detail.Options[1]);
					goto case 1;
				case 1:
					sql.Append(" , first = @first ");
					parameters.Add("@first", detail.Options[0]);
					break;
				default:
					break;
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
			string sql = "DELETE FROM item_detail WHERE parent_id = @parentId";
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "@parentId", parentId }
			};
			return SQLiteUtil.get().ExecuteNonQuery(sql, parameters);
		}
	}
}
