namespace IBMS_Personal.Service
{
	internal static class Services
	{
		private static SubjectService subjectService;
		internal static SubjectService SubjectService
		{
			get
			{
				if (subjectService == null)
				{
					subjectService = new SubjectService();
				}
				return subjectService;
			}
		}

		private static FileService fileService;
		internal static FileService FileService
		{
			get
			{
				if(fileService == null)
				{
					fileService = new FileService();
				}
				return fileService;
			}

		}

		private static ItemService itemService;
		internal static ItemService ItemService
		{
			get
			{
				if (itemService == null)
				{
					itemService = new ItemService();
				}
				return itemService;
			}
		}

		private static ContentService contentService;
		internal static ContentService ContentService
		{
			get
			{
				if (contentService == null)
				{
					contentService = new ContentService();
				}
				return contentService;
			}
		}

		private static ExamService examService;

		internal static ExamService ExamService
		{
			get
			{
				if (examService == null)
				{
					examService = new ExamService();
				}
				return examService;
			}
		}
	}
}
