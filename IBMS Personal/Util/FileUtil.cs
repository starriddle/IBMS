using System.IO;
using System.Windows.Forms;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.Util
{
	public class FileUtil
	{

		/// <summary>
		/// 生成 主数据库 文件，如果不存在
		/// </summary>
		public static void GenerateDBFile()
		{
			string dest = Path.Combine(DB.BASE_PATH, DB.MAIN_NAME);
			if (!File.Exists(dest))
			{
				string source = Path.Combine(DB.BASE_PATH, DB.MAIN_SAMPLE);
				if (File.Exists(source))
				{
					File.Copy(source, dest);
				}
				else
				{
					MessageBox.Show("程序原始文件损坏，请重新安装！");
					Application.Exit();
				}
			}
		}

		/// <summary>
		/// 根据 科目ID 生成对应的 科目数据库 文件，如果相应文件不存在
		/// </summary>
		public static void GenerateDBFile(long subjectId)
		{
			string dest = Path.Combine(DB.BASE_PATH, subjectId.ToString());
			if (!File.Exists(dest))
			{
				string source = Path.Combine(DB.BASE_PATH, DB.SUBJECT_SAMPLE);
				if (File.Exists(source))
				{
					File.Copy(source, dest);
				}
				else
				{
					MessageBox.Show("程序原始文件损坏，请重新安装！");
					Application.Exit();
				}
			}
		}

		public static void DeleteDBFile(long subjectId)
		{
			string dest = Path.Combine(DB.BASE_PATH, subjectId.ToString());
			if (File.Exists(dest))
			{
				File.Delete(dest);
			}
		}
	}
}
