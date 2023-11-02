using System.Data.SQLite;

namespace IBMS_Personal.Entity
{
	/// <summary>
	/// 科目/分类
	/// </summary>
	internal class Subject
	{
		/// <summary>
		/// 编号
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// 父类编号
		/// </summary>
		public long ParentId { get; set; }

		/// <summary>
		/// 科目/分类 标记
		/// </summary>
		public int Flag { get; set; }

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
		internal static Subject ConvertFrom(SQLiteDataReader reader)
		{
			return new Subject
			{
				Id = reader.GetInt64(0),
				ParentId = reader.GetInt64(1),
				Flag = reader.GetInt32(2),
				Name = reader.GetString(3)
			};
		}
	}
}
