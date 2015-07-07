namespace MyScheduler
{
    partial class AddTV
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AirtimeLabel = new System.Windows.Forms.Label();
            this.TotalEpisodesNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.EpisodesLabel = new System.Windows.Forms.Label();
            this.WatchedLabel = new System.Windows.Forms.Label();
            this.WatchedEpisodesNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.URIlabel = new System.Windows.Forms.Label();
            this.URItextbox = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusListBox = new System.Windows.Forms.ListBox();
            this.dateClock1 = new MyScheduler.DateClock();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DescriptionTextbox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TotalEpisodesNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WatchedEpisodesNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.Location = new System.Drawing.Point(36, 3);
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.Size = new System.Drawing.Size(274, 20);
            this.TitleTextbox.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(3, 6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(30, 13);
            this.TitleLabel.TabIndex = 9;
            this.TitleLabel.Text = "Title:";
            // 
            // AirtimeLabel
            // 
            this.AirtimeLabel.AutoSize = true;
            this.AirtimeLabel.Location = new System.Drawing.Point(3, 59);
            this.AirtimeLabel.Name = "AirtimeLabel";
            this.AirtimeLabel.Size = new System.Drawing.Size(41, 13);
            this.AirtimeLabel.TabIndex = 11;
            this.AirtimeLabel.Text = "Airtime:";
            // 
            // TotalEpisodesNumUpDown
            // 
            this.TotalEpisodesNumUpDown.Location = new System.Drawing.Point(89, 88);
            this.TotalEpisodesNumUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TotalEpisodesNumUpDown.Name = "TotalEpisodesNumUpDown";
            this.TotalEpisodesNumUpDown.Size = new System.Drawing.Size(221, 20);
            this.TotalEpisodesNumUpDown.TabIndex = 3;
            this.TotalEpisodesNumUpDown.ValueChanged += new System.EventHandler(this.TotalEpisodesNumUpDown_ValueChanged);
            // 
            // EpisodesLabel
            // 
            this.EpisodesLabel.AutoSize = true;
            this.EpisodesLabel.Location = new System.Drawing.Point(6, 88);
            this.EpisodesLabel.Name = "EpisodesLabel";
            this.EpisodesLabel.Size = new System.Drawing.Size(80, 13);
            this.EpisodesLabel.TabIndex = 12;
            this.EpisodesLabel.Text = "Total Episodes:";
            // 
            // WatchedLabel
            // 
            this.WatchedLabel.AutoSize = true;
            this.WatchedLabel.Location = new System.Drawing.Point(6, 114);
            this.WatchedLabel.Name = "WatchedLabel";
            this.WatchedLabel.Size = new System.Drawing.Size(100, 13);
            this.WatchedLabel.TabIndex = 13;
            this.WatchedLabel.Text = "Watched Episodes:";
            // 
            // WatchedEpisodesNumUpDown
            // 
            this.WatchedEpisodesNumUpDown.Location = new System.Drawing.Point(112, 114);
            this.WatchedEpisodesNumUpDown.Name = "WatchedEpisodesNumUpDown";
            this.WatchedEpisodesNumUpDown.Size = new System.Drawing.Size(198, 20);
            this.WatchedEpisodesNumUpDown.TabIndex = 4;
            // 
            // URIlabel
            // 
            this.URIlabel.AutoSize = true;
            this.URIlabel.Location = new System.Drawing.Point(6, 143);
            this.URIlabel.Name = "URIlabel";
            this.URIlabel.Size = new System.Drawing.Size(29, 13);
            this.URIlabel.TabIndex = 14;
            this.URIlabel.Text = "URI:";
            // 
            // URItextbox
            // 
            this.URItextbox.Location = new System.Drawing.Point(39, 140);
            this.URItextbox.Name = "URItextbox";
            this.URItextbox.Size = new System.Drawing.Size(203, 20);
            this.URItextbox.TabIndex = 5;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(6, 163);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 13);
            this.StatusLabel.TabIndex = 15;
            this.StatusLabel.Text = "Status:";
            // 
            // StatusListBox
            // 
            this.StatusListBox.FormattingEnabled = true;
            this.StatusListBox.Location = new System.Drawing.Point(49, 163);
            this.StatusListBox.Name = "StatusListBox";
            this.StatusListBox.Size = new System.Drawing.Size(261, 56);
            this.StatusListBox.TabIndex = 6;
            // 
            // dateClock1
            // 
            this.dateClock1.Location = new System.Drawing.Point(47, 59);
            this.dateClock1.Name = "dateClock1";
            this.dateClock1.Size = new System.Drawing.Size(263, 23);
            this.dateClock1.TabIndex = 2;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(3, 246);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(145, 42);
            this.AcceptButton.TabIndex = 7;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(160, 246);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(150, 42);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Description:";
            // 
            // DescriptionTextbox
            // 
            this.DescriptionTextbox.Location = new System.Drawing.Point(69, 29);
            this.DescriptionTextbox.Name = "DescriptionTextbox";
            this.DescriptionTextbox.Size = new System.Drawing.Size(241, 20);
            this.DescriptionTextbox.TabIndex = 1;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(248, 138);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(62, 23);
            this.BrowseButton.TabIndex = 16;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // AddTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.DescriptionTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.StatusListBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.URIlabel);
            this.Controls.Add(this.URItextbox);
            this.Controls.Add(this.WatchedLabel);
            this.Controls.Add(this.WatchedEpisodesNumUpDown);
            this.Controls.Add(this.EpisodesLabel);
            this.Controls.Add(this.TotalEpisodesNumUpDown);
            this.Controls.Add(this.AirtimeLabel);
            this.Controls.Add(this.dateClock1);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TitleTextbox);
            this.Name = "AddTV";
            this.Size = new System.Drawing.Size(313, 291);
            this.Load += new System.EventHandler(this.AddTV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TotalEpisodesNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WatchedEpisodesNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label AirtimeLabel;
        private System.Windows.Forms.Label EpisodesLabel;
        private System.Windows.Forms.Label WatchedLabel;
        private System.Windows.Forms.Label URIlabel;
        private System.Windows.Forms.Label StatusLabel;
        public System.Windows.Forms.Button AcceptButton;
        public System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.TextBox TitleTextbox;
        public DateClock dateClock1;
        public System.Windows.Forms.NumericUpDown TotalEpisodesNumUpDown;
        public System.Windows.Forms.NumericUpDown WatchedEpisodesNumUpDown;
        public System.Windows.Forms.TextBox URItextbox;
        public System.Windows.Forms.ListBox StatusListBox;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox DescriptionTextbox;
        private System.Windows.Forms.Button BrowseButton;
    }
}
