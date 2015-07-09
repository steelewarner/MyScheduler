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
        private int bgcForm;
        private int fgcForm;
        private Font fontForm;
        
        /// <summary>
        /// Gets the bool value for if the user should be loaded on form setup
        /// </summary>
        public bool LoadUserOnSetup
        {
            get { return _loaduseronsetup; }
        }
        /// <summary>
        /// Gets the path for the file that should be loaded on setup
        /// </summary>
        public string LoadUserFilePath
        {
            get { return _loaduserfilepath; }
        }

        public int FormBGC
        {
            get { return bgcForm; }
        }
        public int FormFGC
        {
            get { return fgcForm; }
        }
        public Font FormFont
        {
            get { return fontForm; }
        }

        public SettingsForm()
        {
            InitializeComponent();
            _loaduserfilepath = "";
            _loaduseronsetup = false;
        }
        public SettingsForm(MySchedulerForm f)
        {
            InitializeComponent();
            _loaduserfilepath = f.DefaultPath;
            _loaduseronsetup = f.LoadUserOnSetup;
            bgcForm = f.BackColor.ToArgb();
            fgcForm = f.ForeColor.ToArgb();
            fontForm = f.Font;
        }

        private void LoadUserBrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opDialog = new OpenFileDialog())
            {
                opDialog.Filter = "xml file (*.xml)|*.xml";
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
            
            if (!_loaduseronsetup || Uri.UriSchemeFile == new Uri(_loaduserfilepath).Scheme)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid File Path", "Default File Path");
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            bgColorButton.BackColor = Color.FromArgb(bgcForm);
            fgColorButton.BackColor = Color.FromArgb(fgcForm);
            FontStyleButton.Font = fontForm;
            FontStyleButton.Text = fontForm.Name;

            if (_loaduseronsetup)
            {
                LoadUserCheckbox.Checked = true;//should trigger checked changed event
                LoadUserTextbox.Text = _loaduserfilepath;

            }
        }

        private void bgColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog cDialog = new ColorDialog())
            {
                if (cDialog.ShowDialog() == DialogResult.OK)
                {
                    bgcForm = cDialog.Color.ToArgb();
                    bgColorButton.BackColor = cDialog.Color;
                }
            }
        }

        private void fgColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog cDialog = new ColorDialog())
            {
                if (cDialog.ShowDialog() == DialogResult.OK)
                {
                    fgcForm = cDialog.Color.ToArgb();
                    fgColorButton.BackColor = cDialog.Color;
                }
            }
        }

        private void FontStyleButton_Click(object sender, EventArgs e)
        {
            using (FontDialog fDialog = new FontDialog())
            {
                fDialog.MaxSize = 12;
                fDialog.MinSize = 8;
                fDialog.Font = fontForm;
                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    fontForm = fDialog.Font;

                    FontStyleButton.Font = fDialog.Font;
                    FontStyleButton.Text = fDialog.Font.Name;
                }
            }
        }
    }
}
