using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static IBMS_Personal.Entity.Exam;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.View
{
	public partial class ExamForm : Form
	{
		private MainForm mainForm;
		private TimeSpan timerSpan;
		private TimeSpan OneSecond = new TimeSpan(0, 0, 1);
		private Exam exam;
		private ExamModule currentModule;
		private ExamItem currentItem;
		private int currentCount = 0;
		private bool isFinished = false;
		private List<RadioButton> radioButtonOptions;
		private List<CheckBox> checkBoxOptions;

		public ExamForm(MainForm mainForm)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			radioButtonOptions = new List<RadioButton> { radioButtonA, radioButtonB, radioButtonC, radioButtonD, radioButtonE, radioButtonF };
			checkBoxOptions = new List<CheckBox> { checkBoxA, checkBoxB, checkBoxC, checkBoxD, checkBoxE, checkBoxF };
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			timerSpan = timerSpan.Subtract(OneSecond);
			timerLabel.Text = "倒计时 " + timerSpan.ToString();
			if (timerSpan.TotalSeconds <= 0)
			{
				timer.Stop();
				MessageBox.Show("考试时间到，自动交卷！", "考试结束提示");
				FinishExam();
			}
		}

		private void ExamForm_Load(object sender, EventArgs e)
		{
			mainForm.Enabled = false;
			mainForm.Hide();
			this.Text = "模拟考试：" + mainForm.GetSubject().Name;
			ContentRichTextBox.ReadOnly = true;

			submitButton.Enabled = true;
			resultLabel.Visible = false;
			finishLabel.Visible = false;

			try
			{
				exam = Services.ExamService.GetExam(mainForm.ExamSetting);
			}
			catch(Exception ex)
			{
				MessageBox.Show("组卷异常：" + ex.Message,"异常提示");
				this.Close();
			}

			ContentRichTextBox.Text = exam.ToPaperString();
			foreach (var module in exam.Modules)
			{
				moduleComboBox.Items.Add(module);
			}
			countLabel.Text = string.Format("已完成 {0}/{1} 题", currentCount, exam.TotalCount);

			moduleComboBox.SelectedIndex = 0;
			examItemComboBox.SelectedIndex = 0;

			// 开始倒计时
			exam.StartTime = DateTime.Now;
			timerSpan = mainForm.ExamSetting.TotalTime;
			timer.Interval = 1000;
			timer.Enabled = true;
		}

		private void ModuleComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			prevButton.Enabled = false;
			nextButton.Enabled = false;
			examItemComboBox.Items.Clear();
			ExamModule module = (ExamModule)moduleComboBox.SelectedItem;
			foreach (ExamItem item in module.Items)
			{
				if (item.Item.Flag == ItemExtendFlag.UNEXTEND)
				{
					examItemComboBox.Items.Add(item);
					continue;
				}
				foreach (ExamItem child in item.Children)
				{
					examItemComboBox.Items.Add(child);
				}
			}
		}

		private void ExamItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			prevButton.Enabled = examItemComboBox.SelectedIndex != 0 || moduleComboBox.SelectedIndex != 0;
			nextButton.Enabled = examItemComboBox.SelectedIndex != examItemComboBox.Items.Count - 1
								|| moduleComboBox.SelectedIndex != moduleComboBox.Items.Count - 1;

			if (!isFinished) SaveAnswer();

			currentModule = (ExamModule)moduleComboBox.SelectedItem;
			currentItem = (ExamItem)examItemComboBox.SelectedItem;
			InitAnswerGroupBox();
			switch (currentModule.ItemType.Family)
			{
				case ItemTypeFamily.TF:
					radioButtonFalse.Visible = true;
					radioButtonTrue.Visible = true;
					if ("T".Equals(currentItem.Answer)) radioButtonTrue.Checked = true;
					else if ("F".Equals(currentItem.Answer)) radioButtonFalse.Checked = true;
					break;
				case ItemTypeFamily.SC:
					for (int i = 0; i < currentItem.Detail.Number; i++)
					{
						radioButtonOptions[i].Visible = true;
						radioButtonOptions[i].Checked = radioButtonOptions[i].Text.Equals(currentItem.Answer);
						radioButtonOptions[i].BackColor = isFinished && radioButtonOptions[i].Text.Equals(currentItem.Detail.Answer) ? Color.DeepSkyBlue : Color.Transparent;
					}
					break;
				case ItemTypeFamily.MC:
					for (int i = 0; i < currentItem.Detail.Number; i++)
					{
						checkBoxOptions[i].Visible = true;
						checkBoxOptions[i].Checked = currentItem.Answer.Contains(checkBoxOptions[i].Text);
						checkBoxOptions[i].BackColor = isFinished && currentItem.Detail.Answer.Contains(checkBoxOptions[i].Text) ? Color.DeepSkyBlue : Color.Transparent;
					}
					break;
				default:
					answerRichTextBox.Visible = true;
					answerRichTextBox.Text = currentItem.Answer;
					if (isFinished) answerRichTextBox.Text += "\n\n--------\n参考答案：\n"+currentItem.Detail.Answer;
					break;
			}
			if (isFinished)
			{
				if (currentItem.ResultFlag == ExamResultFlag.RIGHT)
				{
					resultLabel.Text = "正确";
					resultLabel.ForeColor = Color.Blue;
				}
				else
				{
					resultLabel.Text = "错误";
					resultLabel.ForeColor = Color.Red;
				}
			}
			resultLabel.Visible = isFinished;
			answerGroupBox.Enabled = !isFinished;
			answerGroupBox.Text = string.Format("第 {0} 题", currentItem.Index);
		}

		private void InitAnswerGroupBox()
		{
			answerGroupBox.Text = string.Empty;

			answerRichTextBox.Visible = false;
			answerRichTextBox.Text = string.Empty;

			radioButtonTrue.Visible = false;
			radioButtonTrue.Checked = false;
			radioButtonFalse.Visible = false;
			radioButtonFalse.Checked = false;

			radioButtonOptions.ForEach(button => { button.Visible = false; button.Checked = false; button.BackColor = Color.Transparent; });

			checkBoxOptions.ForEach(box => { box.Visible = false; box.Checked = false; box.BackColor = Color.Transparent; });

		}

		private void PrevButton_Click(object sender, EventArgs e)
		{
			prevButton.Enabled = false;
			if (examItemComboBox.SelectedIndex == 0)
			{
				moduleComboBox.SelectedIndex--;
				examItemComboBox.SelectedIndex = examItemComboBox.Items.Count - 1;
			}
			else
			{
				examItemComboBox.SelectedIndex--;
			}
		}

		private void NextButton_Click(object sender, EventArgs e)
		{
			nextButton.Enabled = false;
			if (examItemComboBox.SelectedIndex == examItemComboBox.Items.Count - 1)
			{
				moduleComboBox.SelectedIndex++;
				examItemComboBox.SelectedIndex = 0;
			}
			else
			{
				examItemComboBox.SelectedIndex++;
			}
		}

		private void SubmitButton_Click(object sender, EventArgs e)
		{
			FinishExam();
		}

		private void FinishExam()
		{
			timer.Stop();
			submitButton.Enabled = false;
			answerGroupBox.Enabled = false;
			if (!isFinished)
			{
				exam.Duration = mainForm.ExamSetting.TotalTime.Subtract(timerSpan);
				SaveAnswer();
				CheckAnswers();
				finishLabel.Text = exam.TotalScore + " 分";
				finishLabel.Visible = true;
				isFinished = true;

				moduleComboBox.Items.Clear();
				foreach (var module in exam.Modules)
				{
					moduleComboBox.Items.Add(module);
				}
				moduleComboBox.SelectedItem = currentModule;
				examItemComboBox.SelectedItem = currentItem;
			}
			try
			{
				Services.ExamService.AddExamLog(exam, mainForm.ExamSetting);
			}
			catch (Exception ex)
			{
				MessageBox.Show("保存考试记录失败：\n" + ex.Message + "\n\n请尝试重新提交！", "异常提示");
				submitButton.Text = "提交记录";
				submitButton.Enabled = true;
				return;
			}
		}

		/// <summary>
		/// 自动批改待完善，
		/// 目前仅支持客观题
		/// TODO：主观问答题需要逐个询问，由用户自己打分
		/// </summary>
		/// <exception cref="NotImplementedException"></exception>
		private void CheckAnswers()
		{
			int totalScore = 0;
			foreach (ExamModule module in exam.Modules)
			{
				foreach (ExamItem item in module.Items)
				{
					totalScore += CheckAnswer(item, module.Score);
				}
			}
			exam.TotalScore = totalScore;
		}

		private int CheckAnswer(ExamItem item, int score)
		{
			if (item.Item.Flag == ItemExtendFlag.PARENT)
			{
				int totalScore = 0;
				foreach (ExamItem child in item.Children)
				{
					totalScore += CheckAnswer(child, score);
				}
				return totalScore;
			}
			if (string.Equals(item.Answer, item.Detail.Answer))
			{
				item.ResultFlag = ExamResultFlag.RIGHT;
				item.ResultScore = score;
				return score;
			}
			item.ResultFlag = ExamResultFlag.WRONG;
			item.ResultScore = 0;
			return 0;
		}

		private void SaveAnswer()
		{
			if (currentModule == null || currentItem == null) return;

			string currentAnswer = "";
			switch (currentModule.ItemType.Family)
			{
				case ItemTypeFamily.TF:
					if (radioButtonTrue.Checked) currentAnswer = "T";
					else if (radioButtonFalse.Checked) currentAnswer = "F";
					break;
				case ItemTypeFamily.SC:
					for (int i = 0; i < currentItem.Detail.Number; i++)
					{
						if (radioButtonOptions[i].Checked)
						{
							currentAnswer = radioButtonOptions[i].Text;
							break;
						}
					}
					break;
				case ItemTypeFamily.MC:
					for (int i = 0; i < currentItem.Detail.Number; i++)
					{
						if (checkBoxOptions[i].Checked)
						{
							currentAnswer += checkBoxOptions[i].Text;
						}
					}
					break;
				default:
					currentAnswer = answerRichTextBox.Text.Trim();
					break;
			}
			if (!string.Equals(currentAnswer, currentItem.Answer))
			{
				if (currentAnswer.Length == 0) countLabel.Text = string.Format("已完成 {0}/{1} 题", --currentCount, exam.TotalCount);
				if (currentItem.Answer.Length == 0) countLabel.Text = string.Format("已完成 {0}/{1} 题", ++currentCount, exam.TotalCount);
				currentItem.Answer = currentAnswer;
			}
		}

		private void ExamForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!isFinished)
			{
				DialogResult result = MessageBox.Show("模拟考试正在进行中，确定取消考试并退出？",
													  "退出考试提示",
													  MessageBoxButtons.OKCancel,
													  MessageBoxIcon.Exclamation,
													  MessageBoxDefaultButton.Button2);
				if (result == DialogResult.Cancel) e.Cancel = true;
			}
		}

		private void ExamForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			mainForm.Enabled = true;
			mainForm.Show();
		}
	}
}
