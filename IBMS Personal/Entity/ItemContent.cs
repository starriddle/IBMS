using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace IBMS_Personal.Entity
{
	public class ItemContent
	{
		public Item Item { get; set; }

		public ItemDetail Detail { get; set; }

		private List<ItemContent> children = new List<ItemContent>();

		public List<ItemContent> Children { get => children; set => children = value; }

		public ItemContent() { }

		public ItemContent(Item item)
		{
			Item = item;
		}

		public ItemContent(Item item, ItemDetail detail)
		{
			Item = item;
			Detail = detail;
		}

		public ItemContent AddChild(ItemContent item)
		{
			children.Add(item);
			return this;
		}

		public ItemContent SimplyCopy()
		{
			ItemContent content = new ItemContent(Item, Detail);
			foreach (ItemContent child in Children)
			{
				content.AddChild(child.SimplyCopy());
			}
			return content;
		}

		public ItemContent FullyCopy()
		{
			ItemContent content = new ItemContent(Item.Copy(), Detail.Copy());
			foreach (ItemContent child in Children)
			{
				content.AddChild(child.FullyCopy());
			}
			return content;
		}
	}
}
