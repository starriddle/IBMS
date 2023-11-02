using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.View
{
	public partial class PracticeForm : Form
	{
		private MainForm mainForm;
		private ItemType type;
		private int totalCount; // 总题数
		private int totalIndex; // 当前总题数顺序
		private int index; // 当前大题数顺序
		private int childIndex; // 当前子题数顺序
		private List<ItemContent> simpleList; // 试题简易列表
		private ItemContent currentContent; // 当前大题内容
		private ItemDetail currentDetail; // 当前小题详情
		private bool extendFlag; // 当前是否处于扩展题状态
		private List<RadioButton> radioButtonOptions;
		private List<CheckBox> checkBoxOptions;

		public PracticeForm(MainForm mainForm)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.type = mainForm.PracticeSetting.ItemType;
			radioButtonOptions = new List<RadioButton> { radioButtonA, radioButtonB, radioButtonC, radioButtonD, radioButtonE, radioButtonF };
			checkBoxOptions = new List<CheckBox> { checkBoxA, checkBoxB, checkBoxC, checkBoxD, checkBoxE, checkBoxF };
		}

		private void PracticeForm_Load(object sender, EventArgs e)
		{
			mainForm.Enabled = false;
			mainForm.Hide();
			this.Text = "试题练习：" + mainForm.GetSubject().Name;
			infoLabel.Text = new StringBuilder()
								.Append("题型：").Append(mainForm.PracticeSetting.ItemType.Name)
								.Append(" | 章节：").Append(mainForm.PracticeSetting.ItemChapter.Name)
								.Append(" | 顺序：").Append(ItemOrder.names[mainForm.PracticeSetting.PracticeOrder])
								.ToString();
			indexToolStripStatusLabel.Text = totalIndexToolStripStatusLabel.Text = precisionLabel.Text = string.Empty;
			InitForm();
			simpleList = Services.ContentService.GetSimpleContentListForPractice(mainForm.PracticeSetting);
			if(simpleList.Count == 0)
			{
				contentRichTextBox.Text = "本次练习没有试题数据，请先导入试题数据！";
				return;
			}
			totalCount = totalIndex = index = childIndex = 0;
			for (int i = 0; i < simpleList.Count; i++)
			{
				if (simpleList[index].Item.Flag == ItemExtendFlag.PARENT)
				{
					totalCount += simpleList[i].Item.Number;
				}
				else
				{
					totalCount += 1;
				}
			}
			ShowPracticeItemDetail();
		}

		private void InitForm()
		{
			answerLabel1.Text = string.Empty;
			answerGroupBox.Enabled = true;
			answerRichTextBox1.Visible = false;
			answerRichTextBox1.Text = string.Empty;
			radioButtonTrue.Visible = false;
			radioButtonTrue.Checked = false;
			radioButtonFalse.Visible = false;
			radioButtonFalse.Checked = false;
			radioButtonOptions.ForEach(item => { item.Visible = false; item.Checked = false; });
			checkBoxOptions.ForEach(item => { item.Visible = false; item.Checked = false; });

			answerLabel2.Visible = false;
			answerRichTextBox2.Visible = false;
			answerRichTextBox2.Text = string.Empty;
			resultLabel.Visible = false;

			submitButton.Enabled = false;
			nextButton.Enabled = false;

			totalIndexToolStripStatusLabel.Alignment = ToolStripItemAlignment.Right;
		}

		private void ShowPracticeItemDetail()
		{
			indexToolStripStatusLabel.Text = string.Format("第 {0}/{1} 题", index+1, simpleList.Count);
			totalIndexToolStripStatusLabel.Text = string.Format("总第 {0}/{1} 题", totalIndex+1, totalCount);
			// 仅更新扩展子题时，题目信息不需要更新，只有切换大题(非子题)时，才需要更新
			if (childIndex == 0)
			{
				contentRichTextBox.Clear();
				currentContent = Services.ContentService.GetDetailedContent(simpleList[index], true);
				extendFlag = currentContent.Item.Flag == ItemExtendFlag.PARENT;
				StringBuilder content = currentContent.Detail.ToFormatString();
				for (int i = 0; i < currentContent.Children.Count; i++)
				{
					ItemDetail detail = currentContent.Children[i].Detail;
					content.Append("\n\n第").Append(i+1).Append("小题\n").Append(detail.ToFormatString().ToString());
				}
				contentRichTextBox.Text = content.ToString();
			}

			currentDetail = currentContent.Detail;
			precisionLabel.Text = string.Format("历史答题正确率：{0}/{1}", currentContent.Item.Correct, currentContent.Item.Total);
			if (extendFlag)
			{
				currentDetail = currentContent.Children[childIndex].Detail;
				answerLabel1.Text = string.Format("第 {0} 小题：", childIndex + 1);
				precisionLabel.Text = string.Format("历史答题正确率：{0}/{1}", currentContent.Children[childIndex].Item.Correct, currentContent.Children[childIndex].Item.Total);
			}

			switch (type.Family)
			{
				case ItemTypeFamily.TF:
					radioButtonTrue.Visible = true;
					radioButtonFalse.Visible = true;
					break;
				case ItemTypeFamily.SC:
					for (int i = 0; i < currentDetail.Number; i++)
					{
						radioButtonOptions[i].Visible = true;
					}
					break;
				case ItemTypeFamily.MC:
					for (int i = 0; i < currentDetail.Number; i++)
					{
						checkBoxOptions[i].Visible = true;
					}
					break;
				default:
					answerRichTextBox1.Visible = true;
					break;
			}

			submitButton.Enabled = true;
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			submitButton.Enabled = false;
			// 判断是否已作答
			string answer = GetCurrentAnswer();
			if(string.IsNullOrEmpty(answer))
			{
				MessageBox.Show("当前尚未作答，无法提交");
				submitButton.Enabled = true;
				return;
			}

			// 显示答题结果
			answerGroupBox.Enabled = false;
			string answer2 = currentDetail.Answer;
			answerLabel2.Visible = true;
			answerRichTextBox2.Text = answer2;
			answerRichTextBox2.Visible = true;
			bool result = answer.Equals(answer2);
			resultLabel.Text = result ? "正确" : "错误";
			resultLabel.ForeColor = result ? Color.Blue : Color.Red;
			resultLabel.Visible = true;

			// 保存答题记录
			// 扩展题：只有完成所有子题的作答，才会更新父题的答题记录
			if (extendFlag)
			{
				currentContent.Children[childIndex].Item.Total ++;
				if (result) currentContent.Children[childIndex].Item.Correct++;
				if(childIndex == currentContent.Item.Number - 1)
				{
					currentContent.Item.Total ++;
					int correct = currentContent.Item.Total;
					foreach (ItemContent child in currentContent.Children)
					{
						correct = correct > child.Item.Correct ? child.Item.Correct : correct;
					}
					currentContent.Item.Correct = correct;
				}
			}
			// 非扩展题：直接更新练习记录
			else
			{
				currentContent.Item.Total ++;
				if (result) currentContent.Item.Correct++;
			}
			// 非扩展题：0 > 0 - 1
			// 扩展题全部答完时：childindex = count - 1
			// 保存更新记录到数据库
			if (childIndex >= currentContent.Item.Number - 1)
			{
				try
				{
					Services.ContentService.UpdatePracticeLog(currentContent);
				}
				catch (Exception ex)
				{
					MessageBox.Show("练习记录保存失败：\n" + ex.Message, "异常提示");
					Close();
				}
			}

			if(totalIndex < totalCount - 1) nextButton.Enabled = true;
		}

		private string GetCurrentAnswer()
		{
			string answer = "";
			switch (type.Family)
			{
				case ItemTypeFamily.EQ:
					if(!string.IsNullOrWhiteSpace(answerRichTextBox1.Text)) answer = answerRichTextBox1.Text.Trim();
					break;
				case ItemTypeFamily.TF:
					if (radioButtonTrue.Checked) answer = "T";
					else if (radioButtonFalse.Checked) answer = "F";
					break;
				case ItemTypeFamily.SC:
					for (int i = 0; i < currentDetail.Number; i++)
					{
						if (radioButtonOptions[i].Checked)
						{
							answer = radioButtonOptions[i].Text;
							break;
						}
					}
					break;
				case ItemTypeFamily.MC:
					for (int i = 0; i < currentDetail.Number; i++)
					{
						if (checkBoxOptions[i].Checked)
						{
							answer += checkBoxOptions[i].Text;
						}
					}
					break;
				default:
					break;
			}
			return answer;
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			nextButton.Enabled = false;

			// 扩展题 还有子题还未作答
			if (extendFlag && childIndex < currentContent.Children.Count - 1)
			{
				childIndex++;
				totalIndex++;
			}
			// 非扩展题 或 扩展题所有子题已全部作答完毕
			else
			{
				index++;
				childIndex = 0;
				totalIndex++;
			}
			InitForm();
			ShowPracticeItemDetail();
		}

		private void PracticeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(totalCount == 0)
			{
				return;
			}
			// 练习扩展题时，关闭练习窗口，需要特别注意
			if (currentContent.Item.Flag == ItemExtendFlag.PARENT)
			{
				// 当前子题未作答 && 第一个子题完成作答
				// 当前子题已作答 && 最后的子题尚未作答
				// =>只有部分子题完成作答，练习记录不保存
				// 只有所有子题全部完成作答，才会统一保存父题和所有子题的练习记录
				if(submitButton.Enabled && childIndex > 0
					|| !submitButton.Enabled && childIndex < currentContent.Children.Count - 1)
				{
					DialogResult result = MessageBox.Show("当前大题拥有多个子题，尚未全部完成作答，此时退出将丢失已作答子题的练习记录\n\n是否确认退出？",
															"中止练习提示",
															MessageBoxButtons.OKCancel,
															MessageBoxIcon.Warning,
															MessageBoxDefaultButton.Button2);
					if(result == DialogResult.Cancel)
					{
						e.Cancel = true;
					}
				}
			}
			// 尚未完成全部试题的练习
			if(submitButton.Enabled || totalIndex < totalCount-1)
			{
				DialogResult result = MessageBox.Show("试题练习尚未全部完成\n\n是否确认退出？",
														"中止练习提示",
														MessageBoxButtons.OKCancel,
														MessageBoxIcon.Warning,
														MessageBoxDefaultButton.Button2);
				if (result == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
		}

		private void PracticeForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			mainForm.Enabled = true;
			mainForm.Show();
		}
	}
}
