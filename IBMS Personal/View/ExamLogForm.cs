using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IBMS_Personal.View
{
	public partial class ExamLogForm : Form
	{
		private MainForm mainForm;
		private List<List<Label>> labelMatrix;
		private List<Button> buttonList;
		private int pageSize = 10;
		private int totalCount = 0;
		private int totalPages = 0;
		private List<ExamLog> logs;

		public ExamLogForm(MainForm mainForm)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			buttonList = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };
			List<Label> labelColumn1 = new List<Label> { label01, label02, label03, label04, label05, label06, label07, label08, label09, label10 };
			List<Label> labelColumn2 = new List<Label> { label11, label12, label13, label14, label15, label16, label17, label18, label19, label20 };
			List<Label> labelColumn3 = new List<Label> { label21, label22, label23, label24, label25, label26, label27, label28, label29, label30 };
			List<Label> labelColumn4 = new List<Label> { label31, label32, label33, label34, label35, label36, label37, label38, label39, label40 };
			labelMatrix = new List<List<Label>> { labelColumn1, labelColumn2, labelColumn3, labelColumn4 };
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

		private void ExamLogForm_Load(object sender, EventArgs e)
		{
			ClearMatrix();
			prevButton.Enabled = false;
			nextButton.Enabled = false;

			totalCount = Services.ExamService.CountLogs();
			totalPages = totalCount / pageSize + (totalCount % pageSize > 0 ? 1 : 0);
			totalPageLabel.Text = string.Format("/ {0} 页", totalPages);
			for (int i = 0; i < totalPages; i++)
			{
				pageNumberComboBox.Items.Add(i + 1);
			}
			if (totalPages > 0) pageNumberComboBox.SelectedIndex = 0;
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
			ListPage(pageIndex);
			prevButton.Enabled = pageIndex > 0;
			nextButton.Enabled = pageIndex < totalPages - 1;
		}

		private void ListPage(int pageIndex)
		{
			ClearMatrix();
			logs = Services.ExamService.GetExamLogsByPage(pageIndex, pageSize);
			for (int i = 0; i < logs.Count; i++)
			{
				labelMatrix[0][i].Text = logs[i].Id.ToString();
				labelMatrix[1][i].Text = logs[i].StartTime.ToString();
				labelMatrix[2][i].Text = logs[i].Duration.ToString() + "/" + logs[i].TotalTime.ToString();
				labelMatrix[3][i].Text = logs[i].Score.ToString()+" / " + logs[i].TotalScore.ToString();
				buttonList[i].Visible = true;
			}
		}

		private void ShowExamLogInfo(ExamLog examLog)
		{
			ExamLogInfoForm form = new ExamLogInfoForm(mainForm, examLog);
			form.Show();
			mainForm.Enabled = false;
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[0]);
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[1]);
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[2]);
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[3]);
		}

		private void Button5_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[4]);
		}

		private void Button6_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[5]);
		}

		private void Button7_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[6]);
		}

		private void Button8_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[7]);
		}

		private void Button9_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[8]);
		}

		private void Button10_Click(object sender, EventArgs e)
		{
			ShowExamLogInfo(logs[9]);
		}
	}
}
