namespace IBMS_Personal.View
{
	partial class PracticeSettingForm
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
			this.itemTypeComboBox = new System.Windows.Forms.ComboBox();
			this.itemChapterComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButtonPrecision = new System.Windows.Forms.RadioButton();
			this.radioButtonCorrect = new System.Windows.Forms.RadioButton();
			this.radioButtonTotal = new System.Windows.Forms.RadioButton();
			this.radioButtonRandom = new System.Windows.Forms.RadioButton();
			this.radioButtonOriginal = new System.Windows.Forms.RadioButton();
			this.confirmButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// itemTypeComboBox
			// 
			this.itemTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.itemTypeComboBox.FormattingEnabled = true;
			this.itemTypeComboBox.Location = new System.Drawing.Point(54, 125);
			this.itemTypeComboBox.Name = "itemTypeComboBox";
			this.itemTypeComboBox.Size = new System.Drawing.Size(300, 32);
			this.itemTypeComboBox.TabIndex = 0;
			this.itemTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemTypeComboBox_SelectedIndexChanged);
			// 
			// itemChapterComboBox
			// 
			this.itemChapterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.itemChapterComboBox.FormattingEnabled = true;
			this.itemChapterComboBox.Location = new System.Drawing.Point(54, 250);
			this.itemChapterComboBox.Name = "itemChapterComboBox";
			this.itemChapterComboBox.Size = new System.Drawing.Size(300, 32);
			this.itemChapterComboBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "题型：";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.itemChapterComboBox);
			this.groupBox1.Controls.Add(this.itemTypeComboBox);
			this.groupBox1.Location = new System.Drawing.Point(50, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(450, 450);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "试题选择";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(50, 200);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "章节：";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButtonPrecision);
			this.groupBox2.Controls.Add(this.radioButtonCorrect);
			this.groupBox2.Controls.Add(this.radioButtonTotal);
			this.groupBox2.Controls.Add(this.radioButtonRandom);
			this.groupBox2.Controls.Add(this.radioButtonOriginal);
			this.groupBox2.Location = new System.Drawing.Point(700, 50);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(350, 450);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "练习顺序";
			// 
			// radioButtonPrecision
			// 
			this.radioButtonPrecision.AutoSize = true;
			this.radioButtonPrecision.Location = new System.Drawing.Point(100, 300);
			this.radioButtonPrecision.Name = "radioButtonPrecision";
			this.radioButtonPrecision.Size = new System.Drawing.Size(161, 28);
			this.radioButtonPrecision.TabIndex = 4;
			this.radioButtonPrecision.Text = "答题正确率";
			this.radioButtonPrecision.UseVisualStyleBackColor = true;
			// 
			// radioButtonCorrect
			// 
			this.radioButtonCorrect.AutoSize = true;
			this.radioButtonCorrect.Location = new System.Drawing.Point(100, 225);
			this.radioButtonCorrect.Name = "radioButtonCorrect";
			this.radioButtonCorrect.Size = new System.Drawing.Size(137, 28);
			this.radioButtonCorrect.TabIndex = 3;
			this.radioButtonCorrect.Text = "答对次数";
			this.radioButtonCorrect.UseVisualStyleBackColor = true;
			// 
			// radioButtonTotal
			// 
			this.radioButtonTotal.AutoSize = true;
			this.radioButtonTotal.Location = new System.Drawing.Point(100, 150);
			this.radioButtonTotal.Name = "radioButtonTotal";
			this.radioButtonTotal.Size = new System.Drawing.Size(137, 28);
			this.radioButtonTotal.TabIndex = 2;
			this.radioButtonTotal.Text = "答题次数";
			this.radioButtonTotal.UseVisualStyleBackColor = true;
			// 
			// radioButtonRandom
			// 
			this.radioButtonRandom.AutoSize = true;
			this.radioButtonRandom.Checked = true;
			this.radioButtonRandom.Location = new System.Drawing.Point(100, 375);
			this.radioButtonRandom.Name = "radioButtonRandom";
			this.radioButtonRandom.Size = new System.Drawing.Size(137, 28);
			this.radioButtonRandom.TabIndex = 1;
			this.radioButtonRandom.TabStop = true;
			this.radioButtonRandom.Text = "随机次序";
			this.radioButtonRandom.UseVisualStyleBackColor = true;
			// 
			// radioButtonOriginal
			// 
			this.radioButtonOriginal.AutoSize = true;
			this.radioButtonOriginal.Location = new System.Drawing.Point(100, 75);
			this.radioButtonOriginal.Name = "radioButtonOriginal";
			this.radioButtonOriginal.Size = new System.Drawing.Size(137, 28);
			this.radioButtonOriginal.TabIndex = 0;
			this.radioButtonOriginal.Text = "原始次序";
			this.radioButtonOriginal.UseVisualStyleBackColor = true;
			// 
			// confirmButton
			// 
			this.confirmButton.Enabled = false;
			this.confirmButton.Location = new System.Drawing.Point(525, 150);
			this.confirmButton.Name = "confirmButton";
			this.confirmButton.Size = new System.Drawing.Size(150, 75);
			this.confirmButton.TabIndex = 5;
			this.confirmButton.Text = "开始练习";
			this.confirmButton.UseVisualStyleBackColor = true;
			this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(525, 325);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(150, 75);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "取  消";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// PracticeSettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1174, 729);
			this.ControlBox = false;
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.confirmButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "PracticeSettingForm";
			this.Text = "练习配置";
			this.Load += new System.EventHandler(this.PracticeSettingForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox itemTypeComboBox;
		private System.Windows.Forms.ComboBox itemChapterComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButtonPrecision;
		private System.Windows.Forms.RadioButton radioButtonCorrect;
		private System.Windows.Forms.RadioButton radioButtonTotal;
		private System.Windows.Forms.RadioButton radioButtonRandom;
		private System.Windows.Forms.RadioButton radioButtonOriginal;
		private System.Windows.Forms.Button confirmButton;
		private System.Windows.Forms.Button cancelButton;
	}
}