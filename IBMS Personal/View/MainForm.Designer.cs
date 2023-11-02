namespace IBMS_Personal.View
{
	partial class MainForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.systemMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.subjectManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.itemManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.practiceMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.practiceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.practiceHisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.examMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.examMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.examHisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemMenu,
            this.practiceMenu,
            this.examMenu,
            this.helpMenu});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1174, 42);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			// 
			// systemMenu
			// 
			this.systemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subjectManageMenuItem,
            this.itemManageMenuItem,
            this.toolStripSeparator2,
            this.importMenuItem,
            this.exportMenuItem});
			this.systemMenu.Name = "systemMenu";
			this.systemMenu.Size = new System.Drawing.Size(169, 35);
			this.systemMenu.Text = "题库管理(&M)";
			// 
			// subjectManageMenuItem
			// 
			this.subjectManageMenuItem.Name = "subjectManageMenuItem";
			this.subjectManageMenuItem.Size = new System.Drawing.Size(273, 44);
			this.subjectManageMenuItem.Text = "科目管理(&S)";
			this.subjectManageMenuItem.Click += new System.EventHandler(this.ShowSubjectManageForm);
			// 
			// itemManageMenuItem
			// 
			this.itemManageMenuItem.Enabled = false;
			this.itemManageMenuItem.Name = "itemManageMenuItem";
			this.itemManageMenuItem.Size = new System.Drawing.Size(273, 44);
			this.itemManageMenuItem.Text = "试题管理(&I)";
			this.itemManageMenuItem.Click += new System.EventHandler(this.ShowItemManageForm);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(270, 6);
			// 
			// importMenuItem
			// 
			this.importMenuItem.Enabled = false;
			this.importMenuItem.Name = "importMenuItem";
			this.importMenuItem.Size = new System.Drawing.Size(273, 44);
			this.importMenuItem.Text = "导入...";
			this.importMenuItem.Click += new System.EventHandler(this.ImportMenuItem_Click);
			// 
			// exportMenuItem
			// 
			this.exportMenuItem.Enabled = false;
			this.exportMenuItem.Name = "exportMenuItem";
			this.exportMenuItem.Size = new System.Drawing.Size(273, 44);
			this.exportMenuItem.Text = "导出...";
			this.exportMenuItem.Click += new System.EventHandler(this.ExportMenuItem_Click);
			// 
			// practiceMenu
			// 
			this.practiceMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.practiceMenuItem,
            this.practiceHisMenuItem});
			this.practiceMenu.Enabled = false;
			this.practiceMenu.Name = "practiceMenu";
			this.practiceMenu.Size = new System.Drawing.Size(161, 38);
			this.practiceMenu.Text = "试题练习(&P)";
			// 
			// practiceMenuItem
			// 
			this.practiceMenuItem.Name = "practiceMenuItem";
			this.practiceMenuItem.Size = new System.Drawing.Size(359, 44);
			this.practiceMenuItem.Text = "配置练习(&P)";
			this.practiceMenuItem.Click += new System.EventHandler(this.ShowPracticeSettingForm);
			// 
			// practiceHisMenuItem
			// 
			this.practiceHisMenuItem.Name = "practiceHisMenuItem";
			this.practiceHisMenuItem.Size = new System.Drawing.Size(359, 44);
			this.practiceHisMenuItem.Text = "答题记录(&H)";
			this.practiceHisMenuItem.Click += new System.EventHandler(this.ShowPracticeLogForm);
			// 
			// examMenu
			// 
			this.examMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.examMenuItem,
            this.examHisMenuItem});
			this.examMenu.Enabled = false;
			this.examMenu.Name = "examMenu";
			this.examMenu.Size = new System.Drawing.Size(159, 38);
			this.examMenu.Text = "模拟考试(&E)";
			// 
			// examMenuItem
			// 
			this.examMenuItem.Name = "examMenuItem";
			this.examMenuItem.Size = new System.Drawing.Size(359, 44);
			this.examMenuItem.Text = "组卷考试(&E)";
			this.examMenuItem.Click += new System.EventHandler(this.ShowExamSettingForm);
			// 
			// examHisMenuItem
			// 
			this.examHisMenuItem.Name = "examHisMenuItem";
			this.examHisMenuItem.Size = new System.Drawing.Size(359, 44);
			this.examHisMenuItem.Text = "考试记录(&H)";
			this.examHisMenuItem.Click += new System.EventHandler(this.ShowExamLogForm);
			// 
			// helpMenu
			// 
			this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
			this.helpMenu.Name = "helpMenu";
			this.helpMenu.Size = new System.Drawing.Size(117, 35);
			this.helpMenu.Text = "帮助(&H)";
			// 
			// aboutMenuItem
			// 
			this.aboutMenuItem.Name = "aboutMenuItem";
			this.aboutMenuItem.Size = new System.Drawing.Size(246, 44);
			this.aboutMenuItem.Text = "关于(&A)...";
			this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::IBMS_Personal.Properties.Resources.background;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1174, 829);
			this.Controls.Add(this.menuStrip);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "通用题库管理系统";
			this.TransparencyKey = System.Drawing.Color.Transparent;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Repaint);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem systemMenu;
		private System.Windows.Forms.ToolStripMenuItem practiceMenu;
		private System.Windows.Forms.ToolStripMenuItem examMenu;
		private System.Windows.Forms.ToolStripMenuItem practiceMenuItem;
		private System.Windows.Forms.ToolStripMenuItem practiceHisMenuItem;
		private System.Windows.Forms.ToolStripMenuItem examMenuItem;
		private System.Windows.Forms.ToolStripMenuItem examHisMenuItem;
		private System.Windows.Forms.ToolStripMenuItem itemManageMenuItem;
		private System.Windows.Forms.ToolStripMenuItem subjectManageMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem importMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpMenu;
		private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
	}
}



