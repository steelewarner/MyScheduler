namespace MyScheduler
{
    partial class SettingsForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Form");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Calendar");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("List");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Media");
            this.LoadUserCheckbox = new System.Windows.Forms.CheckBox();
            this.LoadUserBrowseButton = new System.Windows.Forms.Button();
            this.LoadUserTextbox = new System.Windows.Forms.TextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.GeneralSettings = new System.Windows.Forms.Panel();
            this.FontStyleButton = new System.Windows.Forms.Button();
            this.FontLabel = new System.Windows.Forms.Label();
            this.fgColorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bgColorButton = new System.Windows.Forms.Button();
            this.bgColorLabel = new System.Windows.Forms.Label();
            this.GeneralSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadUserCheckbox
            // 
            this.LoadUserCheckbox.AutoSize = true;
            this.LoadUserCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LoadUserCheckbox.Location = new System.Drawing.Point(3, 5);
            this.LoadUserCheckbox.Name = "LoadUserCheckbox";
            this.LoadUserCheckbox.Size = new System.Drawing.Size(117, 17);
            this.LoadUserCheckbox.TabIndex = 1;
            this.LoadUserCheckbox.Text = "Load user on setup";
            this.LoadUserCheckbox.UseVisualStyleBackColor = true;
            this.LoadUserCheckbox.CheckedChanged += new System.EventHandler(this.LoadUserCheckbox_CheckedChanged);
            // 
            // LoadUserBrowseButton
            // 
            this.LoadUserBrowseButton.Location = new System.Drawing.Point(214, 3);
            this.LoadUserBrowseButton.Name = "LoadUserBrowseButton";
            this.LoadUserBrowseButton.Size = new System.Drawing.Size(51, 20);
            this.LoadUserBrowseButton.TabIndex = 3;
            this.LoadUserBrowseButton.Text = "Browse";
            this.LoadUserBrowseButton.UseVisualStyleBackColor = true;
            this.LoadUserBrowseButton.Visible = false;
            this.LoadUserBrowseButton.Click += new System.EventHandler(this.LoadUserBrowseButton_Click);
            // 
            // LoadUserTextbox
            // 
            this.LoadUserTextbox.Location = new System.Drawing.Point(128, 3);
            this.LoadUserTextbox.Name = "LoadUserTextbox";
            this.LoadUserTextbox.Size = new System.Drawing.Size(80, 20);
            this.LoadUserTextbox.TabIndex = 2;
            this.LoadUserTextbox.Visible = false;
            // 
            // OKbutton
            // 
            this.OKbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OKbutton.Location = new System.Drawing.Point(150, 204);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 4;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 15);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "FormNode";
            treeNode1.Text = "Form";
            treeNode2.Name = "GeneralNode";
            treeNode2.Text = "General";
            treeNode3.Name = "CalendarNode";
            treeNode3.Text = "Calendar";
            treeNode4.Name = "ListNode";
            treeNode4.Text = "List";
            treeNode5.Name = "MediaNode";
            treeNode5.Text = "Media";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(99, 179);
            this.treeView1.TabIndex = 5;
            // 
            // GeneralSettings
            // 
            this.GeneralSettings.Controls.Add(this.FontStyleButton);
            this.GeneralSettings.Controls.Add(this.FontLabel);
            this.GeneralSettings.Controls.Add(this.fgColorButton);
            this.GeneralSettings.Controls.Add(this.label1);
            this.GeneralSettings.Controls.Add(this.bgColorButton);
            this.GeneralSettings.Controls.Add(this.bgColorLabel);
            this.GeneralSettings.Controls.Add(this.LoadUserTextbox);
            this.GeneralSettings.Controls.Add(this.LoadUserCheckbox);
            this.GeneralSettings.Controls.Add(this.LoadUserBrowseButton);
            this.GeneralSettings.Location = new System.Drawing.Point(117, 16);
            this.GeneralSettings.Name = "GeneralSettings";
            this.GeneralSettings.Size = new System.Drawing.Size(265, 178);
            this.GeneralSettings.TabIndex = 6;
            // 
            // FontStyleButton
            // 
            this.FontStyleButton.Location = new System.Drawing.Point(128, 87);
            this.FontStyleButton.Name = "FontStyleButton";
            this.FontStyleButton.Size = new System.Drawing.Size(75, 23);
            this.FontStyleButton.TabIndex = 9;
            this.FontStyleButton.Text = "Font";
            this.FontStyleButton.UseVisualStyleBackColor = true;
            this.FontStyleButton.Click += new System.EventHandler(this.FontStyleButton_Click);
            // 
            // FontLabel
            // 
            this.FontLabel.AutoSize = true;
            this.FontLabel.Location = new System.Drawing.Point(3, 91);
            this.FontLabel.Name = "FontLabel";
            this.FontLabel.Size = new System.Drawing.Size(54, 13);
            this.FontLabel.TabIndex = 8;
            this.FontLabel.Text = "Font Style";
            // 
            // fgColorButton
            // 
            this.fgColorButton.Location = new System.Drawing.Point(128, 58);
            this.fgColorButton.Name = "fgColorButton";
            this.fgColorButton.Size = new System.Drawing.Size(75, 23);
            this.fgColorButton.TabIndex = 7;
            this.fgColorButton.Text = "Color";
            this.fgColorButton.UseVisualStyleBackColor = true;
            this.fgColorButton.Click += new System.EventHandler(this.fgColorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Form Fore Color";
            // 
            // bgColorButton
            // 
            this.bgColorButton.Location = new System.Drawing.Point(128, 29);
            this.bgColorButton.Name = "bgColorButton";
            this.bgColorButton.Size = new System.Drawing.Size(75, 23);
            this.bgColorButton.TabIndex = 5;
            this.bgColorButton.Text = "Color";
            this.bgColorButton.UseVisualStyleBackColor = true;
            this.bgColorButton.Click += new System.EventHandler(this.bgColorButton_Click);
            // 
            // bgColorLabel
            // 
            this.bgColorLabel.AutoSize = true;
            this.bgColorLabel.Location = new System.Drawing.Point(3, 34);
            this.bgColorLabel.Name = "bgColorLabel";
            this.bgColorLabel.Size = new System.Drawing.Size(85, 13);
            this.bgColorLabel.TabIndex = 4;
            this.bgColorLabel.Text = "Form Back Color";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OKbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 239);
            this.Controls.Add(this.GeneralSettings);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.OKbutton);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.GeneralSettings.ResumeLayout(false);
            this.GeneralSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox LoadUserCheckbox;
        private System.Windows.Forms.Button LoadUserBrowseButton;
        private System.Windows.Forms.TextBox LoadUserTextbox;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel GeneralSettings;
        private System.Windows.Forms.Button bgColorButton;
        private System.Windows.Forms.Label bgColorLabel;
        private System.Windows.Forms.Button FontStyleButton;
        private System.Windows.Forms.Label FontLabel;
        private System.Windows.Forms.Button fgColorButton;
        private System.Windows.Forms.Label label1;
    }
}