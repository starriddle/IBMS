namespace IBMS_Personal.View
{
	partial class ExamLogInfoForm
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
			this.scoreLabel = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.durationLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.startTimeLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.idLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.structureRichTextBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// scoreLabel
			// 
			this.scoreLabel.AutoSize = true;
			this.scoreLabel.Location = new System.Drawing.Point(150, 100);
			this.scoreLabel.Margin = new System.Windows.Forms.Padding(0);
			this.scoreLabel.Name = "scoreLabel";
			this.scoreLabel.Size = new System.Drawing.Size(190, 24);
			this.scoreLabel.TabIndex = 40;
			this.scoreLabel.Text = "{score}/{total}";
			this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(50, 100);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 24);
			this.label3.TabIndex = 33;
			this.label3.Text = "成绩：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// durationLabel
			// 
			this.durationLabel.AutoSize = true;
			this.durationLabel.Location = new System.Drawing.Point(550, 100);
			this.durationLabel.Margin = new System.Windows.Forms.Padding(0);
			this.durationLabel.Name = "durationLabel";
			this.durationLabel.Size = new System.Drawing.Size(226, 24);
			this.durationLabel.TabIndex = 39;
			this.durationLabel.Text = "{duration}/{total}";
			this.durationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(400, 100);
			this.label4.Margin = new System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(135, 24);
			this.label4.TabIndex = 34;
			this.label4.Text = "持续时间：";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// startTimeLabel
			// 
			this.startTimeLabel.AutoSize = true;
			this.startTimeLabel.Location = new System.Drawing.Point(550, 40);
			this.startTimeLabel.Margin = new System.Windows.Forms.Padding(0);
			this.startTimeLabel.Name = "startTimeLabel";
			this.startTimeLabel.Size = new System.Drawing.Size(238, 24);
			this.startTimeLabel.TabIndex = 38;
			this.startTimeLabel.Text = "yyyy-MM-dd hh:mm:ss";
			this.startTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(400, 40);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(135, 24);
			this.label2.TabIndex = 35;
			this.label2.Text = "考试时间：";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// idLabel
			// 
			this.idLabel.AutoSize = true;
			this.idLabel.Location = new System.Drawing.Point(150, 40);
			this.idLabel.Margin = new System.Windows.Forms.Padding(0);
			this.idLabel.Name = "idLabel";
			this.idLabel.Size = new System.Drawing.Size(58, 24);
			this.idLabel.TabIndex = 37;
			this.idLabel.Text = "{id}";
			this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(50, 40);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 24);
			this.label1.TabIndex = 36;
			this.label1.Text = "编号：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(50, 160);
			this.label5.Margin = new System.Windows.Forms.Padding(0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(135, 24);
			this.label5.TabIndex = 41;
			this.label5.Text = "考卷结构：";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(430, 550);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 50);
			this.button1.TabIndex = 43;
			this.button1.Text = "确定";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// structureRichTextBox
			// 
			this.structureRichTextBox.Location = new System.Drawing.Point(50, 200);
			this.structureRichTextBox.Name = "structureRichTextBox";
			this.structureRichTextBox.ReadOnly = true;
			this.structureRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.structureRichTextBox.Size = new System.Drawing.Size(870, 320);
			this.structureRichTextBox.TabIndex = 44;
			this.structureRichTextBox.Text = "";
			// 
			// ExamLogInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(974, 629);
			this.ControlBox = false;
			this.Controls.Add(this.structureRichTextBox);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.scoreLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.durationLabel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.startTimeLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.idLabel);
			this.Controls.Add(this.label1);
			this.Name = "ExamLogInfoForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "考试记录详情";
			this.Load += new System.EventHandler(this.ExamLogInfoForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label scoreLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label durationLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label startTimeLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label idLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox structureRichTextBox;
	}
}