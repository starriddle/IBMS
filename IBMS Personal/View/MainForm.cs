using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using IBMS_Personal.Util;
using System;
using System.Windows.Forms;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.View
{
	public partial class MainForm : Form
	{

		public MainForm()
		{
			InitializeComponent();
		}

		private Subject subject;

		internal Subject GetSubject()
		{
			return subject;
		}

		internal void SetSubject(Subject subject)
		{
			this.subject = subject;
			FileUtil.GenerateDBFile(subject.Id);
			SQLiteUtil.get().CloseConnection().OpenConnection().Attach(subject.Id);
			this.itemManageMenuItem.Enabled = true;
			this.importMenuItem.Enabled = true;
			this.exportMenuItem.Enabled = true;
			this.practiceMenu.Enabled = true;
			this.examMenu.Enabled = true;
		}

		internal PracticeSetting PracticeSetting { get; set; }

		internal ExamSetting ExamSetting { get; set; }

		private void MainForm_Load(object sender, EventArgs e)
		{
			FileUtil.GenerateDBFile();
			SQLiteUtil.Init().OpenConnection();
		}

		private void Repaint(object sender, PaintEventArgs e)
		{
			this.UpdateStyles();
		}

		private void AboutMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(VersionUtil.Info());
		}

		private void ShowSubjectManageForm(object sender, EventArgs e)
		{
			Form subForm = new SubjectManageForm(this)
			{
				MdiParent = this,
				WindowState = FormWindowState.Maximized
			};
			subForm.Show();
			if (MdiChildren.Length > 1) MdiChildren[0].Close();
		}

		private void ShowItemManageForm(object sender, EventArgs e)
		{
			Form subForm = new ItemManageForm(this, ItemViewMode.DETAIL)
			{
				MdiParent = this,
				WindowState = FormWindowState.Maximized
			};
			subForm.Show();
			if (MdiChildren.Length > 1) MdiChildren[0].Close();
		}

		private void ShowPracticeSettingForm(object sender, EventArgs e)
		{
			Form subForm = new PracticeSettingForm(this)
			{
				MdiParent = this,
				WindowState = FormWindowState.Maximized
			};
			subForm.Show();
			if (MdiChildren.Length > 1) MdiChildren[0].Close();
		}

		private void ShowExamSettingForm(object sender, EventArgs e)
		{
			Form subForm = new ExamSettingForm(this)
			{
				MdiParent = this,
				WindowState = FormWindowState.Maximized
			};
			subForm.Show();
			if (MdiChildren.Length > 1) MdiChildren[0].Close();
		}

		private void ShowPracticeLogForm(object sender, EventArgs e)
		{
			Form subForm = new ItemManageForm(this, ItemViewMode.PRACTICE)
			{
				MdiParent = this,
				WindowState = FormWindowState.Maximized
			};
			subForm.Show();
			if (MdiChildren.Length > 1) MdiChildren[0].Close();
		}

		private void ShowExamLogForm(object sender, EventArgs e)
		{
			Form subForm = new ExamLogForm(this)
			{
				MdiParent = this,
				WindowState = FormWindowState.Maximized
			};
			subForm.Show();
			if (MdiChildren.Length>1) MdiChildren[0].Close();
		}

		private void ImportMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "试题导入";
			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "Excel 2007 工作簿(*.xlsx)|*.xlsx|Excel 2003 工作簿(*.xls)|*.xls";
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.Enabled = false;
				try
				{
					Services.FileService.ImportFrom(openFileDialog.FileName);
					MessageBox.Show("导入试题数据成功！", "导入完成");
				}
				catch (Exception ex)
				{
					MessageBox.Show("导入试题数据出现异常：\n" + ex.Message, "导入异常");
				}
				this.Enabled = true;
			}
		}

		private void ExportMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "试题导出";
			saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			saveFileDialog.Filter = "Excel 2007 工作簿(*.xlsx)|*.xlsx|Excel 2003 工作簿(*.xls)|*.xls";
			saveFileDialog.AddExtension = true;
			saveFileDialog.ValidateNames = true;
			saveFileDialog.FileName = subject.Name;
			saveFileDialog.OverwritePrompt = true;
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.Enabled = false;
				try
				{
					Services.FileService.ExportTo(saveFileDialog.FileName);
					MessageBox.Show("导出试题数据成功！", "导出完成");
				}
				catch (Exception ex)
				{
					MessageBox.Show("导出试题数据出现异常：\n" + ex.Message, "导出异常");
				}
				this.Enabled = true;
			}
		}
	}
}
