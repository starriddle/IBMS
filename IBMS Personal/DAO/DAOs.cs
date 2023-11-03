namespace IBMS_Personal.DAO
{
	internal static class DAOs
	{
		private static SubjectDAO subjectDao;
		internal static SubjectDAO SubjectDao
		{
			get
			{
				if (subjectDao == null)
				{
					subjectDao = new SubjectDAO();
				}
				return subjectDao;
			}
		}

		private static ItemTypeDAO itemTypeDao;
		internal static ItemTypeDAO ItemTypeDao
		{
			get
			{
				if (itemTypeDao == null)
				{
					itemTypeDao = new ItemTypeDAO();
				}
				return itemTypeDao;
			}
		}

		private static ItemChapterDAO itemChapterDao;
		internal static ItemChapterDAO ItemChapterDao
		{
			get
			{
				if (itemChapterDao == null)
				{
					itemChapterDao = new ItemChapterDAO();
				}
				return itemChapterDao;
			}
		}

		private static ItemDAO itemDao;
		internal static ItemDAO ItemDao
		{
			get
			{
				if (itemDao == null)
				{
					itemDao = new ItemDAO();
				}
				return itemDao;
			}
		}

		private static ItemDetailDAO itemDetailDao;
		internal static ItemDetailDAO ItemDetailDao
		{
			get
			{
				if (itemDetailDao == null)
				{
					itemDetailDao = new ItemDetailDAO();
				}
				return itemDetailDao;
			}
		}

		private static ExamLogDAO examLogDao;
		internal static ExamLogDAO ExamLogDao
		{
			get
			{
				if (examLogDao == null)
				{
					examLogDao = new ExamLogDAO();
				}
				return examLogDao;
			}
		}
	}
}
