namespace IBMS_Personal.View
{
	partial class SubjectManageForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.currentGroupListBox = new System.Windows.Forms.ListBox();
			this.currentSubjectListBox = new System.Windows.Forms.ListBox();
			this.currentGroupBox = new System.Windows.Forms.GroupBox();
			this.selectGroupButton = new System.Windows.Forms.Button();
			this.deleteGroupButton = new System.Windows.Forms.Button();
			this.currentSubjectBox = new System.Windows.Forms.GroupBox();
			this.deleteSubjectButton = new System.Windows.Forms.Button();
			this.selectSubjectButton = new System.Windows.Forms.Button();
			this.selectedGroupBox = new System.Windows.Forms.GroupBox();
			this.selectedGroupListBox = new System.Windows.Forms.ListBox();
			this.backButton = new System.Windows.Forms.Button();
			this.initButton = new System.Windows.Forms.Button();
			this.nameBox = new System.Windows.Forms.TextBox();
			this.addGroupButton = new System.Windows.Forms.Button();
			this.addSubjectButton = new System.Windows.Forms.Button();
			this.confirmButton = new System.Windows.Forms.Button();
			this.selectLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.currentGroupBox.SuspendLayout();
			this.currentSubjectBox.SuspendLayout();
			this.selectedGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// currentGroupListBox
			// 
			this.currentGroupListBox.FormattingEnabled = true;
			this.currentGroupListBox.ItemHeight = 24;
			this.currentGroupListBox.Location = new System.Drawing.Point(6, 34);
			this.currentGroupListBox.Name = "currentGroupListBox";
			this.currentGroupListBox.Size = new System.Drawing.Size(288, 340);
			this.currentGroupListBox.TabIndex = 1;
			this.currentGroupListBox.SelectedIndexChanged += new System.EventHandler(this.CurrentGroupListBox_SelectedIndexChanged);
			// 
			// currentSubjectListBox
			// 
			this.currentSubjectListBox.FormattingEnabled = true;
			this.currentSubjectListBox.ItemHeight = 24;
			this.currentSubjectListBox.Location = new System.Drawing.Point(6, 34);
			this.currentSubjectListBox.Name = "currentSubjectListBox";
			this.currentSubjectListBox.Size = new System.Drawing.Size(288, 340);
			this.currentSubjectListBox.TabIndex = 2;
			this.currentSubjectListBox.SelectedIndexChanged += new System.EventHandler(this.CurrentSubjectListBox_SelectedIndexChanged);
			// 
			// currentGroupBox
			// 
			this.currentGroupBox.Controls.Add(this.currentGroupListBox);
			this.currentGroupBox.Controls.Add(this.selectGroupButton);
			this.currentGroupBox.Controls.Add(this.deleteGroupButton);
			this.currentGroupBox.Location = new System.Drawing.Point(500, 50);
			this.currentGroupBox.Name = "currentGroupBox";
			this.currentGroupBox.Size = new System.Drawing.Size(300, 450);
			this.currentGroupBox.TabIndex = 1;
			this.currentGroupBox.TabStop = false;
			this.currentGroupBox.Text = "下级分类";
			// 
			// selectGroupButton
			// 
			this.selectGroupButton.Location = new System.Drawing.Point(169, 392);
			this.selectGroupButton.Name = "selectGroupButton";
			this.selectGroupButton.Size = new System.Drawing.Size(125, 52);
			this.selectGroupButton.TabIndex = 4;
			this.selectGroupButton.Text = "选  择";
			this.selectGroupButton.UseVisualStyleBackColor = true;
			this.selectGroupButton.Click += new System.EventHandler(this.SelectGroupButton_Click);
			// 
			// deleteGroupButton
			// 
			this.deleteGroupButton.Location = new System.Drawing.Point(6, 392);
			this.deleteGroupButton.Name = "deleteGroupButton";
			this.deleteGroupButton.Size = new System.Drawing.Size(125, 52);
			this.deleteGroupButton.TabIndex = 9;
			this.deleteGroupButton.Text = "删  除";
			this.deleteGroupButton.UseVisualStyleBackColor = true;
			this.deleteGroupButton.Click += new System.EventHandler(this.DeleteGroupButton_Click);
			// 
			// currentSubjectBox
			// 
			this.currentSubjectBox.Controls.Add(this.deleteSubjectButton);
			this.currentSubjectBox.Controls.Add(this.currentSubjectListBox);
			this.currentSubjectBox.Controls.Add(this.selectSubjectButton);
			this.currentSubjectBox.Location = new System.Drawing.Point(850, 50);
			this.currentSubjectBox.Name = "currentSubjectBox";
			this.currentSubjectBox.Size = new System.Drawing.Size(300, 450);
			this.currentSubjectBox.TabIndex = 2;
			this.currentSubjectBox.TabStop = false;
			this.currentSubjectBox.Text = "科目";
			// 
			// deleteSubjectButton
			// 
			this.deleteSubjectButton.Location = new System.Drawing.Point(6, 392);
			this.deleteSubjectButton.Name = "deleteSubjectButton";
			this.deleteSubjectButton.Size = new System.Drawing.Size(125, 52);
			this.deleteSubjectButton.TabIndex = 13;
			this.deleteSubjectButton.Text = "删  除";
			this.deleteSubjectButton.UseVisualStyleBackColor = true;
			this.deleteSubjectButton.Click += new System.EventHandler(this.DeleteSubjectButton_Click);
			// 
			// selectSubjectButton
			// 
			this.selectSubjectButton.Location = new System.Drawing.Point(169, 392);
			this.selectSubjectButton.Name = "selectSubjectButton";
			this.selectSubjectButton.Size = new System.Drawing.Size(125, 52);
			this.selectSubjectButton.TabIndex = 12;
			this.selectSubjectButton.Text = "选  择";
			this.selectSubjectButton.UseVisualStyleBackColor = true;
			this.selectSubjectButton.Click += new System.EventHandler(this.SelectSubjectButton_Click);
			// 
			// selectedGroupBox
			// 
			this.selectedGroupBox.Controls.Add(this.selectedGroupListBox);
			this.selectedGroupBox.Controls.Add(this.backButton);
			this.selectedGroupBox.Controls.Add(this.initButton);
			this.selectedGroupBox.Location = new System.Drawing.Point(50, 50);
			this.selectedGroupBox.Name = "selectedGroupBox";
			this.selectedGroupBox.Size = new System.Drawing.Size(300, 450);
			this.selectedGroupBox.TabIndex = 3;
			this.selectedGroupBox.TabStop = false;
			this.selectedGroupBox.Text = "已选择分类";
			// 
			// selectedGroupListBox
			// 
			this.selectedGroupListBox.FormattingEnabled = true;
			this.selectedGroupListBox.HorizontalScrollbar = true;
			this.selectedGroupListBox.ItemHeight = 24;
			this.selectedGroupListBox.Location = new System.Drawing.Point(6, 34);
			this.selectedGroupListBox.Name = "selectedGroupListBox";
			this.selectedGroupListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.selectedGroupListBox.Size = new System.Drawing.Size(288, 340);
			this.selectedGroupListBox.TabIndex = 3;
			this.selectedGroupListBox.TabStop = false;
			// 
			// backButton
			// 
			this.backButton.Location = new System.Drawing.Point(169, 392);
			this.backButton.Name = "backButton";
			this.backButton.Size = new System.Drawing.Size(125, 52);
			this.backButton.TabIndex = 5;
			this.backButton.Text = "上一级";
			this.backButton.UseVisualStyleBackColor = true;
			this.backButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// initButton
			// 
			this.initButton.Location = new System.Drawing.Point(6, 392);
			this.initButton.Name = "initButton";
			this.initButton.Size = new System.Drawing.Size(125, 52);
			this.initButton.TabIndex = 13;
			this.initButton.Text = "重  置";
			this.initButton.UseVisualStyleBackColor = true;
			this.initButton.Click += new System.EventHandler(this.InitButton_Click);
			// 
			// nameBox
			// 
			this.nameBox.Location = new System.Drawing.Point(500, 550);
			this.nameBox.Name = "nameBox";
			this.nameBox.Size = new System.Drawing.Size(300, 35);
			this.nameBox.TabIndex = 7;
			// 
			// addGroupButton
			// 
			this.addGroupButton.Location = new System.Drawing.Point(500, 600);
			this.addGroupButton.Name = "addGroupButton";
			this.addGroupButton.Size = new System.Drawing.Size(125, 52);
			this.addGroupButton.TabIndex = 10;
			this.addGroupButton.Text = "添加分类";
			this.addGroupButton.UseVisualStyleBackColor = true;
			this.addGroupButton.Click += new System.EventHandler(this.AddGroupButton_Click);
			// 
			// addSubjectButton
			// 
			this.addSubjectButton.Location = new System.Drawing.Point(675, 600);
			this.addSubjectButton.Name = "addSubjectButton";
			this.addSubjectButton.Size = new System.Drawing.Size(125, 52);
			this.addSubjectButton.TabIndex = 12;
			this.addSubjectButton.Text = "添加科目";
			this.addSubjectButton.UseVisualStyleBackColor = true;
			this.addSubjectButton.Click += new System.EventHandler(this.AddSubjectButton_Click);
			// 
			// confirmButton
			// 
			this.confirmButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.confirmButton.Location = new System.Drawing.Point(1019, 550);
			this.confirmButton.Name = "confirmButton";
			this.confirmButton.Size = new System.Drawing.Size(125, 102);
			this.confirmButton.TabIndex = 14;
			this.confirmButton.Text = "确  定";
			this.confirmButton.UseVisualStyleBackColor = true;
			this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
			// 
			// selectLabel
			// 
			this.selectLabel.AutoSize = true;
			this.selectLabel.Location = new System.Drawing.Point(46, 696);
			this.selectLabel.Name = "selectLabel";
			this.selectLabel.Size = new System.Drawing.Size(106, 24);
			this.selectLabel.TabIndex = 15;
			this.selectLabel.Text = "选择：？";
			// 
			// cancelButton
			// 
			this.cancelButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cancelButton.Location = new System.Drawing.Point(50, 550);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(125, 102);
			this.cancelButton.TabIndex = 16;
			this.cancelButton.Text = "取  消";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// SubjectManageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1174, 729);
			this.ControlBox = false;
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.selectLabel);
			this.Controls.Add(this.confirmButton);
			this.Controls.Add(this.addSubjectButton);
			this.Controls.Add(this.addGroupButton);
			this.Controls.Add(this.nameBox);
			this.Controls.Add(this.selectedGroupBox);
			this.Controls.Add(this.currentSubjectBox);
			this.Controls.Add(this.currentGroupBox);
			this.Name = "SubjectManageForm";
			this.Text = "科目管理";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SubjectManageForm_FormClosed);
			this.Load += new System.EventHandler(this.SubjectManageForm_Load);
			this.currentGroupBox.ResumeLayout(false);
			this.currentSubjectBox.ResumeLayout(false);
			this.selectedGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox currentGroupListBox;
		private System.Windows.Forms.ListBox currentSubjectListBox;
		private System.Windows.Forms.GroupBox currentGroupBox;
		private System.Windows.Forms.GroupBox currentSubjectBox;
		private System.Windows.Forms.GroupBox selectedGroupBox;
		private System.Windows.Forms.ListBox selectedGroupListBox;
		private System.Windows.Forms.Button selectGroupButton;
		private System.Windows.Forms.Button backButton;
		private System.Windows.Forms.TextBox nameBox;
		private System.Windows.Forms.Button deleteGroupButton;
		private System.Windows.Forms.Button addGroupButton;
		private System.Windows.Forms.Button selectSubjectButton;
		private System.Windows.Forms.Button deleteSubjectButton;
		private System.Windows.Forms.Button addSubjectButton;
		private System.Windows.Forms.Button initButton;
		private System.Windows.Forms.Button confirmButton;
		private System.Windows.Forms.Label selectLabel;
		private System.Windows.Forms.Button cancelButton;
	}
}