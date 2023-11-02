namespace IBMS_Personal.View
{
	partial class PracticeForm
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
			this.infoLabel = new System.Windows.Forms.Label();
			this.submitButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.resultLabel = new System.Windows.Forms.Label();
			this.answerGroupBox = new System.Windows.Forms.GroupBox();
			this.radioButtonFalse = new System.Windows.Forms.RadioButton();
			this.radioButtonTrue = new System.Windows.Forms.RadioButton();
			this.checkBoxF = new System.Windows.Forms.CheckBox();
			this.checkBoxE = new System.Windows.Forms.CheckBox();
			this.checkBoxD = new System.Windows.Forms.CheckBox();
			this.checkBoxC = new System.Windows.Forms.CheckBox();
			this.checkBoxB = new System.Windows.Forms.CheckBox();
			this.checkBoxA = new System.Windows.Forms.CheckBox();
			this.radioButtonF = new System.Windows.Forms.RadioButton();
			this.radioButtonE = new System.Windows.Forms.RadioButton();
			this.radioButtonD = new System.Windows.Forms.RadioButton();
			this.radioButtonC = new System.Windows.Forms.RadioButton();
			this.radioButtonB = new System.Windows.Forms.RadioButton();
			this.radioButtonA = new System.Windows.Forms.RadioButton();
			this.answerRichTextBox1 = new System.Windows.Forms.RichTextBox();
			this.answerLabel1 = new System.Windows.Forms.Label();
			this.answerLabel2 = new System.Windows.Forms.Label();
			this.contentRichTextBox = new System.Windows.Forms.RichTextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.indexToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.totalIndexToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.answerRichTextBox2 = new System.Windows.Forms.RichTextBox();
			this.precisionLabel = new System.Windows.Forms.Label();
			this.answerGroupBox.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.Location = new System.Drawing.Point(5, 5);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(58, 24);
			this.infoLabel.TabIndex = 0;
			this.infoLabel.Text = "信息";
			// 
			// submitButton
			// 
			this.submitButton.Enabled = false;
			this.submitButton.Location = new System.Drawing.Point(1010, 425);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(120, 60);
			this.submitButton.TabIndex = 2;
			this.submitButton.Text = "提  交";
			this.submitButton.UseVisualStyleBackColor = true;
			this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Enabled = false;
			this.nextButton.Location = new System.Drawing.Point(1010, 715);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(120, 60);
			this.nextButton.TabIndex = 3;
			this.nextButton.Text = "下一题";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// resultLabel
			// 
			this.resultLabel.AutoSize = true;
			this.resultLabel.BackColor = System.Drawing.SystemColors.Control;
			this.resultLabel.Font = new System.Drawing.Font("华文隶书", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.resultLabel.ForeColor = System.Drawing.Color.Blue;
			this.resultLabel.Location = new System.Drawing.Point(972, 575);
			this.resultLabel.Name = "resultLabel";
			this.resultLabel.Size = new System.Drawing.Size(158, 65);
			this.resultLabel.TabIndex = 6;
			this.resultLabel.Text = "正确";
			this.resultLabel.Visible = false;
			// 
			// answerGroupBox
			// 
			this.answerGroupBox.Controls.Add(this.radioButtonFalse);
			this.answerGroupBox.Controls.Add(this.radioButtonTrue);
			this.answerGroupBox.Controls.Add(this.checkBoxF);
			this.answerGroupBox.Controls.Add(this.checkBoxE);
			this.answerGroupBox.Controls.Add(this.checkBoxD);
			this.answerGroupBox.Controls.Add(this.checkBoxC);
			this.answerGroupBox.Controls.Add(this.checkBoxB);
			this.answerGroupBox.Controls.Add(this.checkBoxA);
			this.answerGroupBox.Controls.Add(this.radioButtonF);
			this.answerGroupBox.Controls.Add(this.radioButtonE);
			this.answerGroupBox.Controls.Add(this.radioButtonD);
			this.answerGroupBox.Controls.Add(this.radioButtonC);
			this.answerGroupBox.Controls.Add(this.radioButtonB);
			this.answerGroupBox.Controls.Add(this.radioButtonA);
			this.answerGroupBox.Controls.Add(this.answerRichTextBox1);
			this.answerGroupBox.Location = new System.Drawing.Point(50, 425);
			this.answerGroupBox.Name = "answerGroupBox";
			this.answerGroupBox.Size = new System.Drawing.Size(900, 160);
			this.answerGroupBox.TabIndex = 7;
			this.answerGroupBox.TabStop = false;
			// 
			// radioButtonFalse
			// 
			this.radioButtonFalse.AutoSize = true;
			this.radioButtonFalse.Location = new System.Drawing.Point(550, 70);
			this.radioButtonFalse.Name = "radioButtonFalse";
			this.radioButtonFalse.Size = new System.Drawing.Size(101, 28);
			this.radioButtonFalse.TabIndex = 15;
			this.radioButtonFalse.TabStop = true;
			this.radioButtonFalse.Text = "False";
			this.radioButtonFalse.UseVisualStyleBackColor = true;
			this.radioButtonFalse.Visible = false;
			// 
			// radioButtonTrue
			// 
			this.radioButtonTrue.AutoSize = true;
			this.radioButtonTrue.Location = new System.Drawing.Point(250, 70);
			this.radioButtonTrue.Name = "radioButtonTrue";
			this.radioButtonTrue.Size = new System.Drawing.Size(89, 28);
			this.radioButtonTrue.TabIndex = 14;
			this.radioButtonTrue.TabStop = true;
			this.radioButtonTrue.Text = "True";
			this.radioButtonTrue.UseVisualStyleBackColor = true;
			this.radioButtonTrue.Visible = false;
			// 
			// checkBoxF
			// 
			this.checkBoxF.AutoSize = true;
			this.checkBoxF.Location = new System.Drawing.Point(650, 70);
			this.checkBoxF.Name = "checkBoxF";
			this.checkBoxF.Size = new System.Drawing.Size(54, 28);
			this.checkBoxF.TabIndex = 13;
			this.checkBoxF.Text = "F";
			this.checkBoxF.UseVisualStyleBackColor = true;
			this.checkBoxF.Visible = false;
			// 
			// checkBoxE
			// 
			this.checkBoxE.AutoSize = true;
			this.checkBoxE.Location = new System.Drawing.Point(550, 70);
			this.checkBoxE.Name = "checkBoxE";
			this.checkBoxE.Size = new System.Drawing.Size(54, 28);
			this.checkBoxE.TabIndex = 12;
			this.checkBoxE.Text = "E";
			this.checkBoxE.UseVisualStyleBackColor = true;
			this.checkBoxE.Visible = false;
			// 
			// checkBoxD
			// 
			this.checkBoxD.AutoSize = true;
			this.checkBoxD.Location = new System.Drawing.Point(450, 70);
			this.checkBoxD.Name = "checkBoxD";
			this.checkBoxD.Size = new System.Drawing.Size(54, 28);
			this.checkBoxD.TabIndex = 11;
			this.checkBoxD.Text = "D";
			this.checkBoxD.UseVisualStyleBackColor = true;
			this.checkBoxD.Visible = false;
			// 
			// checkBoxC
			// 
			this.checkBoxC.AutoSize = true;
			this.checkBoxC.Location = new System.Drawing.Point(350, 70);
			this.checkBoxC.Name = "checkBoxC";
			this.checkBoxC.Size = new System.Drawing.Size(54, 28);
			this.checkBoxC.TabIndex = 10;
			this.checkBoxC.Text = "C";
			this.checkBoxC.UseVisualStyleBackColor = true;
			this.checkBoxC.Visible = false;
			// 
			// checkBoxB
			// 
			this.checkBoxB.AutoSize = true;
			this.checkBoxB.Location = new System.Drawing.Point(250, 70);
			this.checkBoxB.Name = "checkBoxB";
			this.checkBoxB.Size = new System.Drawing.Size(54, 28);
			this.checkBoxB.TabIndex = 9;
			this.checkBoxB.Text = "B";
			this.checkBoxB.UseVisualStyleBackColor = true;
			this.checkBoxB.Visible = false;
			// 
			// checkBoxA
			// 
			this.checkBoxA.AutoSize = true;
			this.checkBoxA.Location = new System.Drawing.Point(150, 70);
			this.checkBoxA.Name = "checkBoxA";
			this.checkBoxA.Size = new System.Drawing.Size(54, 28);
			this.checkBoxA.TabIndex = 8;
			this.checkBoxA.Text = "A";
			this.checkBoxA.UseVisualStyleBackColor = true;
			this.checkBoxA.Visible = false;
			// 
			// radioButtonF
			// 
			this.radioButtonF.AutoSize = true;
			this.radioButtonF.Location = new System.Drawing.Point(650, 70);
			this.radioButtonF.Name = "radioButtonF";
			this.radioButtonF.Size = new System.Drawing.Size(53, 28);
			this.radioButtonF.TabIndex = 7;
			this.radioButtonF.TabStop = true;
			this.radioButtonF.Text = "F";
			this.radioButtonF.UseVisualStyleBackColor = true;
			this.radioButtonF.Visible = false;
			// 
			// radioButtonE
			// 
			this.radioButtonE.AutoSize = true;
			this.radioButtonE.Location = new System.Drawing.Point(550, 70);
			this.radioButtonE.Name = "radioButtonE";
			this.radioButtonE.Size = new System.Drawing.Size(53, 28);
			this.radioButtonE.TabIndex = 6;
			this.radioButtonE.TabStop = true;
			this.radioButtonE.Text = "E";
			this.radioButtonE.UseVisualStyleBackColor = true;
			this.radioButtonE.Visible = false;
			// 
			// radioButtonD
			// 
			this.radioButtonD.AutoSize = true;
			this.radioButtonD.Location = new System.Drawing.Point(450, 70);
			this.radioButtonD.Name = "radioButtonD";
			this.radioButtonD.Size = new System.Drawing.Size(53, 28);
			this.radioButtonD.TabIndex = 5;
			this.radioButtonD.TabStop = true;
			this.radioButtonD.Text = "D";
			this.radioButtonD.UseVisualStyleBackColor = true;
			this.radioButtonD.Visible = false;
			// 
			// radioButtonC
			// 
			this.radioButtonC.AutoSize = true;
			this.radioButtonC.Location = new System.Drawing.Point(350, 70);
			this.radioButtonC.Name = "radioButtonC";
			this.radioButtonC.Size = new System.Drawing.Size(53, 28);
			this.radioButtonC.TabIndex = 4;
			this.radioButtonC.TabStop = true;
			this.radioButtonC.Text = "C";
			this.radioButtonC.UseVisualStyleBackColor = true;
			this.radioButtonC.Visible = false;
			// 
			// radioButtonB
			// 
			this.radioButtonB.AutoSize = true;
			this.radioButtonB.Location = new System.Drawing.Point(250, 70);
			this.radioButtonB.Name = "radioButtonB";
			this.radioButtonB.Size = new System.Drawing.Size(53, 28);
			this.radioButtonB.TabIndex = 3;
			this.radioButtonB.TabStop = true;
			this.radioButtonB.Text = "B";
			this.radioButtonB.UseVisualStyleBackColor = true;
			this.radioButtonB.Visible = false;
			// 
			// radioButtonA
			// 
			this.radioButtonA.AutoSize = true;
			this.radioButtonA.Location = new System.Drawing.Point(150, 70);
			this.radioButtonA.Name = "radioButtonA";
			this.radioButtonA.Size = new System.Drawing.Size(53, 28);
			this.radioButtonA.TabIndex = 2;
			this.radioButtonA.TabStop = true;
			this.radioButtonA.Text = "A";
			this.radioButtonA.UseVisualStyleBackColor = true;
			this.radioButtonA.Visible = false;
			// 
			// answerRichTextBox1
			// 
			this.answerRichTextBox1.Location = new System.Drawing.Point(10, 20);
			this.answerRichTextBox1.Name = "answerRichTextBox1";
			this.answerRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.answerRichTextBox1.Size = new System.Drawing.Size(880, 120);
			this.answerRichTextBox1.TabIndex = 13;
			this.answerRichTextBox1.TabStop = false;
			this.answerRichTextBox1.Text = "";
			// 
			// answerLabel1
			// 
			this.answerLabel1.AutoSize = true;
			this.answerLabel1.Location = new System.Drawing.Point(50, 395);
			this.answerLabel1.Name = "answerLabel1";
			this.answerLabel1.Size = new System.Drawing.Size(142, 24);
			this.answerLabel1.TabIndex = 8;
			this.answerLabel1.Text = "第 n 小题：";
			this.answerLabel1.Visible = false;
			// 
			// answerLabel2
			// 
			this.answerLabel2.AutoSize = true;
			this.answerLabel2.Location = new System.Drawing.Point(50, 605);
			this.answerLabel2.Name = "answerLabel2";
			this.answerLabel2.Size = new System.Drawing.Size(130, 24);
			this.answerLabel2.TabIndex = 9;
			this.answerLabel2.Text = "参考答案：";
			this.answerLabel2.Visible = false;
			// 
			// contentRichTextBox
			// 
			this.contentRichTextBox.Location = new System.Drawing.Point(50, 75);
			this.contentRichTextBox.Name = "contentRichTextBox";
			this.contentRichTextBox.ReadOnly = true;
			this.contentRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.contentRichTextBox.Size = new System.Drawing.Size(1080, 300);
			this.contentRichTextBox.TabIndex = 10;
			this.contentRichTextBox.Text = "";
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.indexToolStripStatusLabel,
            this.totalIndexToolStripStatusLabel});
			this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.statusStrip1.Location = new System.Drawing.Point(0, 795);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1174, 34);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 11;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// indexToolStripStatusLabel
			// 
			this.indexToolStripStatusLabel.Font = new System.Drawing.Font("宋体", 9F);
			this.indexToolStripStatusLabel.Name = "indexToolStripStatusLabel";
			this.indexToolStripStatusLabel.Size = new System.Drawing.Size(166, 24);
			this.indexToolStripStatusLabel.Text = "第 {0}/{1} 题";
			this.indexToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// totalIndexToolStripStatusLabel
			// 
			this.totalIndexToolStripStatusLabel.Font = new System.Drawing.Font("宋体", 9F);
			this.totalIndexToolStripStatusLabel.Name = "totalIndexToolStripStatusLabel";
			this.totalIndexToolStripStatusLabel.Size = new System.Drawing.Size(190, 24);
			this.totalIndexToolStripStatusLabel.Text = "总第 {0}/{1} 题";
			this.totalIndexToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// answerRichTextBox2
			// 
			this.answerRichTextBox2.Location = new System.Drawing.Point(50, 635);
			this.answerRichTextBox2.Name = "answerRichTextBox2";
			this.answerRichTextBox2.ReadOnly = true;
			this.answerRichTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.answerRichTextBox2.Size = new System.Drawing.Size(900, 140);
			this.answerRichTextBox2.TabIndex = 12;
			this.answerRichTextBox2.Text = "";
			this.answerRichTextBox2.Visible = false;
			// 
			// precisionLabel
			// 
			this.precisionLabel.Location = new System.Drawing.Point(730, 48);
			this.precisionLabel.Name = "precisionLabel";
			this.precisionLabel.Size = new System.Drawing.Size(400, 24);
			this.precisionLabel.TabIndex = 13;
			this.precisionLabel.Text = "历史答题正确率 {0}/{1}";
			this.precisionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// PracticeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1174, 829);
			this.Controls.Add(this.precisionLabel);
			this.Controls.Add(this.answerGroupBox);
			this.Controls.Add(this.answerRichTextBox2);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.contentRichTextBox);
			this.Controls.Add(this.answerLabel2);
			this.Controls.Add(this.answerLabel1);
			this.Controls.Add(this.resultLabel);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.submitButton);
			this.Controls.Add(this.infoLabel);
			this.Name = "PracticeForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "试题练习";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PracticeForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PracticeForm_FormClosed);
			this.Load += new System.EventHandler(this.PracticeForm_Load);
			this.answerGroupBox.ResumeLayout(false);
			this.answerGroupBox.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.Button submitButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Label resultLabel;
		private System.Windows.Forms.GroupBox answerGroupBox;
		private System.Windows.Forms.RadioButton radioButtonD;
		private System.Windows.Forms.RadioButton radioButtonC;
		private System.Windows.Forms.RadioButton radioButtonB;
		private System.Windows.Forms.RadioButton radioButtonA;
		private System.Windows.Forms.CheckBox checkBoxA;
		private System.Windows.Forms.RadioButton radioButtonF;
		private System.Windows.Forms.RadioButton radioButtonE;
		private System.Windows.Forms.CheckBox checkBoxF;
		private System.Windows.Forms.CheckBox checkBoxE;
		private System.Windows.Forms.CheckBox checkBoxD;
		private System.Windows.Forms.CheckBox checkBoxC;
		private System.Windows.Forms.CheckBox checkBoxB;
		private System.Windows.Forms.Label answerLabel1;
		private System.Windows.Forms.Label answerLabel2;
		private System.Windows.Forms.RichTextBox contentRichTextBox;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel indexToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel totalIndexToolStripStatusLabel;
		private System.Windows.Forms.RichTextBox answerRichTextBox2;
		private System.Windows.Forms.RichTextBox answerRichTextBox1;
		private System.Windows.Forms.RadioButton radioButtonFalse;
		private System.Windows.Forms.RadioButton radioButtonTrue;
		private System.Windows.Forms.Label precisionLabel;
	}
}