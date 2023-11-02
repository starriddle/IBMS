using System.Data.SQLite;

namespace IBMS_Personal.Entity
{
	/// <summary>
	/// 题型
	/// </summary>
	public class ItemType
	{
		/// <summary>
		/// 编号
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 主观/客观 标记
		/// </summary>
		public int Flag { get; set; }

		/// <summary>
		/// 分类
		/// </summary>
		public int Family { get; set; }

		public override string ToString()
		{
			return Name;
		}

		/// <summary>
		/// 将数据行转换为实例
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		internal static ItemType ConvertFrom(SQLiteDataReader reader)
		{
			return new ItemType
			{
				Id = reader.GetInt64(0),
				Name = reader.GetString(1),
				Flag = reader.GetInt32(2),
				Family = reader.GetInt32(3)
			};
		}
	}
}
