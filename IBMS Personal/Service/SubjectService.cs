using IBMS_Personal.DAO;
using IBMS_Personal.Entity;
using System.Collections.Generic;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.Service
{
	internal class SubjectService
	{
		internal Subject AddSubject(string name, long parentId, int subjectFlag)
		{
			Subject subject = new Subject()
			{
				ParentId = parentId,
				Name = name,
				Flag = subjectFlag
			};
			subject = DAOs.SubjectDao.Insert(subject);
			return subject;
		}

		internal void DeleteSubject(Subject subject)
		{
			DAOs.SubjectDao.DeleteById(subject.Id);
		}

		internal Subject GetSubjectById(long id)
		{
			return DAOs.SubjectDao.GetById(id);
		}

		internal int CountSubjectsByParentGroup(Subject group)
		{
			return DAOs.SubjectDao.CountByParentId(group.Id);
		}

		internal Dictionary<int, List<Subject>> getSubjectsByParentId(long parentId)
		{
			Dictionary<int, List<Subject>> collection = new Dictionary<int, List<Subject>>();
			List<Subject> list = DAOs.SubjectDao.ListByParentId(parentId);
			if(list.Count == 0)
			{
				return collection;
			}
			List<Subject> groups = new List<Subject>();
			List<Subject> subjects = new List<Subject>();
			foreach (Subject subject in list)
			{
				if(subject.Flag == SubjectFlag.SUBJECT)
				{
					subjects.Add(subject);
				}
				else
				{
					groups.Add(subject);
				}
			}
			collection.Add(SubjectFlag.GROUP, groups);
			collection.Add(SubjectFlag.SUBJECT, subjects);
			return collection;
		}
	}
}
