namespace MyScheduler
{
    partial class AddMovie
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
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TitleTextbox = new System.Windows.Forms.TextBox();
            this.DescripitionTextbox = new System.Windows.Forms.TextBox();
            this.StatusListBox = new System.Windows.Forms.ListBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.RuntimeMinutes = new System.Windows.Forms.NumericUpDown();
            this.RuntimeLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RuntimeMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(3, 10);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 34);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Description";
            // 
            // TitleTextbox
            // 
            this.TitleTextbox.Location = new System.Drawing.Point(44, 7);
            this.TitleTextbox.MaxLength = 200;
            this.TitleTextbox.Name = "TitleTextbox";
            this.TitleTextbox.Size = new System.Drawing.Size(260, 20);
            this.TitleTextbox.TabIndex = 2;
            // 
            // DescripitionTextbox
            // 
            this.DescripitionTextbox.Location = new System.Drawing.Point(69, 31);
            this.DescripitionTextbox.Name = "DescripitionTextbox";
            this.DescripitionTextbox.Size = new System.Drawing.Size(235, 20);
            this.DescripitionTextbox.TabIndex = 3;
            // 
            // StatusListBox
            // 
            this.StatusListBox.FormattingEnabled = true;
            this.StatusListBox.Location = new System.Drawing.Point(44, 83);
            this.StatusListBox.Name = "StatusListBox";
            this.StatusListBox.Size = new System.Drawing.Size(260, 56);
            this.StatusListBox.TabIndex = 8;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(3, 83);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 13);
            this.StatusLabel.TabIndex = 17;
            this.StatusLabel.Text = "Status:";
            // 
            // RuntimeMinutes
            // 
            this.RuntimeMinutes.Location = new System.Drawing.Point(100, 57);
            this.RuntimeMinutes.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.RuntimeMinutes.Name = "RuntimeMinutes";
            this.RuntimeMinutes.Size = new System.Drawing.Size(204, 20);
            this.RuntimeMinutes.TabIndex = 6;
            // 
            // RuntimeLabel
            // 
            this.RuntimeLabel.AutoSize = true;
            this.RuntimeLabel.Location = new System.Drawing.Point(3, 59);
            this.RuntimeLabel.Name = "RuntimeLabel";
            this.RuntimeLabel.Size = new System.Drawing.Size(91, 13);
            this.RuntimeLabel.TabIndex = 19;
            this.RuntimeLabel.Text = "Runtime (minutes)";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(157, 145);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(150, 42);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(0, 145);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(145, 42);
            this.AcceptButton.TabIndex = 20;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // AddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.RuntimeLabel);
            this.Controls.Add(this.RuntimeMinutes);
            this.Controls.Add(this.StatusListBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.DescripitionTextbox);
            this.Controls.Add(this.TitleTextbox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "AddMovie";
            this.Size = new System.Drawing.Size(313, 191);
            this.Load += new System.EventHandler(this.AddMovie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RuntimeMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox TitleTextbox;
        private System.Windows.Forms.TextBox DescripitionTextbox;
        public System.Windows.Forms.ListBox StatusListBox;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.NumericUpDown RuntimeMinutes;
        private System.Windows.Forms.Label RuntimeLabel;
        public System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.Button AcceptButton;
    }
}
