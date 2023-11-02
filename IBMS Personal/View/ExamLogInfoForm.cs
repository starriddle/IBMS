using IBMS_Personal.Entity;
using System;
using System.Windows.Forms;

namespace IBMS_Personal.View
{
	public partial class ExamLogInfoForm : Form
	{
		private MainForm mainForm;
		private ExamLog log;

		public ExamLogInfoForm(MainForm mainForm, ExamLog examLog)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			this.log = examLog;
		}

		private void ExamLogInfoForm_Load(object sender, EventArgs e)
		{
			idLabel.Text = log.Id.ToString();
			startTimeLabel.Text = log.StartTime.ToString();
			scoreLabel.Text = log.Score.ToString() + " / " + log.TotalScore.ToString();
			durationLabel.Text = log.Duration.ToString() + " / " + log.TotalTime.ToString();
			structureRichTextBox.Text = log.Structure.ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			mainForm.Enabled = true;
			this.Close();
		}
	}
}
