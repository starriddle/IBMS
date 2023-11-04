using IBMS_Personal.Entity;
using IBMS_Personal.Service;
using IBMS_Personal.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static IBMS_Personal.Util.Constants;

namespace IBMS_Personal.View
{
	public partial class SubjectManageForm : Form
	{
		private MainForm mainForm;

		public SubjectManageForm()
		{
			InitializeComponent();
		}

		public SubjectManageForm(MainForm mainForm)
		{
			InitializeComponent();
			this.mainForm = mainForm;
		}

		private void SubjectManageForm_Load(object sender, EventArgs e)
		{
			mainForm.Text = "通用题库管理系统";
			Subject currentSubject = mainForm.GetSubject();

			if (currentSubject == null)
			{
				InitForm();
				return;
			}
			Subject group = Services.SubjectService.GetSubjectById(currentSubject.ParentId);
			while (group != null)
			{
				selectedGroupListBox.Items.Insert(0, group);
				group = Services.SubjectService.GetSubjectById(group.ParentId);
			}
			RefreshCurrentListBox();
			RefreshSelectLabel();
			foreach (Subject subject in currentSubjectListBox.Items)
			{
				if (subject.Id == currentSubject.Id)
				{
					currentSubjectListBox.SelectedItem = subject;
					selectSubjectButton.PerformClick();
					break;
				}
			}
		}

		private void InitButton_Click(object sender, EventArgs e)
		{
			InitForm();
		}

		private void InitForm()
		{
			// 初始化界面
			this.selectedGroupListBox.Items.Clear();
			this.backButton.Enabled = false;
			this.nameBox.Text = "";
			RefreshCurrentListBox();
			RefreshSelectLabel();
		}

		private void RefreshSelectLabel()
		{
			StringBuilder sb = new StringBuilder("选择: ");
			foreach (var group in this.selectedGroupListBox.Items)
			{
				sb.Append(group).Append(" / ");
			}
			var currentSubject = this.currentSubjectListBox.SelectedItem;
			if (currentSubject == null)
			{
				sb.Append("?");
			}
			else
			{
				sb.Append(currentSubject);
			}
			this.selectLabel.Text = sb.ToString();
		}

		private void RefreshCurrentListBox()
		{
			// 更新界面
			this.currentGroupListBox.Items.Clear();
			this.deleteGroupButton.Enabled = false;
			this.selectGroupButton.Enabled = false;
			this.currentSubjectListBox.Items.Clear();
			this.deleteSubjectButton.Enabled = false;
			this.selectSubjectButton.Enabled = false;
			this.confirmButton.Enabled = false;

			// 更新数据
			long parentId = Constants.DEFAULT_PARENT_ID;
			int count = this.selectedGroupListBox.Items.Count;
			if (count > 0)
			{
				Subject parentGroup = (Subject)this.selectedGroupListBox.Items[count - 1];
				parentId = parentGroup.Id;
			}
			Dictionary<int, List<Subject>> dictionary = Services.SubjectService.getSubjectsByParentId(parentId);
			if (dictionary.TryGetValue(SubjectFlag.GROUP, out List<Subject> currentGroups))
			{
				foreach (Subject group in currentGroups)
				{
					this.currentGroupListBox.Items.Add(group);
				}
			}
			if (dictionary.TryGetValue(SubjectFlag.SUBJECT, out List<Subject> currentSubjects))
			{
				foreach (Subject subject in currentSubjects)
				{
					this.currentSubjectListBox.Items.Add(subject);
				}
			}
		}

		private void CurrentGroupListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = this.currentGroupListBox.SelectedIndex;
			if (index == -1)
			{
				return;
			}
			this.deleteGroupButton.Enabled = true;
			this.selectGroupButton.Enabled = true;
		}

		private void CurrentSubjectListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = this.currentSubjectListBox.SelectedIndex;
			if(index == -1)
			{
				return;
			}
			this.confirmButton.Enabled = false;
			this.deleteSubjectButton.Enabled = true;
			this.selectSubjectButton.Enabled = true;
		}

		private void SelectGroupButton_Click(object sender, EventArgs e)
		{
			this.selectGroupButton.Enabled = false;
			this.deleteGroupButton.Enabled = false;
			this.selectedGroupListBox.Items.Add(this.currentGroupListBox.SelectedItem);
			this.backButton.Enabled = true;

			RefreshCurrentListBox();
			RefreshSelectLabel();
		}

		private void SelectSubjectButton_Click(object sender, EventArgs e)
		{
			this.selectSubjectButton.Enabled = false;
			this.confirmButton.Enabled = true;
			RefreshSelectLabel();
		}

		private void DeleteGroupButton_Click(object sender, EventArgs e)
		{
			this.deleteGroupButton.Enabled = false;
			this.selectGroupButton.Enabled = false;

			Subject group = (Subject)currentSubjectListBox.SelectedItem;
			// 如果分类下为空，则删除分类，否则提示无法删除，需要操作数据库
			int count = Services.SubjectService.CountSubjectsByParentGroup(group);
			if (count > 0)
			{
				MessageBox.Show("当前分类下存在下级分类或科目，无法直接删除！\n请先删除所有下级分类和科目，再删除当前分类！", "删除失败提示");
				this.deleteGroupButton.Enabled = true;
				this.selectGroupButton.Enabled = true;
				return;
			}
			try
			{
				Services.SubjectService.DeleteSubject(group);
			}
			catch (Exception ex)
			{
				MessageBox.Show("删除分类出现错误：\n" + ex.Message, "异常提示");
				this.deleteGroupButton.Enabled = true;
				this.selectGroupButton.Enabled = true;
				return;
			}
			this.currentGroupListBox.SelectedIndex = -1;
			this.currentGroupListBox.Items.Remove(group);
		}

		private void DeleteSubjectButton_Click(object sender, EventArgs e)
		{
			this.deleteSubjectButton.Enabled = false;
			this.selectSubjectButton.Enabled = false;

			Subject subject = (Subject)currentSubjectListBox.SelectedItem;
			// 删除 科目表 条目，以及对应的科目数据库
			try
			{
				FileUtil.DeleteDBFile(subject.Id);
				Services.SubjectService.DeleteSubject(subject);
			}
			catch (Exception ex)
			{
				MessageBox.Show("删除科目出现错误：\n" + ex.Message, "异常提示");
				this.deleteSubjectButton.Enabled = true;
				this.selectSubjectButton.Enabled = true;
				return;
			}
			this.currentSubjectListBox.SelectedIndex = -1;
			this.currentSubjectListBox.Items.Remove(subject);
		}

		private void AddGroupButton_Click(object sender, EventArgs e)
		{
			addGroupButton.Enabled = false;
			string name = this.nameBox.Text.Trim();
			this.nameBox.Text = name;
			if(name.Length == 0)
			{
				MessageBox.Show("请输入分类名称！");
				addGroupButton.Enabled = true;
				return;
			}
			foreach (Subject group in this.currentGroupListBox.Items)
			{
				if(group.Name == name)
				{
					MessageBox.Show("已存在相同名称的当前分类或科目！");
					addGroupButton.Enabled = true;
					return;
				}
			}
			foreach (Subject subject in this.currentSubjectListBox.Items)
			{
				if (subject.Name == name)
				{
					MessageBox.Show("已存在相同名称的当前分类或科目！");
					addGroupButton.Enabled = true;
					return;
				}
			}

			// 添加分类数据
			long parentId = Constants.DEFAULT_PARENT_ID;
			int count = this.selectedGroupListBox.Items.Count;
			if (count > 0)
			{
				Subject parentGroup = (Subject)this.selectedGroupListBox.Items[count - 1];
				parentId = parentGroup.Id;
			}
			try
			{
				Subject newGroup = Services.SubjectService.AddSubject(name, parentId, SubjectFlag.GROUP);
				this.currentGroupListBox.Items.Add(newGroup);
				this.nameBox.Text = "";
			}
			catch (Exception ex)
			{
				MessageBox.Show("添加分类出现错误：\n" + ex.Message, "异常提示");
			}
			addGroupButton.Enabled = true;
		}

		private void AddSubjectButton_Click(object sender, EventArgs e)
		{
			addSubjectButton.Enabled = false;
			string name = this.nameBox.Text.Trim();
			this.nameBox.Text = name;
			if (name.Length == 0)
			{
				MessageBox.Show("请输入科目名称！");
				addSubjectButton.Enabled = true;
				return;
			}
			foreach (Subject group in this.currentGroupListBox.Items)
			{
				if (group.Name == name)
				{
					MessageBox.Show("已存在相同名称的当前分类或科目！");
					addSubjectButton.Enabled = true;
					return;
				}
			}
			foreach (Subject subject in this.currentSubjectListBox.Items)
			{
				if (subject.Name == name)
				{
					MessageBox.Show("已存在相同名称的当前分类或科目！");
					addSubjectButton.Enabled = true;
					return;
				}
			}

			// 添加科目数据
			long parentId = Constants.DEFAULT_PARENT_ID;
			int count = this.selectedGroupListBox.Items.Count;
			if (count > 0)
			{
				Subject parentGroup = (Subject)this.selectedGroupListBox.Items[count - 1];
				parentId = parentGroup.Id;
			}
			try
			{
				Subject newSubject = Services.SubjectService.AddSubject(name, parentId, SubjectFlag.SUBJECT);
				currentSubjectListBox.Items.Add(newSubject);
				FileUtil.GenerateDBFile(newSubject.Id);
				this.nameBox.Text = "";
			}
			catch (Exception ex)
			{
				MessageBox.Show("添加科目出现错误：\n" + ex.Message, "异常提示");
			}
			addSubjectButton.Enabled = true;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ConfirmButton_Click(object sender, EventArgs e)
		{
			mainForm.SetSubject((Subject)this.currentSubjectListBox.SelectedItem);
			this.Close();
		}

		private void BackButton_Click(object sender, EventArgs e)
		{
			int count = this.selectedGroupListBox.Items.Count - 1;
			if (count == 0)
			{
				InitForm();
				return;
			}
			this.selectedGroupListBox.Items.RemoveAt(count);
			RefreshCurrentListBox();
			RefreshSelectLabel();
		}

		private void SubjectManageForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (mainForm.GetSubject() != null)
			{
				mainForm.Text = "[" + mainForm.GetSubject().Name + "]";
			}
		}
	}
}
