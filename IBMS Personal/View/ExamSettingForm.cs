using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static IBMS_Personal.Entity.ExamSetting;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.View
{
	public partial class ExamSettingForm : Form
	{
		private MainForm mainForm;
		private bool existLastSetting;
		private ExamSetting setting = new ExamSetting();
		private ExamModuleSetting module;

		public ExamSettingForm()
		{
			InitializeComponent();
		}

		public ExamSettingForm(MainForm mainForm)
		{
			InitializeComponent();
			this.mainForm = mainForm;
			existLastSetting = mainForm.ExamSetting != null;
		}

		private void ExamSettingForm_Load(object sender, EventArgs e)
		{
			scoreTextBox.Text = "0";
			scoreTextBox.Enabled = false;
			submitModuleButton.Enabled = false;
			itemChapterComboBox.Enabled = false;
			numberTextBox.Text = "0";
			numberTextBox.Enabled = false;
			addChapterButton.Enabled = false;
			addModuleButton.Enabled = false;
			revokeModuleButton.Enabled = false;
			finishSettingButton.Enabled = false;

			moduleSettingTextBox.Text = "";
			examSettingRichTextBox.Text = "";
			totalScoreTextBox.Text = "0";
			totalTimeTextBox.Text = "0";

			// 填充题型列表
			List<ItemType> types = Services.ItemService.GetAllTypes();
			for (int index = 0; index < types.Count; index++)
			{
				itemTypeComboBox.Items.Add(types[index]);
			}

			// 存在上一次的配置信息
			if (existLastSetting)
			{
				// 自动显示上一次的配置信息
				examSettingRichTextBox.Text = mainForm.ExamSetting.ToString();
				TimeSpan totalTime = mainForm.ExamSetting.TotalTime;
				totalTimeTextBox.Text = totalTime.Hours * 60 + totalTime.Minutes + "";
				totalScoreTextBox.Text = mainForm.ExamSetting.TotalScore.ToString();
				finishSettingButton.Enabled = true;
			}
		}

		private void ItemTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			module = null;
			scoreTextBox.Text = "0";
			scoreTextBox.Enabled = itemTypeComboBox.SelectedIndex >= 0;
			submitModuleButton.Enabled = itemTypeComboBox.SelectedIndex >= 0;
			itemChapterComboBox.Enabled= false;
			itemChapterComboBox.Items.Clear();
			numberTextBox.Enabled = false;
			numberTextBox.Text = "0";
			addChapterButton.Enabled = false;
			moduleSettingTextBox.Text = "";
			addModuleButton.Enabled = false;
		}

		private void SubmitModuleButton_Click(object sender, EventArgs e)
		{
			submitModuleButton.Enabled = false;
			if (!int.TryParse(scoreTextBox.Text.Trim(), out int score) || score <= 0)
			{
				MessageBox.Show("请输入该模块每题的分值，要求为正整数！", "分值异常提示");
				submitModuleButton.Enabled = true;
				return;
			}
			scoreTextBox.Enabled= false;
			ItemType type = (ItemType)this.itemTypeComboBox.SelectedItem;
			List<ItemChapter> chapters = Services.ItemService.GetChaptersByType(type);
			if(chapters.Count > 1)
			{
				chapters.Insert(0, new ItemChapter { Id = 0, TypeId = type.Id, Name = "全部" });
			}
			for (int index = 0; index < chapters.Count; index++)
			{
				itemChapterComboBox.Items.Add(chapters[index]);
			}
			module = new ExamModuleSetting(type, score);
			moduleSettingTextBox.Text = module.ToString();
			itemChapterComboBox.Enabled = true;
		}

		private void ItemChapterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			numberTextBox.Text = "0";
			numberTextBox.Enabled = itemChapterComboBox.SelectedIndex >= 0;
			addChapterButton.Enabled = itemChapterComboBox.SelectedIndex >= 0;
		}

		private void AddChapterButton_Click(object sender, EventArgs e)
		{
			numberTextBox.Enabled = false;
			addChapterButton.Enabled = false;

			if (!int.TryParse(totalScoreTextBox.Text.Trim(), out int totalScore) || totalScore <= 0)
			{
				MessageBox.Show("请输入考卷总分，要求为正整数！", "考卷总分异常提示");
				numberTextBox.Enabled = true;
				addChapterButton.Enabled = true;
				return;
			}
			if (!int.TryParse(numberTextBox.Text.Trim(), out int number) || number <= 0)
			{
				MessageBox.Show("请输入该章节选题数量，要求为正整数！", "选题数量异常提示");
				numberTextBox.Enabled = true;
				addChapterButton.Enabled = true;
				return;
			}
			ItemChapter chapter = (ItemChapter)itemChapterComboBox.SelectedItem;
			if (module.Chapters.ContainsKey(chapter))
			{
				MessageBox.Show("本模块已包含当前章节，请勿重复选择！", "章节重复提示");
				itemChapterComboBox.SelectedIndex = -1;
				return;
			}
			// 统计非扩展试题和扩展子题的数量
			int count = Services.ItemService.CountItemsByChapterWithFlag(chapter, ItemExtendFlag.PARENT, false);
			if (count < number)
			{
				MessageBox.Show("该章节选题数量不能大于试题总数: " + count, "选题数量异常提示");
				numberTextBox.Enabled = true;
				addChapterButton.Enabled = true;
				return;
			}
			int totalScore2 = setting.CountScore() + module.CountScore() + module.Score * number;
			if (totalScore2 > totalScore)
			{
				StringBuilder sb = new StringBuilder("试题统计分值：").Append(totalScore2)
									.Append("\n考卷总分：").Append(totalScore)
									.Append("\n所有试题总分值不能超过考卷总分！");
				MessageBox.Show(sb.ToString(), "统计分值异常提示");
				numberTextBox.Enabled = true;
				addChapterButton.Enabled = true;
				return;
			}
			module.AddChapter(chapter, number);
			moduleSettingTextBox.Text = module.ToString();
			itemChapterComboBox.SelectedIndex = -1;
			addModuleButton.Enabled= true;
		}

		private void AddModuleButton_Click(object sender, EventArgs e)
		{
			addModuleButton.Enabled = false;

			if (!int.TryParse(totalTimeTextBox.Text.Trim(), out int totalTime) || totalTime < 30)
			{
				MessageBox.Show("请输入考试时间，要求为不小于30的正整数！", "考试时间异常提示");
				addModuleButton.Enabled = true;
				return;
			}
			if (!int.TryParse(totalScoreTextBox.Text.Trim(), out int totalScore) || totalScore <= 0)
			{
				MessageBox.Show("请输入考卷总分，要求为正整数！", "考卷总分异常提示");
				addModuleButton.Enabled = true;
				return;
			}
			int totalScore2 = setting.CountScore() + module.CountScore();
			if (totalScore2 > totalScore)
			{
				StringBuilder sb = new StringBuilder("试题统计分值：").Append(totalScore2)
									.Append("\n考卷总分：").Append(totalScore)
									.Append("\n所有试题总分值不能超过考卷总分！");
				MessageBox.Show(sb.ToString(), "统计分值异常提示");
				addModuleButton.Enabled = true;
				return;
			}
			existLastSetting = false;
			setting.AddModule(module);
			setting.TotalScore = totalScore;
			setting.TotalTime = new TimeSpan(totalTime / 60, totalTime % 60, 0);
			examSettingRichTextBox.Text = setting.ToString();
			itemTypeComboBox.SelectedIndex = -1;
			revokeModuleButton.Enabled = true;
			finishSettingButton.Enabled = true;
		}

		private void RevokeModuleButton_Click(object sender, EventArgs e)
		{
			revokeModuleButton.Enabled = false;
			examSettingRichTextBox.Text = "";
			setting.RemoveModule();
			examSettingRichTextBox.Text = setting.CountModules() > 0 ? setting.ToString() : "";
			revokeModuleButton.Enabled = setting.CountModules() > 0;
		}

		private void FinishSettingButton_Click(object sender, EventArgs e)
		{
			finishSettingButton.Enabled= false;

			if (!int.TryParse(totalTimeTextBox.Text.Trim(), out int totalTime) || totalTime < 30)
			{
				MessageBox.Show("请输入考试时间，要求为不小于30的正整数！", "考试时间异常提示");
				finishSettingButton.Enabled = true;
				return;
			}
			if (!int.TryParse(totalScoreTextBox.Text.Trim(), out int totalScore) || totalScore <= 0)
			{
				MessageBox.Show("请输入考卷总分，要求为正整数！", "考卷总分异常提示");
				finishSettingButton.Enabled = true;
				return;
			}
			ExamSetting finalSetting = existLastSetting ? mainForm.ExamSetting : setting;
			int totalScore2 = finalSetting.CountScore();
			if (totalScore2 != totalScore)
			{
				StringBuilder sb = new StringBuilder("试题统计分值：").Append(totalScore2)
									.Append("\n考卷总分：").Append(totalScore)
									.Append("\n所有试题总分值与考卷总分不一致！");
				MessageBox.Show(sb.ToString(), "统计分值异常提示");
				finishSettingButton.Enabled = true;
				return;
			}
			finalSetting.TotalScore = totalScore;
			finalSetting.TotalTime = new TimeSpan(totalTime / 60, totalTime % 60, 0);
			mainForm.ExamSetting = finalSetting;
			ExamForm examForm = new ExamForm(mainForm);
			examForm.Show();
			finishSettingButton.Enabled = true;
		}

		private void CancelSettingButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
