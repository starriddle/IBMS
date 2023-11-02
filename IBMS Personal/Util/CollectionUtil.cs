using System;
using System.Collections.Generic;

namespace IBMS_Personal.Util
{
	internal class CollectionUtil
	{
		public static List<T> Shuffle<T>(List<T> list)
		{
			if (list == null) return null;

			Random random = new Random();
			int first = random.Next(list.Count);

			List<T> result = new List<T>();
			for (int i = 0; i < list.Count; i++)
			{
				result.Insert(random.Next(result.Count+1), list[(first+i)%list.Count]);
			}
			return result;
		}

		public static List<T> Shuffle<T>(params T[] array)
		{
			if (array == null) return null;

			Random random = new Random();
			int first = random.Next(array.Length);

			List<T> result = new List<T>();
			for (int i = 0; i < array.Length; i++)
			{
				result.Insert(random.Next(result.Count + 1), array[(first + i) % array.Length]);
			}
			return result;
		}
	}
}
