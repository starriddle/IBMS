namespace IBMS_Personal.View
{
	partial class ExamSettingForm
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
			this.itemChapterComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.numberTextBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.addChapterButton = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.submitModuleButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.itemTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.scoreTextBox = new System.Windows.Forms.TextBox();
			this.moduleSettingTextBox = new System.Windows.Forms.TextBox();
			this.addModuleButton = new System.Windows.Forms.Button();
			this.finishSettingButton = new System.Windows.Forms.Button();
			this.totalTimeTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cancelSettingButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.totalScoreTextBox = new System.Windows.Forms.TextBox();
			this.revokeModuleButton = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.examSettingRichTextBox = new System.Windows.Forms.RichTextBox();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// itemChapterComboBox
			// 
			this.itemChapterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.itemChapterComboBox.FormattingEnabled = true;
			this.itemChapterComboBox.Location = new System.Drawing.Point(110, 34);
			this.itemChapterComboBox.Name = "itemChapterComboBox";
			this.itemChapterComboBox.Size = new System.Drawing.Size(290, 32);
			this.itemChapterComboBox.TabIndex = 19;
			this.itemChapterComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemChapterComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(30, 37);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 24);
			this.label5.TabIndex = 18;
			this.label5.Text = "章节:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(30, 113);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 24);
			this.label6.TabIndex = 21;
			this.label6.Text = "题量:";
			// 
			// numberTextBox
			// 
			this.numberTextBox.Location = new System.Drawing.Point(106, 110);
			this.numberTextBox.Name = "numberTextBox";
			this.numberTextBox.Size = new System.Drawing.Size(120, 35);
			this.numberTextBox.TabIndex = 20;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.addChapterButton);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.itemChapterComboBox);
			this.groupBox2.Controls.Add(this.numberTextBox);
			this.groupBox2.Location = new System.Drawing.Point(440, 34);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(430, 175);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "选题";
			// 
			// addChapterButton
			// 
			this.addChapterButton.Location = new System.Drawing.Point(280, 100);
			this.addChapterButton.Name = "addChapterButton";
			this.addChapterButton.Size = new System.Drawing.Size(120, 50);
			this.addChapterButton.TabIndex = 22;
			this.addChapterButton.Text = "添  加";
			this.addChapterButton.UseVisualStyleBackColor = true;
			this.addChapterButton.Click += new System.EventHandler(this.AddChapterButton_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.submitModuleButton);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.itemTypeComboBox);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.scoreTextBox);
			this.groupBox3.Controls.Add(this.moduleSettingTextBox);
			this.groupBox3.Controls.Add(this.groupBox2);
			this.groupBox3.Location = new System.Drawing.Point(25, 25);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(900, 350);
			this.groupBox3.TabIndex = 24;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "模块";
			// 
			// submitModuleButton
			// 
			this.submitModuleButton.Location = new System.Drawing.Point(280, 134);
			this.submitModuleButton.Name = "submitModuleButton";
			this.submitModuleButton.Size = new System.Drawing.Size(120, 50);
			this.submitModuleButton.TabIndex = 32;
			this.submitModuleButton.Text = "确  定";
			this.submitModuleButton.UseVisualStyleBackColor = true;
			this.submitModuleButton.Click += new System.EventHandler(this.SubmitModuleButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 24);
			this.label1.TabIndex = 28;
			this.label1.Text = "题型:";
			// 
			// itemTypeComboBox
			// 
			this.itemTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.itemTypeComboBox.FormattingEnabled = true;
			this.itemTypeComboBox.Location = new System.Drawing.Point(110, 60);
			this.itemTypeComboBox.Name = "itemTypeComboBox";
			this.itemTypeComboBox.Size = new System.Drawing.Size(290, 32);
			this.itemTypeComboBox.TabIndex = 29;
			this.itemTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemTypeComboBox_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(30, 147);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 24);
			this.label4.TabIndex = 31;
			this.label4.Text = "分值:";
			// 
			// scoreTextBox
			// 
			this.scoreTextBox.Location = new System.Drawing.Point(110, 144);
			this.scoreTextBox.Name = "scoreTextBox";
			this.scoreTextBox.Size = new System.Drawing.Size(120, 35);
			this.scoreTextBox.TabIndex = 30;
			// 
			// moduleSettingTextBox
			// 
			this.moduleSettingTextBox.Location = new System.Drawing.Point(30, 230);
			this.moduleSettingTextBox.Multiline = true;
			this.moduleSettingTextBox.Name = "moduleSettingTextBox";
			this.moduleSettingTextBox.ReadOnly = true;
			this.moduleSettingTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.moduleSettingTextBox.Size = new System.Drawing.Size(840, 100);
			this.moduleSettingTextBox.TabIndex = 25;
			// 
			// addModuleButton
			// 
			this.addModuleButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.addModuleButton.Location = new System.Drawing.Point(935, 205);
			this.addModuleButton.Name = "addModuleButton";
			this.addModuleButton.Size = new System.Drawing.Size(100, 80);
			this.addModuleButton.TabIndex = 19;
			this.addModuleButton.Text = "添加\r\n模块";
			this.addModuleButton.UseVisualStyleBackColor = false;
			this.addModuleButton.Click += new System.EventHandler(this.AddModuleButton_Click);
			// 
			// finishSettingButton
			// 
			this.finishSettingButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.finishSettingButton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.finishSettingButton.Location = new System.Drawing.Point(935, 295);
			this.finishSettingButton.Name = "finishSettingButton";
			this.finishSettingButton.Size = new System.Drawing.Size(100, 80);
			this.finishSettingButton.TabIndex = 24;
			this.finishSettingButton.Text = "完成";
			this.finishSettingButton.UseVisualStyleBackColor = false;
			this.finishSettingButton.Click += new System.EventHandler(this.FinishSettingButton_Click);
			// 
			// totalTimeTextBox
			// 
			this.totalTimeTextBox.Location = new System.Drawing.Point(999, 130);
			this.totalTimeTextBox.Name = "totalTimeTextBox";
			this.totalTimeTextBox.Size = new System.Drawing.Size(82, 35);
			this.totalTimeTextBox.TabIndex = 26;
			this.totalTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(935, 133);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 24);
			this.label7.TabIndex = 27;
			this.label7.Text = "时间";
			// 
			// cancelSettingButton
			// 
			this.cancelSettingButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cancelSettingButton.Location = new System.Drawing.Point(1045, 295);
			this.cancelSettingButton.Name = "cancelSettingButton";
			this.cancelSettingButton.Size = new System.Drawing.Size(100, 80);
			this.cancelSettingButton.TabIndex = 28;
			this.cancelSettingButton.Text = "取消";
			this.cancelSettingButton.UseVisualStyleBackColor = false;
			this.cancelSettingButton.Click += new System.EventHandler(this.CancelSettingButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(935, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 24);
			this.label2.TabIndex = 29;
			this.label2.Text = "总分";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1087, 133);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 24);
			this.label3.TabIndex = 30;
			this.label3.Text = "分钟";
			// 
			// totalScoreTextBox
			// 
			this.totalScoreTextBox.Location = new System.Drawing.Point(999, 60);
			this.totalScoreTextBox.Name = "totalScoreTextBox";
			this.totalScoreTextBox.Size = new System.Drawing.Size(82, 35);
			this.totalScoreTextBox.TabIndex = 31;
			this.totalScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// revokeModuleButton
			// 
			this.revokeModuleButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.revokeModuleButton.Location = new System.Drawing.Point(1045, 205);
			this.revokeModuleButton.Name = "revokeModuleButton";
			this.revokeModuleButton.Size = new System.Drawing.Size(100, 80);
			this.revokeModuleButton.TabIndex = 32;
			this.revokeModuleButton.Text = "撤销\r\n模块";
			this.revokeModuleButton.UseVisualStyleBackColor = false;
			this.revokeModuleButton.Click += new System.EventHandler(this.RevokeModuleButton_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(1087, 63);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(34, 24);
			this.label8.TabIndex = 33;
			this.label8.Text = "分";
			// 
			// examSettingRichTextBox
			// 
			this.examSettingRichTextBox.Location = new System.Drawing.Point(25, 400);
			this.examSettingRichTextBox.Name = "examSettingRichTextBox";
			this.examSettingRichTextBox.ReadOnly = true;
			this.examSettingRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.examSettingRichTextBox.Size = new System.Drawing.Size(1120, 300);
			this.examSettingRichTextBox.TabIndex = 34;
			this.examSettingRichTextBox.Text = "";
			// 
			// ExamSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1174, 729);
			this.ControlBox = false;
			this.Controls.Add(this.examSettingRichTextBox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.revokeModuleButton);
			this.Controls.Add(this.totalScoreTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cancelSettingButton);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.addModuleButton);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.totalTimeTextBox);
			this.Controls.Add(this.finishSettingButton);
			this.Name = "ExamSettingForm";
			this.Text = "组卷配置";
			this.Load += new System.EventHandler(this.ExamSettingForm_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox itemChapterComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox numberTextBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button addChapterButton;
		private System.Windows.Forms.TextBox moduleSettingTextBox;
		private System.Windows.Forms.Button finishSettingButton;
		private System.Windows.Forms.Button addModuleButton;
		private System.Windows.Forms.TextBox totalTimeTextBox;
		private System.Windows.Forms.Button submitModuleButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox itemTypeComboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox scoreTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button cancelSettingButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox totalScoreTextBox;
		private System.Windows.Forms.Button revokeModuleButton;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RichTextBox examSettingRichTextBox;
	}
}