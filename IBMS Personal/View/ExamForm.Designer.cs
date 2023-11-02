namespace IBMS_Personal.View
{
	partial class ExamForm
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
			this.components = new System.ComponentModel.Container();
			this.prevButton = new System.Windows.Forms.Button();
			this.submitButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.examItemComboBox = new System.Windows.Forms.ComboBox();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.moduleComboBox = new System.Windows.Forms.ComboBox();
			this.timerLabel = new System.Windows.Forms.Label();
			this.ContentRichTextBox = new System.Windows.Forms.RichTextBox();
			this.checkBoxA = new System.Windows.Forms.CheckBox();
			this.radioButtonA = new System.Windows.Forms.RadioButton();
			this.radioButtonB = new System.Windows.Forms.RadioButton();
			this.radioButtonC = new System.Windows.Forms.RadioButton();
			this.radioButtonD = new System.Windows.Forms.RadioButton();
			this.radioButtonE = new System.Windows.Forms.RadioButton();
			this.radioButtonF = new System.Windows.Forms.RadioButton();
			this.checkBoxB = new System.Windows.Forms.CheckBox();
			this.checkBoxC = new System.Windows.Forms.CheckBox();
			this.checkBoxD = new System.Windows.Forms.CheckBox();
			this.checkBoxE = new System.Windows.Forms.CheckBox();
			this.checkBoxF = new System.Windows.Forms.CheckBox();
			this.answerGroupBox = new System.Windows.Forms.GroupBox();
			this.radioButtonTrue = new System.Windows.Forms.RadioButton();
			this.radioButtonFalse = new System.Windows.Forms.RadioButton();
			this.answerRichTextBox = new System.Windows.Forms.RichTextBox();
			this.resultLabel = new System.Windows.Forms.Label();
			this.countLabel = new System.Windows.Forms.Label();
			this.finishLabel = new System.Windows.Forms.Label();
			this.answerGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// prevButton
			// 
			this.prevButton.Enabled = false;
			this.prevButton.Location = new System.Drawing.Point(20, 762);
			this.prevButton.Name = "prevButton";
			this.prevButton.Size = new System.Drawing.Size(120, 50);
			this.prevButton.TabIndex = 12;
			this.prevButton.Text = "上一题";
			this.prevButton.UseVisualStyleBackColor = true;
			this.prevButton.Click += new System.EventHandler(this.PrevButton_Click);
			// 
			// submitButton
			// 
			this.submitButton.Location = new System.Drawing.Point(994, 757);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(160, 60);
			this.submitButton.TabIndex = 14;
			this.submitButton.Text = "交  卷";
			this.submitButton.UseVisualStyleBackColor = true;
			this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Enabled = false;
			this.nextButton.Location = new System.Drawing.Point(460, 762);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(120, 50);
			this.nextButton.TabIndex = 15;
			this.nextButton.Text = "下一题";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// examItemComboBox
			// 
			this.examItemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.examItemComboBox.FormattingEnabled = true;
			this.examItemComboBox.Location = new System.Drawing.Point(330, 767);
			this.examItemComboBox.Name = "examItemComboBox";
			this.examItemComboBox.Size = new System.Drawing.Size(100, 32);
			this.examItemComboBox.TabIndex = 16;
			this.examItemComboBox.SelectedIndexChanged += new System.EventHandler(this.ExamItemComboBox_SelectedIndexChanged);
			// 
			// timer
			// 
			this.timer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// moduleComboBox
			// 
			this.moduleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.moduleComboBox.FormattingEnabled = true;
			this.moduleComboBox.Location = new System.Drawing.Point(170, 767);
			this.moduleComboBox.Name = "moduleComboBox";
			this.moduleComboBox.Size = new System.Drawing.Size(150, 32);
			this.moduleComboBox.TabIndex = 19;
			this.moduleComboBox.SelectedIndexChanged += new System.EventHandler(this.ModuleComboBox_SelectedIndexChanged);
			// 
			// timerLabel
			// 
			this.timerLabel.Location = new System.Drawing.Point(774, 775);
			this.timerLabel.Name = "timerLabel";
			this.timerLabel.Size = new System.Drawing.Size(200, 24);
			this.timerLabel.TabIndex = 20;
			this.timerLabel.Text = "倒计时 00:00:00";
			this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ContentRichTextBox
			// 
			this.ContentRichTextBox.Location = new System.Drawing.Point(12, 12);
			this.ContentRichTextBox.Name = "ContentRichTextBox";
			this.ContentRichTextBox.Size = new System.Drawing.Size(1150, 500);
			this.ContentRichTextBox.TabIndex = 21;
			this.ContentRichTextBox.Text = "";
			// 
			// checkBoxA
			// 
			this.checkBoxA.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxA.Location = new System.Drawing.Point(150, 100);
			this.checkBoxA.Name = "checkBoxA";
			this.checkBoxA.Size = new System.Drawing.Size(75, 50);
			this.checkBoxA.TabIndex = 29;
			this.checkBoxA.Text = "A";
			this.checkBoxA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxA.UseVisualStyleBackColor = true;
			this.checkBoxA.Visible = false;
			// 
			// radioButtonA
			// 
			this.radioButtonA.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonA.Location = new System.Drawing.Point(150, 100);
			this.radioButtonA.Name = "radioButtonA";
			this.radioButtonA.Size = new System.Drawing.Size(75, 50);
			this.radioButtonA.TabIndex = 23;
			this.radioButtonA.TabStop = true;
			this.radioButtonA.Text = "A";
			this.radioButtonA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButtonA.UseVisualStyleBackColor = true;
			this.radioButtonA.Visible = false;
			// 
			// radioButtonB
			// 
			this.radioButtonB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonB.Location = new System.Drawing.Point(300, 100);
			this.radioButtonB.Name = "radioButtonB";
			this.radioButtonB.Size = new System.Drawing.Size(75, 50);
			this.radioButtonB.TabIndex = 30;
			this.radioButtonB.TabStop = true;
			this.radioButtonB.Text = "B";
			this.radioButtonB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButtonB.UseVisualStyleBackColor = true;
			this.radioButtonB.Visible = false;
			// 
			// radioButtonC
			// 
			this.radioButtonC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonC.Location = new System.Drawing.Point(450, 100);
			this.radioButtonC.Name = "radioButtonC";
			this.radioButtonC.Size = new System.Drawing.Size(75, 50);
			this.radioButtonC.TabIndex = 31;
			this.radioButtonC.TabStop = true;
			this.radioButtonC.Text = "C";
			this.radioButtonC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButtonC.UseVisualStyleBackColor = true;
			this.radioButtonC.Visible = false;
			// 
			// radioButtonD
			// 
			this.radioButtonD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonD.Location = new System.Drawing.Point(600, 100);
			this.radioButtonD.Name = "radioButtonD";
			this.radioButtonD.Size = new System.Drawing.Size(75, 50);
			this.radioButtonD.TabIndex = 32;
			this.radioButtonD.TabStop = true;
			this.radioButtonD.Text = "D";
			this.radioButtonD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButtonD.UseVisualStyleBackColor = true;
			this.radioButtonD.Visible = false;
			// 
			// radioButtonE
			// 
			this.radioButtonE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonE.Location = new System.Drawing.Point(750, 100);
			this.radioButtonE.Name = "radioButtonE";
			this.radioButtonE.Size = new System.Drawing.Size(75, 50);
			this.radioButtonE.TabIndex = 33;
			this.radioButtonE.TabStop = true;
			this.radioButtonE.Text = "E";
			this.radioButtonE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButtonE.UseVisualStyleBackColor = true;
			this.radioButtonE.Visible = false;
			// 
			// radioButtonF
			// 
			this.radioButtonF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonF.Location = new System.Drawing.Point(900, 100);
			this.radioButtonF.Name = "radioButtonF";
			this.radioButtonF.Size = new System.Drawing.Size(75, 50);
			this.radioButtonF.TabIndex = 34;
			this.radioButtonF.TabStop = true;
			this.radioButtonF.Text = "F";
			this.radioButtonF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButtonF.UseVisualStyleBackColor = true;
			this.radioButtonF.Visible = false;
			// 
			// checkBoxB
			// 
			this.checkBoxB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxB.Location = new System.Drawing.Point(300, 100);
			this.checkBoxB.Name = "checkBoxB";
			this.checkBoxB.Size = new System.Drawing.Size(75, 50);
			this.checkBoxB.TabIndex = 35;
			this.checkBoxB.Text = "B";
			this.checkBoxB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxB.UseVisualStyleBackColor = true;
			this.checkBoxB.Visible = false;
			// 
			// checkBoxC
			// 
			this.checkBoxC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxC.Location = new System.Drawing.Point(450, 100);
			this.checkBoxC.Name = "checkBoxC";
			this.checkBoxC.Size = new System.Drawing.Size(75, 50);
			this.checkBoxC.TabIndex = 36;
			this.checkBoxC.Text = "C";
			this.checkBoxC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxC.UseVisualStyleBackColor = true;
			this.checkBoxC.Visible = false;
			// 
			// checkBoxD
			// 
			this.checkBoxD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxD.Location = new System.Drawing.Point(600, 100);
			this.checkBoxD.Name = "checkBoxD";
			this.checkBoxD.Size = new System.Drawing.Size(75, 50);
			this.checkBoxD.TabIndex = 37;
			this.checkBoxD.Text = "D";
			this.checkBoxD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxD.UseVisualStyleBackColor = true;
			this.checkBoxD.Visible = false;
			// 
			// checkBoxE
			// 
			this.checkBoxE.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxE.Location = new System.Drawing.Point(750, 100);
			this.checkBoxE.Name = "checkBoxE";
			this.checkBoxE.Size = new System.Drawing.Size(75, 50);
			this.checkBoxE.TabIndex = 38;
			this.checkBoxE.Text = "E";
			this.checkBoxE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxE.UseVisualStyleBackColor = true;
			this.checkBoxE.Visible = false;
			// 
			// checkBoxF
			// 
			this.checkBoxF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxF.Location = new System.Drawing.Point(900, 100);
			this.checkBoxF.Name = "checkBoxF";
			this.checkBoxF.Size = new System.Drawing.Size(75, 50);
			this.checkBoxF.TabIndex = 39;
			this.checkBoxF.Text = "F";
			this.checkBoxF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxF.UseVisualStyleBackColor = true;
			this.checkBoxF.Visible = false;
			// 
			// answerGroupBox
			// 
			this.answerGroupBox.Controls.Add(this.radioButtonF);
			this.answerGroupBox.Controls.Add(this.radioButtonA);
			this.answerGroupBox.Controls.Add(this.radioButtonTrue);
			this.answerGroupBox.Controls.Add(this.radioButtonFalse);
			this.answerGroupBox.Controls.Add(this.checkBoxA);
			this.answerGroupBox.Controls.Add(this.radioButtonB);
			this.answerGroupBox.Controls.Add(this.checkBoxB);
			this.answerGroupBox.Controls.Add(this.radioButtonC);
			this.answerGroupBox.Controls.Add(this.radioButtonD);
			this.answerGroupBox.Controls.Add(this.checkBoxF);
			this.answerGroupBox.Controls.Add(this.radioButtonE);
			this.answerGroupBox.Controls.Add(this.checkBoxD);
			this.answerGroupBox.Controls.Add(this.checkBoxC);
			this.answerGroupBox.Controls.Add(this.checkBoxE);
			this.answerGroupBox.Controls.Add(this.answerRichTextBox);
			this.answerGroupBox.Location = new System.Drawing.Point(12, 518);
			this.answerGroupBox.Name = "answerGroupBox";
			this.answerGroupBox.Size = new System.Drawing.Size(1150, 230);
			this.answerGroupBox.TabIndex = 42;
			this.answerGroupBox.TabStop = false;
			this.answerGroupBox.Text = "第 {0} 题";
			// 
			// radioButtonTrue
			// 
			this.radioButtonTrue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonTrue.Location = new System.Drawing.Point(375, 99);
			this.radioButtonTrue.Name = "radioButtonTrue";
			this.radioButtonTrue.Size = new System.Drawing.Size(150, 50);
			this.radioButtonTrue.TabIndex = 23;
			this.radioButtonTrue.TabStop = true;
			this.radioButtonTrue.Text = "True";
			this.radioButtonTrue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButtonTrue.UseVisualStyleBackColor = true;
			this.radioButtonTrue.Visible = false;
			// 
			// radioButtonFalse
			// 
			this.radioButtonFalse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonFalse.Location = new System.Drawing.Point(675, 99);
			this.radioButtonFalse.Name = "radioButtonFalse";
			this.radioButtonFalse.Size = new System.Drawing.Size(150, 50);
			this.radioButtonFalse.TabIndex = 34;
			this.radioButtonFalse.TabStop = true;
			this.radioButtonFalse.Text = "False";
			this.radioButtonFalse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.radioButtonFalse.UseVisualStyleBackColor = true;
			this.radioButtonFalse.Visible = false;
			// 
			// answerRichTextBox
			// 
			this.answerRichTextBox.Location = new System.Drawing.Point(8, 35);
			this.answerRichTextBox.Name = "answerRichTextBox";
			this.answerRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.answerRichTextBox.Size = new System.Drawing.Size(1134, 185);
			this.answerRichTextBox.TabIndex = 41;
			this.answerRichTextBox.TabStop = false;
			this.answerRichTextBox.Text = "";
			// 
			// resultLabel
			// 
			this.resultLabel.AutoSize = true;
			this.resultLabel.BackColor = System.Drawing.Color.Transparent;
			this.resultLabel.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.resultLabel.ForeColor = System.Drawing.Color.Blue;
			this.resultLabel.Location = new System.Drawing.Point(996, 515);
			this.resultLabel.Name = "resultLabel";
			this.resultLabel.Size = new System.Drawing.Size(158, 65);
			this.resultLabel.TabIndex = 40;
			this.resultLabel.Text = "正确";
			this.resultLabel.Visible = false;
			// 
			// countLabel
			// 
			this.countLabel.AutoSize = true;
			this.countLabel.Location = new System.Drawing.Point(600, 775);
			this.countLabel.Name = "countLabel";
			this.countLabel.Size = new System.Drawing.Size(154, 24);
			this.countLabel.TabIndex = 43;
			this.countLabel.Text = "已完成 99/99";
			this.countLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// finishLabel
			// 
			this.finishLabel.AutoSize = true;
			this.finishLabel.BackColor = System.Drawing.Color.Transparent;
			this.finishLabel.Font = new System.Drawing.Font("华文行楷", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.finishLabel.ForeColor = System.Drawing.Color.Red;
			this.finishLabel.Location = new System.Drawing.Point(410, 219);
			this.finishLabel.Name = "finishLabel";
			this.finishLabel.Size = new System.Drawing.Size(277, 101);
			this.finishLabel.TabIndex = 42;
			this.finishLabel.Text = "100 分";
			this.finishLabel.Visible = false;
			// 
			// ExamForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1174, 829);
			this.Controls.Add(this.resultLabel);
			this.Controls.Add(this.finishLabel);
			this.Controls.Add(this.countLabel);
			this.Controls.Add(this.ContentRichTextBox);
			this.Controls.Add(this.timerLabel);
			this.Controls.Add(this.moduleComboBox);
			this.Controls.Add(this.examItemComboBox);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.submitButton);
			this.Controls.Add(this.prevButton);
			this.Controls.Add(this.answerGroupBox);
			this.Name = "ExamForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "模拟考试";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExamForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExamForm_FormClosed);
			this.Load += new System.EventHandler(this.ExamForm_Load);
			this.answerGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button prevButton;
		private System.Windows.Forms.Button submitButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.ComboBox examItemComboBox;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.ComboBox moduleComboBox;
		private System.Windows.Forms.Label timerLabel;
		private System.Windows.Forms.RichTextBox ContentRichTextBox;
		private System.Windows.Forms.CheckBox checkBoxA;
		private System.Windows.Forms.RadioButton radioButtonA;
		private System.Windows.Forms.RadioButton radioButtonB;
		private System.Windows.Forms.RadioButton radioButtonC;
		private System.Windows.Forms.RadioButton radioButtonD;
		private System.Windows.Forms.RadioButton radioButtonE;
		private System.Windows.Forms.RadioButton radioButtonF;
		private System.Windows.Forms.CheckBox checkBoxB;
		private System.Windows.Forms.CheckBox checkBoxC;
		private System.Windows.Forms.CheckBox checkBoxD;
		private System.Windows.Forms.CheckBox checkBoxE;
		private System.Windows.Forms.CheckBox checkBoxF;
		private System.Windows.Forms.GroupBox answerGroupBox;
		private System.Windows.Forms.RadioButton radioButtonTrue;
		private System.Windows.Forms.RadioButton radioButtonFalse;
		private System.Windows.Forms.Label countLabel;
		private System.Windows.Forms.Label resultLabel;
		private System.Windows.Forms.RichTextBox answerRichTextBox;
		private System.Windows.Forms.Label finishLabel;
	}
}