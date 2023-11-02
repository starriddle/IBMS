using System.Data.SQLite;

namespace IBMS_Personal.Entity
{
	/// <summary>
	/// 章节
	/// </summary>
	public class ItemChapter
	{

		/// <summary>
		/// 编号
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 题型编号
		/// </summary>
		public long TypeId { get; set; }

		/// <summary>
		/// 名称
		/// </summary>
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}

		/// <summary>
		/// 将数据行转换为实例
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		internal static ItemChapter ConvertFrom(SQLiteDataReader reader)
		{
			return new ItemChapter
			{
				Id = reader.GetInt64(0),
				TypeId = reader.GetInt64(1),
				Name = reader.GetString(2)
			};
		}
	}
}
