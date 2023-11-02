using System.Reflection;

namespace IBMS_Personal.Util
{
	internal static class VersionUtil
	{

		public static string Info()
		{
			string version = "程序集版本：" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			return version;
		}
	}
}
