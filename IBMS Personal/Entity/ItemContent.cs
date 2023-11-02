using System.Collections.Generic;

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

		public ItemContent Copy()
		{
			ItemContent content = new ItemContent(Item, Detail);
			foreach (ItemContent child in Children)
			{
				content.AddChild(child.Copy());
			}
			return content;
		}
	}
}
