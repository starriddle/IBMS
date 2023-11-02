using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.View
{
	public partial class PracticeSettingForm : Form
	{
		private MainForm mainForm;
		private bool existLastSetting;

		public PracticeSettingForm(MainForm mainForm)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			existLastSetting = mainForm.PracticeSetting != null;
		}

		private void PracticeSettingForm_Load(object sender, EventArgs e)
		{
			// 填充题型列表
			List<ItemType> types = Services.ItemService.GetAllTypes();
			for (int index = 0; index < types.Count; index++)
			{
				itemTypeComboBox.Items.Add(types[index]);
			}
			// 存在上一次的配置信息
			if (existLastSetting)
			{
				// 自动选择上一次的题型
				long typeId = mainForm.PracticeSetting.ItemType.Id;
				for (int index = 0; index < types.Count; index++)
				{
					if (typeId == types[index].Id)
					{
						itemTypeComboBox.SelectedIndex = index;
					}
				}
			}
		}

		private void ItemTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.confirmButton.Enabled = false;
			this.itemChapterComboBox.Items.Clear();
			// 填充章节列表
			ItemType type = (ItemType)this.itemTypeComboBox.SelectedItem;
			List<ItemChapter> chapters = Services.ItemService.GetChaptersByType(type);
			if (chapters.Count > 1)
			{
				chapters.Insert(0, new ItemChapter { Id = 0, TypeId = type.Id, Name = "全部" });
			}
			for (int index = 0; index < chapters.Count; index++)
			{
				itemChapterComboBox.Items.Add(chapters[index]);
			}
			// 默认选择 全部章节
			itemChapterComboBox.SelectedIndex = 0;

			// 如果存在上一次的配置信息
			if (existLastSetting)
			{
				// 每次打开配置界面 仅限自动配置一次
				existLastSetting = false;
				// 自动选择上一次的章节
				long chapterId = mainForm.PracticeSetting.ItemChapter.Id;
				for (int index = 0; index < chapters.Count; index++)
				{
					if (chapterId == chapters[index].Id)
					{
						itemChapterComboBox.SelectedIndex = index;
					}
				}
				// 自动选择上一次的练习顺序
				switch (mainForm.PracticeSetting.PracticeOrder)
				{
					case ItemOrder.ORIGINAL:
						this.radioButtonOriginal.Checked = true;
						break;
					case ItemOrder.TOTAL:
						this.radioButtonTotal.Checked = true;
						break;
					case ItemOrder.CORRECT:
						this.radioButtonCorrect.Checked = true;
						break;
					case ItemOrder.PRECISION:
						this.radioButtonPrecision.Checked = true;
						break;
					default:
						this.radioButtonRandom.Checked = true;
						break;
				}
			}

			confirmButton.Enabled = true;
		}

		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			this.confirmButton.Enabled = false;
			int order = ItemOrder.RANDOM;
			if (this.radioButtonOriginal.Checked) { order = ItemOrder.ORIGINAL; }
			else if (this.radioButtonTotal.Checked) { order = ItemOrder.TOTAL; }
			else if (this.radioButtonCorrect.Checked) { order = ItemOrder.CORRECT; }
			else if (this.radioButtonPrecision.Checked) { order = ItemOrder.PRECISION; }
			mainForm.PracticeSetting = new PracticeSetting
			{
				ItemType = (ItemType)this.itemTypeComboBox.SelectedItem,
				ItemChapter = (ItemChapter)this.itemChapterComboBox.SelectedItem,
				PracticeOrder = order
			};
			PracticeForm form = new PracticeForm(mainForm);
			form.Show();
			this.confirmButton.Enabled = true;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
