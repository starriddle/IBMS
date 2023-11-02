namespace IBMS_Personal.View
{
	partial class ItemContentForm
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
			this.childGroupBox = new System.Windows.Forms.GroupBox();
			this.questionGroupBox = new System.Windows.Forms.GroupBox();
			this.questionChildRichTextBox = new System.Windows.Forms.RichTextBox();
			this.answerGroupBox = new System.Windows.Forms.GroupBox();
			this.radioButtonFalse = new System.Windows.Forms.RadioButton();
			this.radioButtonTrue = new System.Windows.Forms.RadioButton();
			this.checkBoxE = new System.Windows.Forms.CheckBox();
			this.checkBoxF = new System.Windows.Forms.CheckBox();
			this.checkBoxD = new System.Windows.Forms.CheckBox();
			this.checkBoxC = new System.Windows.Forms.CheckBox();
			this.checkBoxB = new System.Windows.Forms.CheckBox();
			this.checkBoxA = new System.Windows.Forms.CheckBox();
			this.textBoxF = new System.Windows.Forms.TextBox();
			this.textBoxE = new System.Windows.Forms.TextBox();
			this.textBoxD = new System.Windows.Forms.TextBox();
			this.textBoxC = new System.Windows.Forms.TextBox();
			this.textBoxB = new System.Windows.Forms.TextBox();
			this.radioButtonA = new System.Windows.Forms.RadioButton();
			this.textBoxA = new System.Windows.Forms.TextBox();
			this.radioButtonB = new System.Windows.Forms.RadioButton();
			this.radioButtonC = new System.Windows.Forms.RadioButton();
			this.radioButtonD = new System.Windows.Forms.RadioButton();
			this.radioButtonE = new System.Windows.Forms.RadioButton();
			this.radioButtonF = new System.Windows.Forms.RadioButton();
			this.answerRichTextBox = new System.Windows.Forms.RichTextBox();
			this.questionMainRichTextBox = new System.Windows.Forms.RichTextBox();
			this.itemChapterComboBox = new System.Windows.Forms.ComboBox();
			this.itemTypeComboBox = new System.Windows.Forms.ComboBox();
			this.labelChapter = new System.Windows.Forms.Label();
			this.labelType = new System.Windows.Forms.Label();
			this.manageTypeChapterButton = new System.Windows.Forms.Button();
			this.extendCheckBox = new System.Windows.Forms.CheckBox();
			this.labelQuestion = new System.Windows.Forms.Label();
			this.prevButton = new System.Windows.Forms.Button();
			this.nextButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.editButton = new System.Windows.Forms.Button();
			this.removeButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.submitButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.precisionLabel = new System.Windows.Forms.Label();
			this.childGroupBox.SuspendLayout();
			this.questionGroupBox.SuspendLayout();
			this.answerGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// childGroupBox
			// 
			this.childGroupBox.Controls.Add(this.questionGroupBox);
			this.childGroupBox.Controls.Add(this.answerGroupBox);
			this.childGroupBox.Location = new System.Drawing.Point(135, 350);
			this.childGroupBox.Name = "childGroupBox";
			this.childGroupBox.Size = new System.Drawing.Size(900, 465);
			this.childGroupBox.TabIndex = 12;
			this.childGroupBox.TabStop = false;
			this.childGroupBox.Text = "第{0}题  答题准确率：00/00";
			// 
			// questionGroupBox
			// 
			this.questionGroupBox.Controls.Add(this.questionChildRichTextBox);
			this.questionGroupBox.Location = new System.Drawing.Point(10, 30);
			this.questionGroupBox.Name = "questionGroupBox";
			this.questionGroupBox.Size = new System.Drawing.Size(880, 130);
			this.questionGroupBox.TabIndex = 36;
			this.questionGroupBox.TabStop = false;
			this.questionGroupBox.Text = "问题：";
			// 
			// questionChildRichTextBox
			// 
			this.questionChildRichTextBox.Location = new System.Drawing.Point(10, 30);
			this.questionChildRichTextBox.Name = "questionChildRichTextBox";
			this.questionChildRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.questionChildRichTextBox.Size = new System.Drawing.Size(860, 90);
			this.questionChildRichTextBox.TabIndex = 1;
			this.questionChildRichTextBox.TabStop = false;
			this.questionChildRichTextBox.Text = "";
			// 
			// answerGroupBox
			// 
			this.answerGroupBox.Controls.Add(this.radioButtonFalse);
			this.answerGroupBox.Controls.Add(this.radioButtonTrue);
			this.answerGroupBox.Controls.Add(this.checkBoxE);
			this.answerGroupBox.Controls.Add(this.checkBoxF);
			this.answerGroupBox.Controls.Add(this.checkBoxD);
			this.answerGroupBox.Controls.Add(this.checkBoxC);
			this.answerGroupBox.Controls.Add(this.checkBoxB);
			this.answerGroupBox.Controls.Add(this.checkBoxA);
			this.answerGroupBox.Controls.Add(this.textBoxF);
			this.answerGroupBox.Controls.Add(this.textBoxE);
			this.answerGroupBox.Controls.Add(this.textBoxD);
			this.answerGroupBox.Controls.Add(this.textBoxC);
			this.answerGroupBox.Controls.Add(this.textBoxB);
			this.answerGroupBox.Controls.Add(this.radioButtonA);
			this.answerGroupBox.Controls.Add(this.textBoxA);
			this.answerGroupBox.Controls.Add(this.radioButtonB);
			this.answerGroupBox.Controls.Add(this.radioButtonC);
			this.answerGroupBox.Controls.Add(this.radioButtonD);
			this.answerGroupBox.Controls.Add(this.radioButtonE);
			this.answerGroupBox.Controls.Add(this.radioButtonF);
			this.answerGroupBox.Controls.Add(this.answerRichTextBox);
			this.answerGroupBox.Location = new System.Drawing.Point(10, 165);
			this.answerGroupBox.Name = "answerGroupBox";
			this.answerGroupBox.Size = new System.Drawing.Size(880, 290);
			this.answerGroupBox.TabIndex = 35;
			this.answerGroupBox.TabStop = false;
			this.answerGroupBox.Text = "答案：";
			// 
			// radioButtonFalse
			// 
			this.radioButtonFalse.AutoSize = true;
			this.radioButtonFalse.Location = new System.Drawing.Point(600, 140);
			this.radioButtonFalse.Name = "radioButtonFalse";
			this.radioButtonFalse.Size = new System.Drawing.Size(53, 28);
			this.radioButtonFalse.TabIndex = 35;
			this.radioButtonFalse.Text = "F";
			this.radioButtonFalse.UseVisualStyleBackColor = true;
			// 
			// radioButtonTrue
			// 
			this.radioButtonTrue.AutoSize = true;
			this.radioButtonTrue.Location = new System.Drawing.Point(280, 140);
			this.radioButtonTrue.Name = "radioButtonTrue";
			this.radioButtonTrue.Size = new System.Drawing.Size(53, 28);
			this.radioButtonTrue.TabIndex = 34;
			this.radioButtonTrue.Text = "T";
			this.radioButtonTrue.UseVisualStyleBackColor = false;
			// 
			// checkBoxE
			// 
			this.checkBoxE.AutoSize = true;
			this.checkBoxE.Location = new System.Drawing.Point(10, 200);
			this.checkBoxE.Name = "checkBoxE";
			this.checkBoxE.Size = new System.Drawing.Size(54, 28);
			this.checkBoxE.TabIndex = 12;
			this.checkBoxE.TabStop = false;
			this.checkBoxE.Text = "E";
			this.checkBoxE.UseVisualStyleBackColor = true;
			// 
			// checkBoxF
			// 
			this.checkBoxF.AutoSize = true;
			this.checkBoxF.Location = new System.Drawing.Point(450, 200);
			this.checkBoxF.Name = "checkBoxF";
			this.checkBoxF.Size = new System.Drawing.Size(54, 28);
			this.checkBoxF.TabIndex = 13;
			this.checkBoxF.TabStop = false;
			this.checkBoxF.Text = "F";
			this.checkBoxF.UseVisualStyleBackColor = true;
			// 
			// checkBoxD
			// 
			this.checkBoxD.AutoSize = true;
			this.checkBoxD.Location = new System.Drawing.Point(450, 115);
			this.checkBoxD.Name = "checkBoxD";
			this.checkBoxD.Size = new System.Drawing.Size(54, 28);
			this.checkBoxD.TabIndex = 11;
			this.checkBoxD.TabStop = false;
			this.checkBoxD.Text = "D";
			this.checkBoxD.UseVisualStyleBackColor = true;
			// 
			// checkBoxC
			// 
			this.checkBoxC.AutoSize = true;
			this.checkBoxC.Location = new System.Drawing.Point(10, 115);
			this.checkBoxC.Name = "checkBoxC";
			this.checkBoxC.Size = new System.Drawing.Size(54, 28);
			this.checkBoxC.TabIndex = 10;
			this.checkBoxC.TabStop = false;
			this.checkBoxC.Text = "C";
			this.checkBoxC.UseVisualStyleBackColor = true;
			// 
			// checkBoxB
			// 
			this.checkBoxB.AutoSize = true;
			this.checkBoxB.Location = new System.Drawing.Point(450, 30);
			this.checkBoxB.Name = "checkBoxB";
			this.checkBoxB.Size = new System.Drawing.Size(54, 28);
			this.checkBoxB.TabIndex = 9;
			this.checkBoxB.TabStop = false;
			this.checkBoxB.Text = "B";
			this.checkBoxB.UseVisualStyleBackColor = true;
			// 
			// checkBoxA
			// 
			this.checkBoxA.AutoSize = true;
			this.checkBoxA.Location = new System.Drawing.Point(10, 30);
			this.checkBoxA.Name = "checkBoxA";
			this.checkBoxA.Size = new System.Drawing.Size(54, 28);
			this.checkBoxA.TabIndex = 8;
			this.checkBoxA.TabStop = false;
			this.checkBoxA.Text = "A";
			this.checkBoxA.UseVisualStyleBackColor = true;
			// 
			// textBoxF
			// 
			this.textBoxF.Location = new System.Drawing.Point(510, 200);
			this.textBoxF.Multiline = true;
			this.textBoxF.Name = "textBoxF";
			this.textBoxF.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxF.Size = new System.Drawing.Size(360, 80);
			this.textBoxF.TabIndex = 19;
			this.textBoxF.TabStop = false;
			this.textBoxF.Text = "选项F";
			// 
			// textBoxE
			// 
			this.textBoxE.Location = new System.Drawing.Point(70, 200);
			this.textBoxE.Multiline = true;
			this.textBoxE.Name = "textBoxE";
			this.textBoxE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxE.Size = new System.Drawing.Size(360, 80);
			this.textBoxE.TabIndex = 18;
			this.textBoxE.TabStop = false;
			this.textBoxE.Text = "选项E";
			// 
			// textBoxD
			// 
			this.textBoxD.Location = new System.Drawing.Point(510, 115);
			this.textBoxD.Multiline = true;
			this.textBoxD.Name = "textBoxD";
			this.textBoxD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxD.Size = new System.Drawing.Size(360, 80);
			this.textBoxD.TabIndex = 17;
			this.textBoxD.TabStop = false;
			this.textBoxD.Text = "选项D";
			// 
			// textBoxC
			// 
			this.textBoxC.Location = new System.Drawing.Point(70, 115);
			this.textBoxC.Multiline = true;
			this.textBoxC.Name = "textBoxC";
			this.textBoxC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxC.Size = new System.Drawing.Size(360, 80);
			this.textBoxC.TabIndex = 16;
			this.textBoxC.TabStop = false;
			this.textBoxC.Text = "选项C";
			// 
			// textBoxB
			// 
			this.textBoxB.Location = new System.Drawing.Point(510, 30);
			this.textBoxB.Multiline = true;
			this.textBoxB.Name = "textBoxB";
			this.textBoxB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxB.Size = new System.Drawing.Size(360, 80);
			this.textBoxB.TabIndex = 15;
			this.textBoxB.TabStop = false;
			this.textBoxB.Text = "选项B";
			// 
			// radioButtonA
			// 
			this.radioButtonA.AutoSize = true;
			this.radioButtonA.Location = new System.Drawing.Point(10, 30);
			this.radioButtonA.Name = "radioButtonA";
			this.radioButtonA.Size = new System.Drawing.Size(53, 28);
			this.radioButtonA.TabIndex = 2;
			this.radioButtonA.TabStop = true;
			this.radioButtonA.Text = "A";
			this.radioButtonA.UseVisualStyleBackColor = true;
			// 
			// textBoxA
			// 
			this.textBoxA.Location = new System.Drawing.Point(70, 30);
			this.textBoxA.Multiline = true;
			this.textBoxA.Name = "textBoxA";
			this.textBoxA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxA.Size = new System.Drawing.Size(360, 80);
			this.textBoxA.TabIndex = 14;
			this.textBoxA.TabStop = false;
			this.textBoxA.Text = "选项A";
			// 
			// radioButtonB
			// 
			this.radioButtonB.AutoSize = true;
			this.radioButtonB.Location = new System.Drawing.Point(450, 30);
			this.radioButtonB.Name = "radioButtonB";
			this.radioButtonB.Size = new System.Drawing.Size(53, 28);
			this.radioButtonB.TabIndex = 3;
			this.radioButtonB.TabStop = true;
			this.radioButtonB.Text = "B";
			this.radioButtonB.UseVisualStyleBackColor = true;
			// 
			// radioButtonC
			// 
			this.radioButtonC.AutoSize = true;
			this.radioButtonC.Location = new System.Drawing.Point(10, 115);
			this.radioButtonC.Name = "radioButtonC";
			this.radioButtonC.Size = new System.Drawing.Size(53, 28);
			this.radioButtonC.TabIndex = 4;
			this.radioButtonC.TabStop = true;
			this.radioButtonC.Text = "C";
			this.radioButtonC.UseVisualStyleBackColor = true;
			// 
			// radioButtonD
			// 
			this.radioButtonD.AutoSize = true;
			this.radioButtonD.Location = new System.Drawing.Point(450, 115);
			this.radioButtonD.Name = "radioButtonD";
			this.radioButtonD.Size = new System.Drawing.Size(53, 28);
			this.radioButtonD.TabIndex = 5;
			this.radioButtonD.TabStop = true;
			this.radioButtonD.Text = "D";
			this.radioButtonD.UseVisualStyleBackColor = true;
			// 
			// radioButtonE
			// 
			this.radioButtonE.AutoSize = true;
			this.radioButtonE.Location = new System.Drawing.Point(10, 200);
			this.radioButtonE.Name = "radioButtonE";
			this.radioButtonE.Size = new System.Drawing.Size(53, 28);
			this.radioButtonE.TabIndex = 6;
			this.radioButtonE.TabStop = true;
			this.radioButtonE.Text = "E";
			this.radioButtonE.UseVisualStyleBackColor = true;
			// 
			// radioButtonF
			// 
			this.radioButtonF.AutoSize = true;
			this.radioButtonF.Location = new System.Drawing.Point(450, 200);
			this.radioButtonF.Name = "radioButtonF";
			this.radioButtonF.Size = new System.Drawing.Size(53, 28);
			this.radioButtonF.TabIndex = 7;
			this.radioButtonF.TabStop = true;
			this.radioButtonF.Text = "F";
			this.radioButtonF.UseVisualStyleBackColor = true;
			// 
			// answerRichTextBox
			// 
			this.answerRichTextBox.Location = new System.Drawing.Point(20, 40);
			this.answerRichTextBox.Name = "answerRichTextBox";
			this.answerRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.answerRichTextBox.Size = new System.Drawing.Size(840, 240);
			this.answerRichTextBox.TabIndex = 2;
			this.answerRichTextBox.TabStop = false;
			this.answerRichTextBox.Text = "";
			// 
			// questionMainRichTextBox
			// 
			this.questionMainRichTextBox.Location = new System.Drawing.Point(25, 120);
			this.questionMainRichTextBox.Name = "questionMainRichTextBox";
			this.questionMainRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.questionMainRichTextBox.Size = new System.Drawing.Size(1120, 200);
			this.questionMainRichTextBox.TabIndex = 13;
			this.questionMainRichTextBox.Text = "";
			// 
			// itemChapterComboBox
			// 
			this.itemChapterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.itemChapterComboBox.FormattingEnabled = true;
			this.itemChapterComboBox.Location = new System.Drawing.Point(415, 26);
			this.itemChapterComboBox.Name = "itemChapterComboBox";
			this.itemChapterComboBox.Size = new System.Drawing.Size(300, 32);
			this.itemChapterComboBox.TabIndex = 17;
			// 
			// itemTypeComboBox
			// 
			this.itemTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.itemTypeComboBox.FormattingEnabled = true;
			this.itemTypeComboBox.Location = new System.Drawing.Point(110, 26);
			this.itemTypeComboBox.Name = "itemTypeComboBox";
			this.itemTypeComboBox.Size = new System.Drawing.Size(160, 32);
			this.itemTypeComboBox.TabIndex = 16;
			this.itemTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemTypeComboBox_SelectedIndexChanged);
			// 
			// labelChapter
			// 
			this.labelChapter.AutoSize = true;
			this.labelChapter.Location = new System.Drawing.Point(330, 34);
			this.labelChapter.Name = "labelChapter";
			this.labelChapter.Size = new System.Drawing.Size(70, 24);
			this.labelChapter.TabIndex = 15;
			this.labelChapter.Text = "章节:";
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(25, 34);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(70, 24);
			this.labelType.TabIndex = 14;
			this.labelType.Text = "题型:";
			// 
			// manageTypeChapterButton
			// 
			this.manageTypeChapterButton.Location = new System.Drawing.Point(815, 26);
			this.manageTypeChapterButton.Name = "manageTypeChapterButton";
			this.manageTypeChapterButton.Size = new System.Drawing.Size(100, 40);
			this.manageTypeChapterButton.TabIndex = 19;
			this.manageTypeChapterButton.Text = "管 理";
			this.manageTypeChapterButton.UseVisualStyleBackColor = true;
			this.manageTypeChapterButton.Click += new System.EventHandler(this.ItemChapterButton_Click);
			// 
			// extendCheckBox
			// 
			this.extendCheckBox.AutoSize = true;
			this.extendCheckBox.Location = new System.Drawing.Point(1055, 30);
			this.extendCheckBox.Name = "extendCheckBox";
			this.extendCheckBox.Size = new System.Drawing.Size(90, 28);
			this.extendCheckBox.TabIndex = 20;
			this.extendCheckBox.Text = "扩展";
			this.extendCheckBox.UseVisualStyleBackColor = true;
			this.extendCheckBox.CheckedChanged += new System.EventHandler(this.ExtendCheckBox_CheckedChanged);
			// 
			// labelQuestion
			// 
			this.labelQuestion.AutoSize = true;
			this.labelQuestion.Location = new System.Drawing.Point(25, 90);
			this.labelQuestion.Name = "labelQuestion";
			this.labelQuestion.Size = new System.Drawing.Size(70, 24);
			this.labelQuestion.TabIndex = 21;
			this.labelQuestion.Text = "问题:";
			// 
			// prevButton
			// 
			this.prevButton.Location = new System.Drawing.Point(5, 405);
			this.prevButton.Name = "prevButton";
			this.prevButton.Size = new System.Drawing.Size(120, 60);
			this.prevButton.TabIndex = 24;
			this.prevButton.TabStop = false;
			this.prevButton.Text = "上一题";
			this.prevButton.UseVisualStyleBackColor = true;
			this.prevButton.Click += new System.EventHandler(this.PrevButton_Click);
			// 
			// nextButton
			// 
			this.nextButton.Location = new System.Drawing.Point(1045, 405);
			this.nextButton.Name = "nextButton";
			this.nextButton.Size = new System.Drawing.Size(120, 60);
			this.nextButton.TabIndex = 26;
			this.nextButton.TabStop = false;
			this.nextButton.Text = "下一题";
			this.nextButton.UseVisualStyleBackColor = true;
			this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.BackColor = System.Drawing.Color.Tomato;
			this.deleteButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.deleteButton.Location = new System.Drawing.Point(5, 735);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(120, 60);
			this.deleteButton.TabIndex = 30;
			this.deleteButton.TabStop = false;
			this.deleteButton.Text = "删 除";
			this.deleteButton.UseVisualStyleBackColor = false;
			this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
			// 
			// editButton
			// 
			this.editButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.editButton.Location = new System.Drawing.Point(1045, 735);
			this.editButton.Name = "editButton";
			this.editButton.Size = new System.Drawing.Size(120, 60);
			this.editButton.TabIndex = 31;
			this.editButton.TabStop = false;
			this.editButton.Text = "编 辑";
			this.editButton.UseVisualStyleBackColor = true;
			this.editButton.Click += new System.EventHandler(this.EditButton_Click);
			// 
			// removeButton
			// 
			this.removeButton.BackColor = System.Drawing.Color.Salmon;
			this.removeButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.removeButton.Location = new System.Drawing.Point(5, 515);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(120, 60);
			this.removeButton.TabIndex = 32;
			this.removeButton.TabStop = false;
			this.removeButton.Text = "移 除";
			this.removeButton.UseVisualStyleBackColor = false;
			this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// addButton
			// 
			this.addButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.addButton.Location = new System.Drawing.Point(1045, 515);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(120, 60);
			this.addButton.TabIndex = 33;
			this.addButton.TabStop = false;
			this.addButton.Text = "添 加";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// submitButton
			// 
			this.submitButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.submitButton.Location = new System.Drawing.Point(1045, 625);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(120, 60);
			this.submitButton.TabIndex = 34;
			this.submitButton.TabStop = false;
			this.submitButton.Text = "确 定";
			this.submitButton.UseVisualStyleBackColor = true;
			this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.BackColor = System.Drawing.Color.LightSalmon;
			this.cancelButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cancelButton.Location = new System.Drawing.Point(5, 625);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(120, 60);
			this.cancelButton.TabIndex = 35;
			this.cancelButton.TabStop = false;
			this.cancelButton.Text = "取 消";
			this.cancelButton.UseVisualStyleBackColor = false;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// precisionLabel
			// 
			this.precisionLabel.Location = new System.Drawing.Point(866, 90);
			this.precisionLabel.Name = "precisionLabel";
			this.precisionLabel.Size = new System.Drawing.Size(279, 24);
			this.precisionLabel.TabIndex = 36;
			this.precisionLabel.Text = "答题准确率：00/00";
			this.precisionLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ItemContentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1174, 829);
			this.Controls.Add(this.precisionLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.submitButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.removeButton);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.nextButton);
			this.Controls.Add(this.prevButton);
			this.Controls.Add(this.labelQuestion);
			this.Controls.Add(this.extendCheckBox);
			this.Controls.Add(this.manageTypeChapterButton);
			this.Controls.Add(this.itemChapterComboBox);
			this.Controls.Add(this.itemTypeComboBox);
			this.Controls.Add(this.labelChapter);
			this.Controls.Add(this.labelType);
			this.Controls.Add(this.questionMainRichTextBox);
			this.Controls.Add(this.childGroupBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ItemContentForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "试题信息";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemContentForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemContentForm_FormClosed);
			this.Load += new System.EventHandler(this.ItemContentForm_Load);
			this.childGroupBox.ResumeLayout(false);
			this.questionGroupBox.ResumeLayout(false);
			this.answerGroupBox.ResumeLayout(false);
			this.answerGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox childGroupBox;
		private System.Windows.Forms.TextBox textBoxA;
		private System.Windows.Forms.CheckBox checkBoxF;
		private System.Windows.Forms.CheckBox checkBoxE;
		private System.Windows.Forms.CheckBox checkBoxD;
		private System.Windows.Forms.CheckBox checkBoxC;
		private System.Windows.Forms.CheckBox checkBoxB;
		private System.Windows.Forms.CheckBox checkBoxA;
		private System.Windows.Forms.RadioButton radioButtonF;
		private System.Windows.Forms.RadioButton radioButtonE;
		private System.Windows.Forms.RadioButton radioButtonD;
		private System.Windows.Forms.RadioButton radioButtonC;
		private System.Windows.Forms.RadioButton radioButtonB;
		private System.Windows.Forms.RadioButton radioButtonA;
		private System.Windows.Forms.RichTextBox questionMainRichTextBox;
		private System.Windows.Forms.ComboBox itemChapterComboBox;
		private System.Windows.Forms.ComboBox itemTypeComboBox;
		private System.Windows.Forms.Label labelChapter;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.Button manageTypeChapterButton;
		private System.Windows.Forms.CheckBox extendCheckBox;
		private System.Windows.Forms.Label labelQuestion;
		private System.Windows.Forms.Button prevButton;
		private System.Windows.Forms.Button nextButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.Button editButton;
		private System.Windows.Forms.GroupBox answerGroupBox;
		private System.Windows.Forms.GroupBox questionGroupBox;
		private System.Windows.Forms.TextBox textBoxC;
		private System.Windows.Forms.TextBox textBoxB;
		private System.Windows.Forms.TextBox textBoxF;
		private System.Windows.Forms.TextBox textBoxE;
		private System.Windows.Forms.TextBox textBoxD;
		private System.Windows.Forms.RadioButton radioButtonFalse;
		private System.Windows.Forms.RadioButton radioButtonTrue;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button submitButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label precisionLabel;
		private System.Windows.Forms.RichTextBox questionChildRichTextBox;
		private System.Windows.Forms.RichTextBox answerRichTextBox;
	}
}