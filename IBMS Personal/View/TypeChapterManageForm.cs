using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IBMS_Personal.View
{
	public partial class TypeChapterManageForm : Form
	{
		private ItemContentForm itemContentForm;

		public TypeChapterManageForm(ItemContentForm itemContentForm)
		{
			InitializeComponent();
			this.itemContentForm = itemContentForm;
		}

		private void TypeChapterManageForm_Load(object sender, EventArgs e)
		{
			InitTypeData();
		}

		private void InitTypeData()
		{
			typeComboBox.Items.Clear();
			List<ItemType> types = Services.ItemService.GetAllTypes();
			for (int index = 0; index < types.Count; index++)
			{
				typeComboBox.Items.Add(types[index]);
			}
			typeComboBox.Enabled = true;
			deleteTypeButton.Enabled = false;
			typeTextBox.Text = string.Empty;
			typeTextBox.Enabled = true;
			addTypeButton.Enabled = true;

			familyLabel.Text = flagLabel.Text = string.Empty;

			familyComboBox.SelectedIndex = 0;
			familyComboBox.Enabled = true;
			flagComboBox.SelectedIndex = 0;
			flagComboBox.Enabled = false;

			InitChapterData();
		}

		private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ItemType currentType = (ItemType)this.typeComboBox.SelectedItem;
			familyLabel.Text = familyComboBox.Items[currentType.Family].ToString();
			flagLabel.Text = flagComboBox.Items[currentType.Flag].ToString();
			deleteTypeButton.Enabled = true;

			InitChapterData();
		}

		private void InitChapterData()
		{
			deleteChapterButton.Enabled = false;
			this.chapterComboBox.Items.Clear();
			chapterTextBox.Text = string.Empty;
			ItemType currentType = (ItemType)this.typeComboBox.SelectedItem;
			if (currentType == null)
			{
				chapterComboBox.Enabled = false;
				chapterTextBox.Enabled = false;
				addChapterButton.Enabled = false;
			}
			else
			{
				List<ItemChapter> chapters = Services.ItemService.GetChaptersByType(currentType);
				for (int index = 0; index < chapters.Count; index++)
				{
					chapterComboBox.Items.Add(chapters[index]);
				}
				chapterComboBox.Enabled = true;
				chapterTextBox.Enabled = true;
				addChapterButton.Enabled = true;
			}
		}

		private void ChapterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			deleteChapterButton.Enabled = true;
		}

		private void FamilyComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (familyComboBox.SelectedIndex == familyComboBox.Items.Count - 1)
			{
				flagComboBox.Enabled = true;
			}
			else
			{
				flagComboBox.Enabled = false;
				flagComboBox.SelectedIndex = 0;
			}
		}

		private void AddTypeButton_Click(object sender, EventArgs e)
		{
			addTypeButton.Enabled = false;

			if (string.IsNullOrWhiteSpace(typeTextBox.Text))
			{
				typeTextBox.Text = string.Empty;
				MessageBox.Show("题型名称不能为空！", "添加失败");
				addTypeButton.Enabled = true;
				return;
			}

			string name = typeTextBox.Text.Trim();
			foreach (ItemType type in typeComboBox.Items)
			{
				if (name.Equals(type.Name))
				{
					typeTextBox.Text = name;
					MessageBox.Show("题型名称已存在！", "添加失败");
					addTypeButton.Enabled = true;
					return;
				}
			}

			ItemType newType = new ItemType()
			{
				Family = familyComboBox.SelectedIndex,
				Flag = flagComboBox.SelectedIndex,
				Name = name
			};
			newType = Services.ItemService.CreateType(newType);
			typeComboBox.Items.Add(newType);
			typeComboBox.SelectedItem = newType;

			typeTextBox.Text = string.Empty;
			addTypeButton.Enabled = true;
		}

		private void AddChapterButton_Click(object sender, EventArgs e)
		{
			addChapterButton.Enabled = false;

			if (string.IsNullOrWhiteSpace(chapterTextBox.Text))
			{
				chapterTextBox.Text = string.Empty;
				MessageBox.Show("章节名称不能为空！", "添加失败");
				addChapterButton.Enabled = true;
				return;
			}
			string name = chapterTextBox.Text.Trim();
			foreach (ItemChapter chapter in chapterComboBox.Items)
			{
				if (name.Equals(chapter.Name))
				{
					chapterTextBox.Text = name;
					MessageBox.Show("章节名称已存在！", "添加失败");
					addChapterButton.Enabled = true;
					return;
				}
			}

			ItemType currentType = (ItemType)this.typeComboBox.SelectedItem;
			ItemChapter newChapter = new ItemChapter()
			{
				TypeId = currentType.Id,
				Name = name
			};
			newChapter = Services.ItemService.CreateChapter(newChapter);
			chapterComboBox.Items.Add(newChapter);
			chapterComboBox.SelectedItem = newChapter;

			chapterTextBox.Text = string.Empty;
			addChapterButton.Enabled = true;
		}

		private void DeleteTypeButton_Click(object sender, EventArgs e)
		{
			deleteTypeButton.Enabled= false;

			int count = chapterComboBox.Items.Count;
			if (count > 0)
			{
				MessageBox.Show("当前题型不为空，存在章节数据，无法删除！", "删除失败");
				deleteTypeButton.Enabled = true;
				return;
			}

			ItemType type = (ItemType)this.typeComboBox.SelectedItem;
			count = Services.ItemService.CountItemsByType(type);
			if (count > 0)
			{
				MessageBox.Show("当前题型不为空，存在试题数据，无法删除！", "删除失败");
				deleteTypeButton.Enabled = true;
				return;
			}

			Services.ItemService.DeleteType(type);
			InitTypeData();
		}

		private void DeleteChapterButton_Click(object sender, EventArgs e)
		{
			deleteChapterButton.Enabled = false;

			ItemChapter chapter = (ItemChapter)chapterComboBox.SelectedItem;
			int count = Services.ItemService.CountItemsByChapter(chapter);
			if (count > 0 )
			{
				MessageBox.Show("当前章节不为空，存在试题数据，无法删除！", "删除失败");
				deleteChapterButton.Enabled = true;
				return;
			}

			Services.ItemService.DeleteChapter(chapter);
			InitChapterData();
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			itemContentForm.Enabled = true;
			this.Close();
		}

		private void TypeChapterManageForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			itemContentForm.RefreshTypeData();
		}
	}
}
