using IBMS_Personal.DAO;
using IBMS_Personal.Entity;
using System.Collections.Generic;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.Service
{
	internal class ItemService
	{

		internal List<ItemType> GetAllTypes()
		{
			return DAOs.ItemTypeDao.List();
		}

		internal ItemType CreateType(ItemType newType)
		{
			return DAOs.ItemTypeDao.Insert(newType);
		}

		internal bool DeleteType(ItemType type)
		{
			int count = DAOs.ItemTypeDao.DeleteById(type.Id);
			return count == 1;
		}

		internal List<ItemChapter> GetChaptersByType(ItemType type)
		{
			return DAOs.ItemChapterDao.ListByTypeId(type.Id);
		}

		internal ItemChapter CreateChapter(ItemChapter newChapter)
		{
			return DAOs.ItemChapterDao.Insert(newChapter);
		}

		internal bool DeleteChapter(ItemChapter chapter)
		{
			int count = DAOs.ItemChapterDao.DeleteById(chapter.Id);
			return count == 1;
		}

		internal int CountItemsByType(ItemType type)
		{
			return DAOs.ItemDao.CountByTypeId(type.Id);
		}

		internal List<Item> GetItemsByType(ItemType type)
		{
			return DAOs.ItemDao.ListByTypeId(type.Id);
		}

		internal int CountItemsByChapter(ItemChapter chapter)
		{
			ItemType type = new ItemType() { Id = chapter.TypeId };
			if (chapter.Id == 0) return CountItemsByType(type);
			return DAOs.ItemDao.CountByChapterId(chapter.Id);
		}

		internal List<Item> GetItemsByChapter(ItemChapter chapter)
		{
			if (chapter.Id == 0)
			{
				ItemType type = new ItemType()
				{
					Id = chapter.TypeId
				};
				return GetItemsByType(type);
			}
			return DAOs.ItemDao.ListByChapterId(chapter.Id);
		}

		internal int CountItemsByTypeAndFlag(ItemType type, int extendFlag, bool flag)
		{
			if (extendFlag == ItemExtendFlag.ALL) return CountItemsByType(type);
			return DAOs.ItemDao.CountByTypeIdAndFlag(type.Id, extendFlag, flag);
		}

		internal List<Item> GetItemsByTypeAndFlag(ItemType type, int extendFlag, bool flag)
		{
			if (extendFlag == ItemExtendFlag.ALL)
			{
				return GetItemsByType(type);
			}
			return DAOs.ItemDao.ListByTypeIdAndFlag(type.Id, extendFlag, flag);
		}

		internal int CountItemsByChapterWithFlag(ItemChapter chapter, int extendFlag, bool flag)
		{
			ItemType type = new ItemType() { Id = chapter.TypeId };
			if (extendFlag == ItemExtendFlag.ALL)
				return CountItemsByChapter(chapter);
			if (chapter.Id == 0)
				return CountItemsByTypeAndFlag(type, extendFlag, flag);
			return DAOs.ItemDao.CountByChapterIdAndFlag(chapter.Id, extendFlag, flag);
		}

		internal List<Item> GetItemsByChapterWithFlag(ItemChapter chapter, int extendFlag, bool flag)
		{
			if (extendFlag == ItemExtendFlag.ALL)
			{
				return GetItemsByChapter(chapter);
			}
			if (chapter.Id == 0)
			{
				ItemType type = new ItemType()
				{
					Id = chapter.TypeId
				};
				return GetItemsByTypeAndFlag(type, extendFlag, flag);
			}
			return DAOs.ItemDao.ListByChapterIdAndFlag(chapter.Id, extendFlag, flag);
		}
	}
}
