namespace MyScheduler
{
    partial class MediaInfo
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.EpisodeCount = new System.Windows.Forms.Label();
            this.DashLabel = new System.Windows.Forms.Label();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.DownloadLabel = new System.Windows.Forms.Label();
            this.AirtimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(3, 3);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.SizeChanged += new System.EventHandler(this.Check_Label_Width);
            this.TitleLabel.MouseHover += new System.EventHandler(this.Label_Scroll);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(52, 3);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(37, 13);
            this.StatusLabel.TabIndex = 2;
            this.StatusLabel.Text = "Status";
            this.StatusLabel.SizeChanged += new System.EventHandler(this.Check_Label_Width);
            this.StatusLabel.MouseHover += new System.EventHandler(this.Label_Scroll);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(250, 18);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(48, 13);
            this.ProgressLabel.TabIndex = 3;
            this.ProgressLabel.Text = "Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(304, 18);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(316, 47);
            this.progressBar1.TabIndex = 4;
            // 
            // EpisodeCount
            // 
            this.EpisodeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EpisodeCount.AutoSize = true;
            this.EpisodeCount.Location = new System.Drawing.Point(263, 42);
            this.EpisodeCount.Name = "EpisodeCount";
            this.EpisodeCount.Size = new System.Drawing.Size(37, 13);
            this.EpisodeCount.TabIndex = 5;
            this.EpisodeCount.Text = "ep/Ep";
            // 
            // DashLabel
            // 
            this.DashLabel.AutoSize = true;
            this.DashLabel.Location = new System.Drawing.Point(36, 3);
            this.DashLabel.Name = "DashLabel";
            this.DashLabel.Size = new System.Drawing.Size(10, 13);
            this.DashLabel.TabIndex = 6;
            this.DashLabel.Text = "-";
            this.DashLabel.SizeChanged += new System.EventHandler(this.Check_Label_Width);
            this.DashLabel.MouseHover += new System.EventHandler(this.Label_Scroll);
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDescription.Location = new System.Drawing.Point(0, 19);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxDescription.Size = new System.Drawing.Size(244, 44);
            this.richTextBoxDescription.TabIndex = 7;
            this.richTextBoxDescription.Text = "";
            // 
            // DownloadLabel
            // 
            this.DownloadLabel.AutoSize = true;
            this.DownloadLabel.Location = new System.Drawing.Point(95, 3);
            this.DownloadLabel.Name = "DownloadLabel";
            this.DownloadLabel.Size = new System.Drawing.Size(55, 13);
            this.DownloadLabel.TabIndex = 8;
            this.DownloadLabel.Text = "Download";
            this.DownloadLabel.SizeChanged += new System.EventHandler(this.Check_Label_Width);
            this.DownloadLabel.MouseHover += new System.EventHandler(this.Label_Scroll);
            // 
            // AirtimeLabel
            // 
            this.AirtimeLabel.AutoSize = true;
            this.AirtimeLabel.Location = new System.Drawing.Point(156, 3);
            this.AirtimeLabel.Name = "AirtimeLabel";
            this.AirtimeLabel.Size = new System.Drawing.Size(38, 13);
            this.AirtimeLabel.TabIndex = 9;
            this.AirtimeLabel.Text = "Airtime";
            this.AirtimeLabel.SizeChanged += new System.EventHandler(this.Check_Label_Width);
            this.AirtimeLabel.MouseHover += new System.EventHandler(this.Label_Scroll);
            // 
            // MediaInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.AirtimeLabel);
            this.Controls.Add(this.DownloadLabel);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.DashLabel);
            this.Controls.Add(this.EpisodeCount);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "MediaInfo";
            this.Size = new System.Drawing.Size(618, 63);
            this.Load += new System.EventHandler(this.MediaInfo_Load);
            this.MouseHover += new System.EventHandler(this.Label_Scroll);
            this.Resize += new System.EventHandler(this.MediaInfo_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label DashLabel;
        public System.Windows.Forms.RichTextBox richTextBoxDescription;
        public System.Windows.Forms.Label TitleLabel;
        public System.Windows.Forms.Label StatusLabel;
        public System.Windows.Forms.Label ProgressLabel;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label EpisodeCount;
        private System.Windows.Forms.Label DownloadLabel;
        private System.Windows.Forms.Label AirtimeLabel;

    }
}
