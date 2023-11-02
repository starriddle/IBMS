using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.View
{
	public partial class ItemManageForm : Form
	{

		public MainForm mainForm;
		private int mode;
		private List<List<Label>> labelMatrix;
		private List<Button> buttonList;
		private int pageSize = 10;
		private int totalCount = 0;
		private int totalPages = 0;
		private List<ItemContent> simpleList;
		private List<ItemContent> detailedList;

		public ItemManageForm(MainForm mainForm, int mode)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.mode = mode;
			buttonList = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };
			List<Label> labelColumn1 = new List<Label> { label01, label02, label03, label04, label05, label06, label07, label08, label09, label10 };
			List<Label> labelColumn2 = new List<Label> { label11, label12, label13, label14, label15, label16, label17, label18, label19, label20 };
			List<Label> labelColumn3 = new List<Label> { label21, label22, label23, label24, label25, label26, label27, label28, label29, label30 };
			List<Label> labelColumn4 = new List<Label> { label31, label32, label33, label34, label35, label36, label37, label38, label39, label40 };
			labelMatrix = new List<List<Label>> { labelColumn1, labelColumn2, labelColumn3, labelColumn4 };
		}
		private void ItemManageForm_Load(object sender, EventArgs e)
		{
			bool isPracticeLog = mode == ItemViewMode.PRACTICE;
			this.Text = !isPracticeLog ? "试题管理" : "练习记录";
			createItemButton.Visible = !isPracticeLog;
			labelOrder.Visible = itemOrderComboBox.Visible = labelTitle3.Visible = isPracticeLog;
			labelMatrix[3].ForEach(label => label.Visible = isPracticeLog);

			ClearMatrix();
			totalPageLabel.Text = "/ 页";
			prevButton.Enabled = false;
			nextButton.Enabled = false;
			submitButton.Enabled = false;

			itemOrderComboBox.SelectedIndex = 0;
			// 填充题型列表
			List<ItemType> types = Services.ItemService.GetAllTypes();
			for (int index = 0; index < types.Count; index++)
			{
				itemTypeComboBox.Items.Add(types[index]);
			}
			// 默认选择第一个题型
			 if(types.Count > 0) itemTypeComboBox.SelectedIndex = 0;
		}

		private void ClearMatrix()
		{
			foreach (List<Label> labelList in labelMatrix)
			{
				foreach (Label label in labelList)
				{
					label.Text = string.Empty;
				}
			}
			foreach (Button button in buttonList)
			{
				button.Visible = false;
			}
		}


		private void ItemTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
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
			// 默认选择 第一个选项
			if(chapters.Count > 0) itemChapterComboBox.SelectedIndex = 0;
		}

		private void ItemChapterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			submitButton.Enabled = true;
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			// 禁用确认按钮
			submitButton.Enabled = false;

			// 清空分页组件数据
			pageNumberComboBox.Items.Clear();
			totalPageLabel.Text = "/ 页";
			prevButton.Enabled = false;
			nextButton.Enabled = false;

			// 统计非扩展题和扩展父题的数量
			simpleList = Services.ContentService.GetSimpleContentList((ItemChapter)itemChapterComboBox.SelectedItem, itemOrderComboBox.SelectedIndex);
			totalCount = simpleList.Count;
			// 无试题数据 返回
			if (totalCount == 0)
			{
				ClearMatrix();
				labelMatrix[2][4].Text = "当前条件下没有试题！";
				return;
			}
			// 有数据 渲染分页组件
			totalPages = totalCount / pageSize + (totalCount % pageSize > 0 ? 1 : 0);
			totalPageLabel.Text = string.Format("/ {0} 页", totalPages);
			for (int i = 0; i < totalPages; i++)
			{
				pageNumberComboBox.Items.Add(i + 1);
			}
			// 跳转首页
			pageNumberComboBox.SelectedIndex = 0;
			// 恢复确认按钮
			submitButton.Enabled = true;
		}

		private void PrevButton_Click(object sender, EventArgs e)
		{
			prevButton.Enabled = false;
			pageNumberComboBox.SelectedIndex--;
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			nextButton.Enabled = false;
			pageNumberComboBox.SelectedIndex++;
		}

		private void PageNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int pageIndex = pageNumberComboBox.SelectedIndex;
			FillPage(pageIndex);
			prevButton.Enabled = pageIndex > 0;
			nextButton.Enabled = pageIndex < totalPages - 1;
		}

		private void FillPage(int pageIndex)
		{
			// 清空表格
			ClearMatrix();
			// 查询数据
			int start = pageIndex * pageSize;
			int size = (start + pageSize) > totalCount ? (totalCount - start) : pageSize;
			List<ItemContent> pageList = simpleList.GetRange(start, size);
			detailedList = Services.ContentService.GetDetailedContentList(pageList);
			// 渲染表格 填充数据
			for (int i = 0; i < detailedList.Count; i++)
			{
				Item item = detailedList[i].Item;
				ItemDetail detail = detailedList[i].Detail;
				labelMatrix[0][i].Text = item.Id.ToString();
				labelMatrix[1][i].Text = item.Flag == ItemExtendFlag.PARENT ? item.Number.ToString() : "";
				labelMatrix[2][i].Text = detail.Question.Length > 27 ? detail.Question.Substring(0, 25) + "……" : detail.Question;
				labelMatrix[3][i].Text = item.Correct + "/" + item.Total;
				buttonList[i].Visible = true;
			}
		}

		private void CreateItemButton_Click(object sender, EventArgs e)
		{
			ItemContentForm form = new ItemContentForm(mainForm, this, null, ItemViewMode.CREATE);
			form.Show();
			mainForm.Enabled = false;
		}

		private void ShowItemContentForm(ItemContent detailedContent)
		{
			ItemContentForm form = new ItemContentForm(mainForm, this, detailedContent, mode);
			form.Show();
			mainForm.Enabled = false;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[0]);
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[1]);
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[2]);
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[3]);
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[4]);
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[5]);
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[6]);
		}

		private void Button8_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[7]);
		}

		private void Button9_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[8]);
		}

		private void Button10_Click(object sender, EventArgs e)
		{
			ShowItemContentForm(detailedList[9]);
		}

		internal void RefreshContentList()
		{
			submitButton.PerformClick();
		}
	}
}
