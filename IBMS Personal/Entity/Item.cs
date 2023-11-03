using System.Data.SQLite;

namespace IBMS_Personal.Entity
{
	/// <summary>
	/// 试题
	/// </summary>
	public class Item
	{

		/// <summary>
		/// 试题编号
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 题型编号
		/// </summary>
		public long TypeId { get; set; }

		/// <summary>
		/// 章节编号
		/// 默认：0 (无章节)
		/// </summary>
		public long ChapterId { get; set; }

		/// <summary>
		/// 扩展标记
		/// 0-非扩展题(默认)，1-子题，2-父题
		/// </summary>
		public int Flag { get; set; }

		/// <summary>
		/// 扩展（子题）数量
		/// 默认：0 (非扩展题+子题，无下级子题)
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// 父题编号
		/// 默认：0 (非扩展题+父题，无上级父题)
		/// </summary>
		public long ParentId { get; set; }

		/// <summary>
		/// 答题正确次数
		/// </summary>
		public int Correct { get; set; }

		/// <summary>
		/// 答题总次数
		/// </summary>
		public int Total { get; set; }

		/// <summary>
		/// 将数据行转换为实例
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static Item ConvertFrom(SQLiteDataReader reader)
		{
			return new Item
			{
				Id = reader.GetInt64(0),
				TypeId = reader.GetInt64(1),
				ChapterId = reader.GetInt64(2),
				Flag = reader.GetInt32(3),
				Number = reader.GetInt32(4),
				ParentId = reader.GetInt64(5),
				Correct = reader.GetInt32(6),
				Total = reader.GetInt32(7)
			};
		}
		
		public Item Copy()
		{
			Item item = new Item();
			item.Id = Id;
			item.TypeId = TypeId;
			item.ChapterId = ChapterId;
			item.Flag = Flag;
			item.Number = Number;
			item.ParentId = ParentId;
			item.Correct = Correct;
			item.Total = Total;
			return item;
		}
	}
}
