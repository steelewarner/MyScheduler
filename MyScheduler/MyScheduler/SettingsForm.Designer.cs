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
            this.LoadUserCheckbox = new System.Windows.Forms.CheckBox();
            this.LoadUserBrowseButton = new System.Windows.Forms.Button();
            this.LoadUserTextbox = new System.Windows.Forms.TextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadUserCheckbox
            // 
            this.LoadUserCheckbox.AutoSize = true;
            this.LoadUserCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LoadUserCheckbox.Location = new System.Drawing.Point(12, 12);
            this.LoadUserCheckbox.Name = "LoadUserCheckbox";
            this.LoadUserCheckbox.Size = new System.Drawing.Size(117, 17);
            this.LoadUserCheckbox.TabIndex = 1;
            this.LoadUserCheckbox.Text = "Load user on setup";
            this.LoadUserCheckbox.UseVisualStyleBackColor = true;
            this.LoadUserCheckbox.CheckedChanged += new System.EventHandler(this.LoadUserCheckbox_CheckedChanged);
            // 
            // LoadUserBrowseButton
            // 
            this.LoadUserBrowseButton.Location = new System.Drawing.Point(221, 9);
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
            this.LoadUserTextbox.Location = new System.Drawing.Point(135, 12);
            this.LoadUserTextbox.Name = "LoadUserTextbox";
            this.LoadUserTextbox.Size = new System.Drawing.Size(80, 20);
            this.LoadUserTextbox.TabIndex = 2;
            this.LoadUserTextbox.Visible = false;
            // 
            // OKbutton
            // 
            this.OKbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OKbutton.Location = new System.Drawing.Point(98, 83);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 4;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OKbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.LoadUserBrowseButton);
            this.Controls.Add(this.LoadUserTextbox);
            this.Controls.Add(this.LoadUserCheckbox);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox LoadUserCheckbox;
        private System.Windows.Forms.Button LoadUserBrowseButton;
        private System.Windows.Forms.TextBox LoadUserTextbox;
        private System.Windows.Forms.Button OKbutton;
    }
}