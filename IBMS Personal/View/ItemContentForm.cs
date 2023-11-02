using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.View
{
	public partial class ItemContentForm : Form
	{

		private MainForm mainForm;
		private ItemManageForm itemManageForm;
		private ItemContent content;
		private int mode;
		private List<RadioButton> radioButtonOptions;
		private List<CheckBox> checkBoxOptions;
		private List<TextBox> textBoxOptions;
		private ItemContent newContent;
		private int childIndex;

		public ItemContentForm(MainForm mainForm, ItemManageForm itemManageForm, ItemContent content, int mode)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.itemManageForm = itemManageForm;
			this.content = content;
			this.mode = mode;
			radioButtonOptions = new List<RadioButton> { radioButtonA, radioButtonB, radioButtonC, radioButtonD, radioButtonE, radioButtonF };
			checkBoxOptions = new List<CheckBox> { checkBoxA, checkBoxB, checkBoxC, checkBoxD, checkBoxE, checkBoxF };
			textBoxOptions = new List<TextBox> { textBoxA, textBoxB, textBoxC, textBoxD, textBoxE, textBoxF };
		}

		private void ItemContentForm_Load(object sender, EventArgs e)
		{
			SwitchMode();
			FillItemTypeComboBox();
			if (mode != ItemViewMode.CREATE)
			{
				long typeId = content.Item.TypeId;
				foreach (ItemType type in itemTypeComboBox.Items)
				{
					if (type.Id == typeId)
					{
						itemTypeComboBox.SelectedItem = type;
						break;
					}
				}
				questionMainRichTextBox.Text = content.Detail.Question;

				if (content.Item.Flag == ItemExtendFlag.PARENT)
				{
					extendCheckBox.Checked = true;
				}
				else
				{
					FillChildGroupBox(0);
				}
			}
		}

		/// <summary>
		/// 根据模式调整窗口组件
		/// </summary>
		private void SwitchMode()
		{
			this.Text = ItemViewMode.titles[mode] + " " + mainForm.GetSubject().Name;

			// 新建试题：题型、章节、扩展标记 可编辑
			manageTypeChapterButton.Visible = itemTypeComboBox.Enabled = itemChapterComboBox.Enabled = extendCheckBox.Enabled = mode == ItemViewMode.CREATE;

			// 试题查看：显示删除和编辑按钮
			deleteButton.Visible = editButton.Visible = mode == ItemViewMode.DETAIL;

			// 编辑模式 = 新建/更新
			bool editable = mode == ItemViewMode.CREATE || mode == ItemViewMode.UPDATE;

			// 非编辑模式：显示关闭按钮
			closeButton.Visible = !editable;
			// 编辑模式：显示提交和取消按钮
			submitButton.Visible = cancelButton.Visible = editable;

			// 编辑模式：试题内容可编辑
			questionMainRichTextBox.ReadOnly = questionChildRichTextBox.ReadOnly = answerRichTextBox.ReadOnly = !editable;
			textBoxOptions.ForEach(box => box.ReadOnly = !editable);
			radioButtonTrue.Enabled = radioButtonFalse.Enabled = editable;
			radioButtonOptions.ForEach(button => button.Enabled = editable);
			checkBoxOptions.ForEach(box => box.Enabled = editable);
		}

		private void ItemTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillItemChapterComboBox();
			if (mode != ItemViewMode.CREATE)
			{
				long chapterId = content.Item.ChapterId;
				foreach (ItemChapter chapter in itemChapterComboBox.Items)
				{
					if (chapter.Id == chapterId)
					{
						itemChapterComboBox.SelectedItem = chapter;
						break;
					}
				}
			}
		}

		/// <summary>
		/// 填充题型列表
		/// </summary>
		private void FillItemTypeComboBox()
		{
			this.itemTypeComboBox.Items.Clear();
			List<ItemType> types = Services.ItemService.GetAllTypes();
			for (int index = 0; index < types.Count; index++)
			{
				itemTypeComboBox.Items.Add(types[index]);
			}
		}

		/// <summary>
		/// 填充章节列表
		/// </summary>
		private void FillItemChapterComboBox()
		{
			this.itemChapterComboBox.Items.Clear();
			ItemType type = (ItemType)this.itemTypeComboBox.SelectedItem;
			List<ItemChapter> chapters = Services.ItemService.GetChaptersByType(type);
			for (int index = 0; index < chapters.Count; index++)
			{
				itemChapterComboBox.Items.Add(chapters[index]);
			}
		}

		private void ExtendCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			// 非新建模式，只可能在查看模式窗口载入时触发，此时忽略该事件
			if (mode != ItemViewMode.CREATE) return;
			// 新建模式，切换扩展标记时，保存父题(非扩展题)和子题所有内容，最后保存时才会根据扩展标记删除不需要的内容
			// 切换为扩展试题，显示第1个子题内容
			// 切换为非扩展试题，显示试题内容
			// TODO 保存当前信息
			childIndex = 0;
            FillChildGroupBox();
        }

		// 填充答案信息
		private void FillChildGroupBox(int index)
		{
			childIndex = index;
			ItemDetail detail;

			if (mode == ItemViewMode.PRACTICE)
			{
				childGroupBox.Text = "答题准确率：" + content.Item.Correct + "/" + content.Item.Total;
			}
			if (extendCheckBox.Checked)
			{
				childGroupBox.Text = "第 " + (childIndex + 1) + " 题";
				if (mode == ItemViewMode.PRACTICE)
				{
					childGroupBox.Text += "  答题准确率：" + content.Item.Correct + "/" + content.Item.Total;
				}
				detail = content.Children[childIndex].Detail;
				prevButton.Visible = moveUpButton.Visible = childIndex == 0;
				nextButton.Visible = moveDownButton.Visible = childIndex == content.Item.Number - 1;
			}
			else
			{
				questionGroupBox.Visible = false;
				detail = content.Detail;
				prevButton.Visible = nextButton.Visible = moveUpButton.Visible = moveDownButton.Visible = addButton.Visible = removeButton.Visible = false;
			}
			ItemType type = (ItemType)itemTypeComboBox.SelectedItem;
			switch (type.Family)
			{
				case ItemTypeFamily.TF:
					radioButtonTrue.Visible = radioButtonFalse.Visible = true;
					if("T".Equals(detail.Answer)) radioButtonTrue.Checked = true;
					else if ("F".Equals(detail.Answer)) radioButtonFalse.Checked = true;
					break;
				case ItemTypeFamily.SC:
					for (int i = 0; i < detail.Options.Count; i++)
					{
						textBoxOptions[i].Text = detail.Options[i];
						textBoxOptions[i].Visible = true;
						radioButtonOptions[i].Visible = true;
					}
					radioButtonOptions[detail.Answer.ElementAt(0) - 'A'].Checked = true;
					break;
				case ItemTypeFamily.MC:
					for (int i = 0; i < detail.Options.Count; i++)
					{
						textBoxOptions[i].Text = detail.Options[i];
						textBoxOptions[i].Visible = true;
						checkBoxOptions[i].Visible = true;
					}
					detail.Answer.ToList().ForEach(c => checkBoxOptions[c - 'A'].Checked = true);
					break;
				case ItemTypeFamily.EQ:
					answerRichTextBox.Text = detail.Answer;
					answerRichTextBox.Visible = true;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 扩展子题，上一题
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PrevButton_Click(object sender, EventArgs e)
		{
			// TODO 暂存当前子题（新建、更新模式）
			childIndex--;
			FillChildGroupBox();
		}

		/// <summary>
		/// 扩展子题，下一题
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NextButton_Click(object sender, EventArgs e)
		{
			// TODO 暂存当前子题（新建、更新模式）
			childIndex++;
			FillChildGroupBox();
		}

		private void MoveUpButton_Click(object sender, EventArgs e)
		{
			ItemContent temp = newContent.Children[childIndex];
			newContent.Children.RemoveAt(childIndex);
			newContent.Children.Insert(--childIndex, temp);
			childGroupBox.Text = "第 " + (childIndex + 1) + "/" + newContent.Item.Number + " 题";
		}

		private void MoveDownButton_Click(object sender, EventArgs e)
		{
			ItemContent temp = newContent.Children[childIndex];
			newContent.Children.RemoveAt(childIndex);
			newContent.Children.Insert(++childIndex, temp);
			childGroupBox.Text = "第 " + (childIndex + 1) + "/" + (newContent.Item.Number) + " 题";
		}

		/// <summary>
		/// 添加子题，顺序在当前子题前面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddButton_Click(object sender, EventArgs e)
		{
			// TODO 暂存当前子题
			newContent.Children.Insert(childIndex, new ItemContent(new Item()
			{
				TypeId = newContent.Item.TypeId,
				ChapterId = newContent.Item.ChapterId,
				Flag = ItemExtendFlag.CHILD
			}, new ItemDetail()));
			FillChildGroupBox();
		}

		/// <summary>
		/// 移除子题，自动显示后一个或最后一个子题内容
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RemoveButton_Click(object sender, EventArgs e)
		{
			if (newContent.Children.Count <= 2)
			{
				MessageBox.Show("扩展题子题数量不得少于 2 个！", "错误提示");
				return;
			}
			newContent.Children.RemoveAt(childIndex);
			newContent.Item.Number--;
			if (childIndex == newContent.Item.Number)
			{
				childIndex--;
			}
			FillChildGroupBox();
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			mode = ItemViewMode.UPDATE;
			SwitchMode();
            if (content.Item.Flag == ItemExtendFlag.PARENT)
            {
				removeButton.Visible = addButton.Visible = true;
				moveUpButton.Visible = childIndex > 0;
				moveDownButton.Visible = childIndex < content.Item.Number - 1;
            }
        }

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			// TODO 暂存当前子题/试题，完善试题内容
			if (mode == ItemViewMode.CREATE)
			{
				try
				{
					Services.ContentService.CreateContent(newContent);
				}
				catch (Exception ex)
				{
					MessageBox.Show("试题创建出现错误：\n" + ex.Message, "异常提示");
					return;
				}
				MessageBox.Show("创建成功");
			}
			else if (mode == ItemViewMode.UPDATE)
			{
				try
				{
					Services.ContentService.UpdateContent(newContent);
				}
				catch (Exception ex)
				{
					MessageBox.Show("试题更新出现错误：\n" + ex.Message, "异常提示");
					return;
				}
				MessageBox.Show("更新成功");
			}
			content = newContent;
			newContent = null;
			mode = ItemViewMode.DETAIL;
			SwitchMode();
			removeButton.Visible = addButton.Visible = moveUpButton.Visible = moveDownButton.Visible = false;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			if (mode == ItemViewMode.UPDATE)
			{
				newContent = null;
				mode = ItemViewMode.DETAIL;
				SwitchMode();
				FillItemDetail();
			}
			else if (mode == ItemViewMode.CREATE)
			{
				mainForm.Enabled = true;
				this.Close();
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			try
			{
				Services.ContentService.DeleteContent(content);
			}
			catch (Exception ex)
			{
				MessageBox.Show("试题删除失败！\n错误信息：\n" + ex.Message, "异常提示");
				return;
			}
			MessageBox.Show("删除成功");
			mainForm.Enabled = true;
			this.Close();
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			mainForm.Enabled = true;
			this.Close();
		}

		private void ItemChapterButton_Click(object sender, EventArgs e)
		{
			TypeChapterManageForm form = new TypeChapterManageForm(this);
			form.Show();
			this.Enabled = false;
		}

		internal void RefreshTypeData()
		{
			throw new NotImplementedException();
		}
	}
}
