namespace IBMS_Personal.View
{
	partial class TypeChapterManageForm
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
			this.typeComboBox = new System.Windows.Forms.ComboBox();
			this.deleteTypeButton = new System.Windows.Forms.Button();
			this.typeGroupBox = new System.Windows.Forms.GroupBox();
			this.flagLabel = new System.Windows.Forms.Label();
			this.familyLabel = new System.Windows.Forms.Label();
			this.familyComboBox = new System.Windows.Forms.ComboBox();
			this.flagComboBox = new System.Windows.Forms.ComboBox();
			this.addTypeButton = new System.Windows.Forms.Button();
			this.typeTextBox = new System.Windows.Forms.TextBox();
			this.chapterGroupBox = new System.Windows.Forms.GroupBox();
			this.addChapterButton = new System.Windows.Forms.Button();
			this.chapterTextBox = new System.Windows.Forms.TextBox();
			this.chapterComboBox = new System.Windows.Forms.ComboBox();
			this.deleteChapterButton = new System.Windows.Forms.Button();
			this.closeButton = new System.Windows.Forms.Button();
			this.typeGroupBox.SuspendLayout();
			this.chapterGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// typeComboBox
			// 
			this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeComboBox.FormattingEnabled = true;
			this.typeComboBox.Location = new System.Drawing.Point(50, 60);
			this.typeComboBox.Name = "typeComboBox";
			this.typeComboBox.Size = new System.Drawing.Size(300, 32);
			this.typeComboBox.TabIndex = 0;
			this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
			// 
			// deleteTypeButton
			// 
			this.deleteTypeButton.Location = new System.Drawing.Point(400, 60);
			this.deleteTypeButton.Name = "deleteTypeButton";
			this.deleteTypeButton.Size = new System.Drawing.Size(100, 69);
			this.deleteTypeButton.TabIndex = 4;
			this.deleteTypeButton.Text = "删 除";
			this.deleteTypeButton.UseVisualStyleBackColor = true;
			this.deleteTypeButton.Click += new System.EventHandler(this.DeleteTypeButton_Click);
			// 
			// typeGroupBox
			// 
			this.typeGroupBox.Controls.Add(this.flagLabel);
			this.typeGroupBox.Controls.Add(this.familyLabel);
			this.typeGroupBox.Controls.Add(this.familyComboBox);
			this.typeGroupBox.Controls.Add(this.flagComboBox);
			this.typeGroupBox.Controls.Add(this.addTypeButton);
			this.typeGroupBox.Controls.Add(this.typeTextBox);
			this.typeGroupBox.Controls.Add(this.typeComboBox);
			this.typeGroupBox.Controls.Add(this.deleteTypeButton);
			this.typeGroupBox.Location = new System.Drawing.Point(50, 25);
			this.typeGroupBox.Name = "typeGroupBox";
			this.typeGroupBox.Size = new System.Drawing.Size(550, 310);
			this.typeGroupBox.TabIndex = 7;
			this.typeGroupBox.TabStop = false;
			this.typeGroupBox.Text = "题型";
			// 
			// flagLabel
			// 
			this.flagLabel.AutoSize = true;
			this.flagLabel.Location = new System.Drawing.Point(201, 105);
			this.flagLabel.Name = "flagLabel";
			this.flagLabel.Size = new System.Drawing.Size(106, 24);
			this.flagLabel.TabIndex = 10;
			this.flagLabel.Text = "主客观题";
			// 
			// familyLabel
			// 
			this.familyLabel.AutoSize = true;
			this.familyLabel.Location = new System.Drawing.Point(46, 105);
			this.familyLabel.Name = "familyLabel";
			this.familyLabel.Size = new System.Drawing.Size(106, 24);
			this.familyLabel.TabIndex = 9;
			this.familyLabel.Text = "题型分类";
			// 
			// familyComboBox
			// 
			this.familyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.familyComboBox.FormattingEnabled = true;
			this.familyComboBox.Items.AddRange(new object[] {
            "判断题",
            "单选题",
            "多选题",
            "问答题"});
			this.familyComboBox.Location = new System.Drawing.Point(50, 230);
			this.familyComboBox.Name = "familyComboBox";
			this.familyComboBox.Size = new System.Drawing.Size(145, 32);
			this.familyComboBox.TabIndex = 8;
			this.familyComboBox.SelectedIndexChanged += new System.EventHandler(this.FamilyComboBox_SelectedIndexChanged);
			// 
			// flagComboBox
			// 
			this.flagComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.flagComboBox.FormattingEnabled = true;
			this.flagComboBox.Items.AddRange(new object[] {
            "客观题",
            "主观题"});
			this.flagComboBox.Location = new System.Drawing.Point(205, 230);
			this.flagComboBox.Name = "flagComboBox";
			this.flagComboBox.Size = new System.Drawing.Size(145, 32);
			this.flagComboBox.TabIndex = 7;
			// 
			// addTypeButton
			// 
			this.addTypeButton.Location = new System.Drawing.Point(400, 180);
			this.addTypeButton.Name = "addTypeButton";
			this.addTypeButton.Size = new System.Drawing.Size(100, 73);
			this.addTypeButton.TabIndex = 6;
			this.addTypeButton.Text = "添 加";
			this.addTypeButton.UseVisualStyleBackColor = true;
			this.addTypeButton.Click += new System.EventHandler(this.AddTypeButton_Click);
			// 
			// typeTextBox
			// 
			this.typeTextBox.Location = new System.Drawing.Point(50, 180);
			this.typeTextBox.Name = "typeTextBox";
			this.typeTextBox.Size = new System.Drawing.Size(300, 35);
			this.typeTextBox.TabIndex = 5;
			// 
			// chapterGroupBox
			// 
			this.chapterGroupBox.Controls.Add(this.addChapterButton);
			this.chapterGroupBox.Controls.Add(this.chapterTextBox);
			this.chapterGroupBox.Controls.Add(this.chapterComboBox);
			this.chapterGroupBox.Controls.Add(this.deleteChapterButton);
			this.chapterGroupBox.Location = new System.Drawing.Point(50, 380);
			this.chapterGroupBox.Name = "chapterGroupBox";
			this.chapterGroupBox.Size = new System.Drawing.Size(550, 220);
			this.chapterGroupBox.TabIndex = 8;
			this.chapterGroupBox.TabStop = false;
			this.chapterGroupBox.Text = "章节";
			// 
			// addChapterButton
			// 
			this.addChapterButton.Location = new System.Drawing.Point(400, 130);
			this.addChapterButton.Name = "addChapterButton";
			this.addChapterButton.Size = new System.Drawing.Size(100, 50);
			this.addChapterButton.TabIndex = 6;
			this.addChapterButton.Text = "添 加";
			this.addChapterButton.UseVisualStyleBackColor = true;
			this.addChapterButton.Click += new System.EventHandler(this.AddChapterButton_Click);
			// 
			// chapterTextBox
			// 
			this.chapterTextBox.Location = new System.Drawing.Point(50, 140);
			this.chapterTextBox.Name = "chapterTextBox";
			this.chapterTextBox.Size = new System.Drawing.Size(300, 35);
			this.chapterTextBox.TabIndex = 5;
			// 
			// chapterComboBox
			// 
			this.chapterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.chapterComboBox.FormattingEnabled = true;
			this.chapterComboBox.Location = new System.Drawing.Point(50, 60);
			this.chapterComboBox.Name = "chapterComboBox";
			this.chapterComboBox.Size = new System.Drawing.Size(300, 32);
			this.chapterComboBox.TabIndex = 0;
			this.chapterComboBox.SelectedIndexChanged += new System.EventHandler(this.ChapterComboBox_SelectedIndexChanged);
			// 
			// deleteChapterButton
			// 
			this.deleteChapterButton.Location = new System.Drawing.Point(400, 50);
			this.deleteChapterButton.Name = "deleteChapterButton";
			this.deleteChapterButton.Size = new System.Drawing.Size(100, 50);
			this.deleteChapterButton.TabIndex = 4;
			this.deleteChapterButton.Text = "删 除";
			this.deleteChapterButton.UseVisualStyleBackColor = true;
			this.deleteChapterButton.Click += new System.EventHandler(this.DeleteChapterButton_Click);
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(259, 635);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(120, 60);
			this.closeButton.TabIndex = 9;
			this.closeButton.Text = "关 闭";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// TypeChapterManageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(649, 719);
			this.ControlBox = false;
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.chapterGroupBox);
			this.Controls.Add(this.typeGroupBox);
			this.Name = "TypeChapterManageForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "题型章节管理";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TypeChapterManageForm_FormClosed);
			this.Load += new System.EventHandler(this.TypeChapterManageForm_Load);
			this.typeGroupBox.ResumeLayout(false);
			this.typeGroupBox.PerformLayout();
			this.chapterGroupBox.ResumeLayout(false);
			this.chapterGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ComboBox typeComboBox;
		private System.Windows.Forms.Button deleteTypeButton;
		private System.Windows.Forms.GroupBox typeGroupBox;
		private System.Windows.Forms.Button addTypeButton;
		private System.Windows.Forms.TextBox typeTextBox;
		private System.Windows.Forms.GroupBox chapterGroupBox;
		private System.Windows.Forms.Button addChapterButton;
		private System.Windows.Forms.TextBox chapterTextBox;
		private System.Windows.Forms.ComboBox chapterComboBox;
		private System.Windows.Forms.Button deleteChapterButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.ComboBox flagComboBox;
		private System.Windows.Forms.ComboBox familyComboBox;
		private System.Windows.Forms.Label familyLabel;
		private System.Windows.Forms.Label flagLabel;
	}
}