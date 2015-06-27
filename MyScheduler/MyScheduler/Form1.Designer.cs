﻿namespace MyScheduler
{
    partial class MySchedulerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Anime");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("TV Shows");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Movies");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MySchedulerForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CalendarTab = new System.Windows.Forms.TabPage();
            this.TaskCalendar = new System.Windows.Forms.DataGridView();
            this.TaskCalendarContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleTab = new System.Windows.Forms.TabPage();
            this.ListViewSchedule = new System.Windows.Forms.ListView();
            this.MediaTab = new System.Windows.Forms.TabPage();
            this.MediaList = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Toolbar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MonthLabel = new System.Windows.Forms.Label();
            this.NextMonthButton = new System.Windows.Forms.Button();
            this.PreviousMonthButton = new System.Windows.Forms.Button();
            this.mediaInfo1 = new MyScheduler.MediaInfo();
            this.AddMediacontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAnimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTVShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.CalendarTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskCalendar)).BeginInit();
            this.TaskCalendarContextMenuStrip.SuspendLayout();
            this.ScheduleTab.SuspendLayout();
            this.MediaTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Toolbar.SuspendLayout();
            this.AddMediacontextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CalendarTab);
            this.tabControl1.Controls.Add(this.ScheduleTab);
            this.tabControl1.Controls.Add(this.MediaTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 454);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // CalendarTab
            // 
            this.CalendarTab.Controls.Add(this.TaskCalendar);
            this.CalendarTab.Location = new System.Drawing.Point(4, 22);
            this.CalendarTab.Name = "CalendarTab";
            this.CalendarTab.Padding = new System.Windows.Forms.Padding(3);
            this.CalendarTab.Size = new System.Drawing.Size(620, 428);
            this.CalendarTab.TabIndex = 0;
            this.CalendarTab.Text = "Calendar";
            this.CalendarTab.UseVisualStyleBackColor = true;
            this.CalendarTab.Click += new System.EventHandler(this.TabCalendar_Click);
            // 
            // TaskCalendar
            // 
            this.TaskCalendar.AllowUserToAddRows = false;
            this.TaskCalendar.AllowUserToDeleteRows = false;
            this.TaskCalendar.AllowUserToResizeColumns = false;
            this.TaskCalendar.AllowUserToResizeRows = false;
            this.TaskCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TaskCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskCalendar.ContextMenuStrip = this.TaskCalendarContextMenuStrip;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TaskCalendar.DefaultCellStyle = dataGridViewCellStyle1;
            this.TaskCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskCalendar.Location = new System.Drawing.Point(3, 3);
            this.TaskCalendar.Name = "TaskCalendar";
            this.TaskCalendar.ReadOnly = true;
            this.TaskCalendar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TaskCalendar.RowHeadersVisible = false;
            this.TaskCalendar.RowTemplate.Height = 75;
            this.TaskCalendar.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TaskCalendar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TaskCalendar.Size = new System.Drawing.Size(614, 422);
            this.TaskCalendar.TabIndex = 0;
            this.TaskCalendar.Resize += new System.EventHandler(this.TaskCalendar_Resize);
            // 
            // TaskCalendarContextMenuStrip
            // 
            this.TaskCalendarContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTaskToolStripMenuItem,
            this.removeTaskToolStripMenuItem});
            this.TaskCalendarContextMenuStrip.Name = "TaskCalendarContextMenuStrip";
            this.TaskCalendarContextMenuStrip.Size = new System.Drawing.Size(145, 48);
            // 
            // addTaskToolStripMenuItem
            // 
            this.addTaskToolStripMenuItem.Name = "addTaskToolStripMenuItem";
            this.addTaskToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addTaskToolStripMenuItem.Text = "Add Task";
            this.addTaskToolStripMenuItem.Click += new System.EventHandler(this.addTaskToolStripMenuItem_Click);
            // 
            // removeTaskToolStripMenuItem
            // 
            this.removeTaskToolStripMenuItem.Name = "removeTaskToolStripMenuItem";
            this.removeTaskToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.removeTaskToolStripMenuItem.Text = "Remove Task";
            this.removeTaskToolStripMenuItem.Click += new System.EventHandler(this.removeTaskToolStripMenuItem_Click);
            // 
            // ScheduleTab
            // 
            this.ScheduleTab.Controls.Add(this.ListViewSchedule);
            this.ScheduleTab.Location = new System.Drawing.Point(4, 22);
            this.ScheduleTab.Name = "ScheduleTab";
            this.ScheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScheduleTab.Size = new System.Drawing.Size(620, 428);
            this.ScheduleTab.TabIndex = 1;
            this.ScheduleTab.Text = "Schedule";
            this.ScheduleTab.UseVisualStyleBackColor = true;
            this.ScheduleTab.Click += new System.EventHandler(this.ScheduleTab_Click);
            // 
            // ListViewSchedule
            // 
            this.ListViewSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewSchedule.GridLines = true;
            this.ListViewSchedule.Location = new System.Drawing.Point(3, 3);
            this.ListViewSchedule.Name = "ListViewSchedule";
            this.ListViewSchedule.Size = new System.Drawing.Size(614, 422);
            this.ListViewSchedule.TabIndex = 0;
            this.ListViewSchedule.UseCompatibleStateImageBehavior = false;
            this.ListViewSchedule.View = System.Windows.Forms.View.Details;
            this.ListViewSchedule.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewSchedule_ColumnClick);
            // 
            // MediaTab
            // 
            this.MediaTab.Controls.Add(this.mediaInfo1);
            this.MediaTab.Controls.Add(this.MediaList);
            this.MediaTab.Controls.Add(this.panel1);
            this.MediaTab.Location = new System.Drawing.Point(4, 22);
            this.MediaTab.Name = "MediaTab";
            this.MediaTab.Size = new System.Drawing.Size(620, 428);
            this.MediaTab.TabIndex = 2;
            this.MediaTab.Text = "Media";
            this.MediaTab.UseVisualStyleBackColor = true;
            // 
            // MediaList
            // 
            this.MediaList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MediaList.ContextMenuStrip = this.AddMediacontextMenuStrip;
            this.MediaList.Location = new System.Drawing.Point(0, 0);
            this.MediaList.Name = "MediaList";
            treeNode1.Name = "AnimeNode";
            treeNode1.Text = "Anime";
            treeNode2.Name = "TV";
            treeNode2.Text = "TV Shows";
            treeNode3.Name = "Movies";
            treeNode3.Text = "Movies";
            this.MediaList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.MediaList.Size = new System.Drawing.Size(120, 363);
            this.MediaList.TabIndex = 1;
            this.MediaList.Tag = "";
            this.MediaList.Resize += new System.EventHandler(this.MediaList_Resize);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(121, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 361);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(500, 359);
            this.webBrowser1.TabIndex = 0;
            // 
            // Toolbar
            // 
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(628, 24);
            this.Toolbar.TabIndex = 1;
            this.Toolbar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStripMenuItem,
            this.loadUserToolStripMenuItem,
            this.saveUserToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newUserToolStripMenuItem.Text = "Create User";
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // loadUserToolStripMenuItem
            // 
            this.loadUserToolStripMenuItem.Name = "loadUserToolStripMenuItem";
            this.loadUserToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.loadUserToolStripMenuItem.Text = "Load User Schedule";
            this.loadUserToolStripMenuItem.Click += new System.EventHandler(this.loadUserToolStripMenuItem_Click);
            // 
            // saveUserToolStripMenuItem
            // 
            this.saveUserToolStripMenuItem.Name = "saveUserToolStripMenuItem";
            this.saveUserToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveUserToolStripMenuItem.Text = "Save User Schedule";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // MonthLabel
            // 
            this.MonthLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MonthLabel.AutoSize = true;
            this.MonthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthLabel.Location = new System.Drawing.Point(295, 0);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Size = new System.Drawing.Size(47, 17);
            this.MonthLabel.TabIndex = 1;
            this.MonthLabel.Tag = "int";
            this.MonthLabel.Text = "Month";
            this.MonthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NextMonthButton
            // 
            this.NextMonthButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NextMonthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextMonthButton.Location = new System.Drawing.Point(348, 2);
            this.NextMonthButton.Name = "NextMonthButton";
            this.NextMonthButton.Size = new System.Drawing.Size(58, 17);
            this.NextMonthButton.TabIndex = 2;
            this.NextMonthButton.Text = "Next";
            this.NextMonthButton.UseVisualStyleBackColor = true;
            // 
            // PreviousMonthButton
            // 
            this.PreviousMonthButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PreviousMonthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousMonthButton.Location = new System.Drawing.Point(231, 2);
            this.PreviousMonthButton.Name = "PreviousMonthButton";
            this.PreviousMonthButton.Size = new System.Drawing.Size(58, 17);
            this.PreviousMonthButton.TabIndex = 3;
            this.PreviousMonthButton.Text = "Previous";
            this.PreviousMonthButton.UseVisualStyleBackColor = true;
            // 
            // mediaInfo1
            // 
            this.mediaInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mediaInfo1.Location = new System.Drawing.Point(0, 363);
            this.mediaInfo1.Name = "mediaInfo1";
            this.mediaInfo1.Size = new System.Drawing.Size(620, 65);
            this.mediaInfo1.TabIndex = 2;
            // 
            // AddMediacontextMenuStrip
            // 
            this.AddMediacontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAnimeToolStripMenuItem,
            this.addTVShowToolStripMenuItem,
            this.addMovieToolStripMenuItem});
            this.AddMediacontextMenuStrip.Name = "AddMediacontextMenuStrip";
            this.AddMediacontextMenuStrip.Size = new System.Drawing.Size(153, 92);
            // 
            // addAnimeToolStripMenuItem
            // 
            this.addAnimeToolStripMenuItem.Name = "addAnimeToolStripMenuItem";
            this.addAnimeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addAnimeToolStripMenuItem.Text = "Add Anime";
            this.addAnimeToolStripMenuItem.Click += new System.EventHandler(this.addAnimeToolStripMenuItem_Click);
            // 
            // addTVShowToolStripMenuItem
            // 
            this.addTVShowToolStripMenuItem.Name = "addTVShowToolStripMenuItem";
            this.addTVShowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addTVShowToolStripMenuItem.Text = "Add TV Show";
            // 
            // addMovieToolStripMenuItem
            // 
            this.addMovieToolStripMenuItem.Name = "addMovieToolStripMenuItem";
            this.addMovieToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addMovieToolStripMenuItem.Text = "Add Movie";
            // 
            // MySchedulerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 478);
            this.Controls.Add(this.PreviousMonthButton);
            this.Controls.Add(this.NextMonthButton);
            this.Controls.Add(this.MonthLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Toolbar;
            this.Name = "MySchedulerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Scheduler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.MySchedulerForm_Resize);
            this.tabControl1.ResumeLayout(false);
            this.CalendarTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaskCalendar)).EndInit();
            this.TaskCalendarContextMenuStrip.ResumeLayout(false);
            this.ScheduleTab.ResumeLayout(false);
            this.MediaTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.AddMediacontextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CalendarTab;
        private System.Windows.Forms.TabPage ScheduleTab;
        private System.Windows.Forms.MenuStrip Toolbar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.DataGridView TaskCalendar;
        private System.Windows.Forms.TabPage MediaTab;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label MonthLabel;
        private System.Windows.Forms.Button NextMonthButton;
        private System.Windows.Forms.Button PreviousMonthButton;
        private System.Windows.Forms.ContextMenuStrip TaskCalendarContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTaskToolStripMenuItem;
        private System.Windows.Forms.ListView ListViewSchedule;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView MediaList;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private MediaInfo mediaInfo1;
        private System.Windows.Forms.ContextMenuStrip AddMediacontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addAnimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTVShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMovieToolStripMenuItem;
    }
}

