using IBMS_Personal.Entity;
using IBMS_Personal.Service;
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
		private bool editable;
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
			precisionLabel.Text = string.Empty;
			childGroupBox.Text = string.Empty;
			questionGroupBox.Visible = answerRichTextBox.Visible = false;
			radioButtonTrue.Visible = radioButtonFalse.Visible = false;
			radioButtonOptions.ForEach(button => button.Visible = false);
			checkBoxOptions.ForEach(box => box.Visible = false);
			textBoxOptions.ForEach(box => box.Visible = false);
			FillItemTypeComboBox();
			if (mode == ItemViewMode.CREATE)
			{
				prevButton.Visible = nextButton.Visible = addButton.Visible = removeButton.Visible = false;
				questionMainRichTextBox.Enabled = false;
				extendCheckBox.Enabled = false;
				childGroupBox.Enabled = false;
			}
			else
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
				FillItemDetail();
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
			editable = mode == ItemViewMode.CREATE || mode == ItemViewMode.UPDATE;

			// 编辑模式：显示提交和取消按钮
			submitButton.Visible = cancelButton.Visible = editable;

			// 编辑模式：试题内容可编辑
			questionMainRichTextBox.ReadOnly = questionChildRichTextBox.ReadOnly = answerRichTextBox.ReadOnly = !editable;
			radioButtonTrue.Enabled = radioButtonFalse.Enabled = editable;
			radioButtonOptions.ForEach(button => button.Enabled = editable);
			checkBoxOptions.ForEach(box => box.Enabled = editable);
			textBoxOptions.ForEach(box => box.ReadOnly = !editable);
		}

		/// <summary>
		/// 填充题型列表
		/// </summary>
		private void FillItemTypeComboBox()
		{
			if(mode == ItemViewMode.CREATE)
			{
				questionMainRichTextBox.Enabled = false;
				extendCheckBox.Enabled = false;
				childGroupBox.Enabled = false;
			}
			this.itemTypeComboBox.Items.Clear();
			List<ItemType> types = Services.ItemService.GetAllTypes();
			for (int index = 0; index < types.Count; index++)
			{
				itemTypeComboBox.Items.Add(types[index]);
			}
		}

		/// <summary>
		/// 题型列表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (mode == ItemViewMode.CREATE)
			{
				questionMainRichTextBox.Enabled = false;
				extendCheckBox.Enabled = false;
				childGroupBox.Enabled = false;
			}
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

		/// <summary>
		/// 章节列表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void itemChapterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// 非新建模式，只可能在查看模式窗口载入时触发，此时忽略该事件
			if (mode != ItemViewMode.CREATE) return;
			// 新建模式，切换章节，更新新试题的题型、章节信息，在窗口载入时根据题型显示对应组件
			long typeId = ((ItemType)itemTypeComboBox.SelectedItem).Id;
			if (newContent == null || newContent.Item.TypeId != typeId)
			{
				newContent = new ItemContent(new Item(), new ItemDetail());
				if (extendCheckBox.Checked)
				{
					newContent.AddChild(new ItemContent(new Item(), new ItemDetail()))
						.AddChild(new ItemContent(new Item(), new ItemDetail()));
					newContent.Item.Number = 2;
					childIndex = 0;
				}
			}
			else
			{
				if (extendCheckBox.Checked)
				{
					UpdateDetailFromChildGroupBox(newContent.Children[childIndex].Detail);
					newContent.Detail.Question = questionMainRichTextBox.Text.Trim();
				}
				else
				{
					UpdateDetailFromChildGroupBox(newContent.Detail);
					newContent.Detail.Question = questionMainRichTextBox.Text.Trim();
				}
			}
			newContent.Item.TypeId = typeId;
			newContent.Item.ChapterId = ((ItemChapter)itemChapterComboBox.SelectedItem).Id;
			newContent.Item.Flag = extendCheckBox.Checked ? ItemExtendFlag.PARENT : ItemExtendFlag.UNEXTEND;
			if (extendCheckBox.Checked)
			{
				foreach (ItemContent child in newContent.Children)
				{
					child.Item.TypeId = newContent.Item.TypeId;
					child.Item.ChapterId = newContent.Item.ChapterId;
					child.Item.Flag = ItemExtendFlag.CHILD;
				}
			}
			FillChildGroupBox();
			questionMainRichTextBox.Enabled = true;
			extendCheckBox.Enabled = true;
			childGroupBox.Enabled = true;
		}

		private void ExtendCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			// 非新建模式，只可能在查看模式窗口载入时触发，此时忽略该事件
			if (mode != ItemViewMode.CREATE) return;
			// 新建模式，切换扩展标记时，保存父题(非扩展题)和子题所有内容，最后保存时才会根据扩展标记删除不需要的内容
			// 非扩展题切换为扩展试题，显示第1个子题内容
			childIndex = 0;
			if (extendCheckBox.Checked)
			{
				newContent.Detail.Question = questionMainRichTextBox.Text.Trim();
				newContent.Detail.Answer = null;
				newContent.Detail.Number = 0;
				newContent.Detail.Options.Clear();

				newContent.Item.Flag = ItemExtendFlag.PARENT;
				newContent.Item.Number = 2;
				newContent.AddChild(new ItemContent(new Item()
				{
					TypeId = newContent.Item.TypeId,
					ChapterId = newContent.Item.ChapterId,
					Flag = ItemExtendFlag.CHILD,
					ParentId = newContent.Item.Id,
				}, new ItemDetail()
				{
					ParentId = newContent.Item.Id
				})).AddChild(new ItemContent(new Item()
				{
					TypeId = newContent.Item.TypeId,
					ChapterId = newContent.Item.ChapterId,
					Flag = ItemExtendFlag.CHILD,
					ParentId = newContent.Item.Id,
				}, new ItemDetail()
				{
					ParentId = newContent.Item.Id
				}));
				UpdateDetailFromChildGroupBox(newContent.Children[childIndex].Detail);
			}
			// 扩展题切换为非扩展试题，显示试题内容
			else
			{
				childIndex = 0;
				UpdateDetailFromChildGroupBox(newContent.Detail);
				newContent.Detail.Question = questionMainRichTextBox.Text.Trim();
				newContent.Item.Flag = ItemExtendFlag.UNEXTEND;
				newContent.Item.Number = 0;
				newContent.Children.Clear();
			}
			FillChildGroupBox();
		}

		// 填充答案信息
		private void FillItemDetail()
		{
			ItemContent currentContent = editable ? newContent : content;
			questionMainRichTextBox.Text = currentContent.Detail.Question;

			if (mode == ItemViewMode.PRACTICE)
			{
				precisionLabel.Text = "答题准确率：" + currentContent.Item.Correct + "/" + currentContent.Item.Total;
			}

			if (currentContent.Item.Flag == ItemExtendFlag.PARENT)
			{
				extendCheckBox.Checked = true;
			}
			FillChildGroupBox();
		}

		// 填充答案信息
		private void FillChildGroupBox()
		{
			questionGroupBox.Visible = answerRichTextBox.Visible = false;
			questionChildRichTextBox.Text = answerRichTextBox.Text = string.Empty;
			radioButtonTrue.Visible = radioButtonFalse.Visible = false;
			radioButtonTrue.Checked = radioButtonFalse.Checked = false;
			radioButtonOptions.ForEach(button =>
			{
				button.Visible = false;
				button.Checked = false;
			});
			checkBoxOptions.ForEach(box =>
			{
				box.Visible = false;
				box.Checked = false;
			});
			textBoxOptions.ForEach(box =>
			{
				box.Visible = false;
				box.Text = string.Empty;
			});

			ItemContent currentContent = editable ? newContent : content;

			ItemDetail detail;

			if (extendCheckBox.Checked)
			{
				childGroupBox.Text = "第 " + (childIndex + 1) + " 题";
				if (mode == ItemViewMode.PRACTICE)
				{
					childGroupBox.Text += "  答题准确率：" + currentContent.Children[childIndex].Item.Correct + "/" + currentContent.Children[childIndex].Item.Total;
				}
				detail = currentContent.Children[childIndex].Detail;
				questionGroupBox.Visible = true;
				questionChildRichTextBox.Text = detail.Question;
				prevButton.Visible = childIndex > 0;
				nextButton.Visible = childIndex < currentContent.Item.Number - 1;
				removeButton.Visible = addButton.Visible = editable;
			}
			else
			{
				childGroupBox.Text = string.Empty;
				detail = currentContent.Detail;
				questionGroupBox.Visible = false;
				prevButton.Visible = nextButton.Visible = addButton.Visible = removeButton.Visible = false;
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
					if (editable)
					{
						for (int i = detail.Options.Count; i < textBoxOptions.Count; i++)
						{
							textBoxOptions[i].Text = string.Empty;
							textBoxOptions[i].Visible = true;
							radioButtonOptions[i].Visible = true;
						}
					}
					if (!string.IsNullOrEmpty(detail.Answer)) radioButtonOptions[detail.Answer.ElementAt(0) - 'A'].Checked = true;
					break;
				case ItemTypeFamily.MC:
					for (int i = 0; i < detail.Options.Count; i++)
					{
						textBoxOptions[i].Text = detail.Options[i];
						textBoxOptions[i].Visible = true;
						checkBoxOptions[i].Visible = true;
					}
					if (editable)
					{
						for (int i = detail.Options.Count; i < textBoxOptions.Count; i++)
						{
							textBoxOptions[i].Text = string.Empty;
							textBoxOptions[i].Visible = true;
							checkBoxOptions[i].Visible = true;
						}
					}
					if (!string.IsNullOrEmpty(detail.Answer)) detail.Answer.ToList().ForEach(c => checkBoxOptions[c - 'A'].Checked = true);
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
		/// 从界面获取试题详情
		/// </summary>
		/// <param name="detail"></param>
		/// <exception cref="NotImplementedException"></exception>
		private void UpdateDetailFromChildGroupBox(ItemDetail detail)
		{
			string question = questionChildRichTextBox.Text;
			detail.Question = string.IsNullOrWhiteSpace(question) ? string.Empty : question.Trim();
			
			ItemType type = (ItemType)itemTypeComboBox.SelectedItem;
			detail.Answer = string.Empty;
			detail.Options.Clear();
			switch (type.Family)
			{
				case ItemTypeFamily.TF:
					if(radioButtonTrue.Checked) detail.Answer = "T";
					else if (radioButtonFalse.Checked) detail.Answer = "F";
					break;
				case ItemTypeFamily.SC:
					detail.Options.Clear();
					for (int i = 0; i < textBoxOptions.Count; i++)
					{
						string option = textBoxOptions[i].Text;
						if (string.IsNullOrEmpty(option)) break;
						detail.AddOption(option.Trim());
						if (radioButtonOptions[i].Checked) detail.Answer = radioButtonOptions[i].Text;
					}
					break;
				case ItemTypeFamily.MC:
					detail.Options.Clear();
					for (int i = 0; i < textBoxOptions.Count; i++)
					{
						string option = textBoxOptions[i].Text;
						if (string.IsNullOrEmpty(option)) break;
						detail.AddOption(option.Trim());
						if (checkBoxOptions[i].Checked) detail.Answer += checkBoxOptions[i].Text;
					}
					break;
				case ItemTypeFamily.EQ:
					string answer = answerRichTextBox.Text;
					if (string.IsNullOrEmpty(answer)) break;
					detail.Answer = answer.Trim();
					break;
				default:
					break;
			}
			detail.Number = detail.Options.Count;
		}

		/// <summary>
		/// 扩展子题，上一题
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PrevButton_Click(object sender, EventArgs e)
		{
			// 编辑模式下 暂存当前子题（新建、更新模式）
			if (editable)
			{
				ItemDetail detail = newContent.Children[childIndex].Detail;
				UpdateDetailFromChildGroupBox(detail);
			}
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
			// 编辑模式下 暂存当前子题（新建、更新模式）
			if (editable)
			{
				ItemDetail detail = newContent.Children[childIndex].Detail;
				UpdateDetailFromChildGroupBox(detail);
			}
			childIndex++;
			FillChildGroupBox();
		}

		/// <summary>
		/// 在子题列表追加新子题
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddButton_Click(object sender, EventArgs e)
		{
			addButton.Enabled = false;
			// 暂存当前子题
			ItemDetail detail = newContent.Children[childIndex].Detail;
			UpdateDetailFromChildGroupBox(detail);
			// 新建子题
			newContent.AddChild( new ItemContent(new Item()
			{
				TypeId = newContent.Item.TypeId,
				ChapterId = newContent.Item.ChapterId,
				Flag = ItemExtendFlag.CHILD,
				ParentId = newContent.Item.Id,
			}, new ItemDetail()
			{
				ParentId = newContent.Item.Id
			}));
			newContent.Item.Number++;
			// 切换到新子题
			childIndex = newContent.Item.Number - 1;
			FillChildGroupBox();
			addButton.Enabled = true;
		}

		/// <summary>
		/// 移除子题，自动显示后一个或最后一个子题内容
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RemoveButton_Click(object sender, EventArgs e)
		{
			removeButton.Enabled = false;
			// 扩展题最少保留2个子题
			if (newContent.Children.Count <= 2)
			{
				MessageBox.Show("扩展题子题数量不得少于 2 个！", "错误提示");
				removeButton.Enabled = true;
				return;
			}
			// 移除子题
			newContent.Children.RemoveAt(childIndex);
			newContent.Item.Number--;
			// 切换到下一题，或最后一个子题
			if (childIndex == newContent.Item.Number)
			{
				childIndex--;
			}
			FillChildGroupBox();
			removeButton.Enabled = true;
		}

		// 由详情查看模式至更新模式
		private void EditButton_Click(object sender, EventArgs e)
		{
			editButton.Enabled = false;
			newContent = content.FullyCopy();
			mode = ItemViewMode.UPDATE;
			SwitchMode();
			FillItemDetail();
			editButton.Enabled = true;
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			submitButton.Enabled = false;
			// TODO 暂存当前子题/试题，完善试题内容
			if (extendCheckBox.Checked)
			{
				UpdateDetailFromChildGroupBox(newContent.Children[childIndex].Detail);
				newContent.Detail.Question = questionMainRichTextBox.Text.Trim();
			}
			else
			{
				UpdateDetailFromChildGroupBox(newContent.Detail);
				newContent.Detail.Question = questionMainRichTextBox.Text.Trim();
			}
			if (mode == ItemViewMode.CREATE)
			{
				try
				{
					content = Services.ContentService.CreateContent(newContent);
				}
				catch (Exception ex)
				{
					MessageBox.Show("试题创建出现错误：\n" + ex.Message, "异常提示");
					submitButton.Enabled = true;
					return;
				}
				MessageBox.Show("创建成功");
			}
			else if (mode == ItemViewMode.UPDATE)
			{
				try
				{
					content = Services.ContentService.UpdateContent(newContent);
				}
				catch (Exception ex)
				{
					MessageBox.Show("试题更新出现错误：\n" + ex.Message, "异常提示");
					submitButton.Enabled = true;
					return;
				}
				MessageBox.Show("更新成功");
			}
			newContent = null;
			mode = ItemViewMode.DETAIL;
			SwitchMode();
			FillItemDetail();
			submitButton.Enabled = true;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			if (mode == ItemViewMode.UPDATE)
			{
				newContent = null;
				if (childIndex >= content.Item.Number) childIndex = content.Item.Number - 1;
				mode = ItemViewMode.DETAIL;
				SwitchMode();
				FillItemDetail();
			}
			else if (mode == ItemViewMode.CREATE)
			{
				this.Close();
			}
		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			deleteButton.Enabled = false;
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
			this.Close();
		}

		private void ItemChapterButton_Click(object sender, EventArgs e)
		{
			TypeChapterManageForm form = new TypeChapterManageForm(this);
			form.Show();
			this.Enabled = false;
		}

		private void ItemContentForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (mode == ItemViewMode.UPDATE || mode == ItemViewMode.CREATE)
			{
				DialogResult result = MessageBox.Show("试题正在编辑，确定取消编辑并退出？",
													  "退出编辑提示",
													  MessageBoxButtons.OKCancel,
													  MessageBoxIcon.Exclamation,
													  MessageBoxDefaultButton.Button2);
				if (result == DialogResult.Cancel) e.Cancel = true;
			}
		}

		private void ItemContentForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			mainForm.Enabled = true;
		}

		internal void RefreshTypeData()
		{
			long typeId = 0, chapterId = 0;
			if (itemTypeComboBox.SelectedIndex >= 0)
			{
				typeId = ((ItemType)itemTypeComboBox.SelectedItem).Id;
			}

			if (itemChapterComboBox.SelectedIndex >= 0)
			{
				chapterId = ((ItemChapter)itemChapterComboBox.SelectedItem).Id;
			}
			FillItemTypeComboBox();
			foreach (ItemType type in itemTypeComboBox.Items)
			{
				if (type.Id == typeId)
				{
					itemTypeComboBox.SelectedItem = type;
					break;
				}
			}
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
}
