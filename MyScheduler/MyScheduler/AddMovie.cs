using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScheduler
{
    public partial class AddMovie : UserControl
    {
        private string _title;
        private string _desc;
        private int _minutes;
        private ShowStatus _status;
        private DialogResult ReturnStatus;

        public DialogResult Result
        {
            get { return ReturnStatus; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }
        public int Runtime
        {
            get { return _minutes; }
            set { _minutes = value; }
        }
        public ShowStatus Status
        {
            get { return _status; }
        }

        public AddMovie(string ControlName)
        {
            InitializeComponent();
            ReturnStatus = DialogResult.Cancel;
            this.Name = ControlName;
        }

        private void AddMovie_Load(object sender, EventArgs e)
        {
            var stats = Enum.GetValues(typeof(ShowStatus));
            foreach (ShowStatus s in stats)
            {
                StatusListBox.Items.Add(s);
            }

            StatusListBox.SelectedIndex = 0;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            Title = TitleTextbox.Text;
            Description = DescripitionTextbox.Text;
            Runtime = (int)RuntimeMinutes.Value;
            _status = (ShowStatus)StatusListBox.SelectedItem;
            ReturnStatus = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ReturnStatus = DialogResult.Cancel;
        }
        public void Clear()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                }
                else if (c is NumericUpDown)
                {
                    ((NumericUpDown)c).Value = 0;
                }
            }
        }
    }
}
