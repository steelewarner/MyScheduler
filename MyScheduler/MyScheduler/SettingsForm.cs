using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScheduler
{
    public partial class SettingsForm : Form
    {
        private bool _loaduseronsetup;
        private string _loaduserfilepath;
        
        public bool LoadUserOnSetup
        {
            get { return _loaduseronsetup; }
        }
        public string LoadUserFilePath
        {
            get { return _loaduserfilepath; }
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void LoadUserBrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opDialog = new OpenFileDialog())
            {
                if (opDialog.ShowDialog() == DialogResult.OK)
                {
                    _loaduserfilepath = opDialog.FileName;
                    LoadUserTextbox.Text = opDialog.FileName;
                }
            }
        }

        private void LoadUserCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadUserCheckbox.Checked)
            {
                LoadUserTextbox.Visible = true;
                LoadUserBrowseButton.Visible = true;
                _loaduseronsetup = true;
            }
            else
            {
                LoadUserTextbox.Visible = false;
                LoadUserBrowseButton.Visible = false;
                _loaduseronsetup = false;
            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        { 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
