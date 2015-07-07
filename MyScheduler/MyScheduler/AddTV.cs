/**********************************
 * Author: Steele Warner
 * Created: June 26, 2015
 **********************************/

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
    public partial class AddTV : UserControl
    {
        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
        }
        private DialogResult ReturnStatus;
        public DialogResult Result
        {
            get { return ReturnStatus; }
        }
        public AddTV(string control_name)
        {
            InitializeComponent();
            this.Name = control_name;//Default control name
            _Date = new DateTime();
            ReturnStatus = DialogResult.Cancel;
        }

        private void AddTV_Load(object sender, EventArgs e)
        {
            WatchedEpisodesNumUpDown.Maximum = TotalEpisodesNumUpDown.Value;

            StatusListBox.Items.Add(ShowStatus.Airing);
            StatusListBox.Items.Add(ShowStatus.Completed);
            StatusListBox.Items.Add(ShowStatus.FinishedAiring);
            StatusListBox.Items.Add(ShowStatus.PlanToWatch);
            StatusListBox.SelectedIndex = 0;
        }

        private void TotalEpisodesNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            WatchedEpisodesNumUpDown.Maximum = TotalEpisodesNumUpDown.Value;
            if (WatchedEpisodesNumUpDown.Value > TotalEpisodesNumUpDown.Value)
            {
                WatchedEpisodesNumUpDown.Value = TotalEpisodesNumUpDown.Value;
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                _Date = dateClock1.ParseDateClock();
                Uri temp = new Uri(URItextbox.Text);//check to see if correct uri format has been entered
                ReturnStatus = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                ReturnStatus = DialogResult.Cancel;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ReturnStatus = DialogResult.Cancel;
        }

        /// <summary>
        /// Clears all input information from control and sets it back to default values
        /// </summary>
        public void Clear()
        {
            foreach (TextBox tb in this.Controls)
            {
                tb.Text = string.Empty;
            }
            foreach(NumericUpDown num in this.Controls)
            {
                num.Value = 0;
            }

            dateClock1.textBox1.Text = "MM";
            dateClock1.textBox2.Text = "DD";
            dateClock1.textBox3.Text = "YYYY";
            dateClock1.textBox4.Text = "24";
            dateClock1.textBox5.Text = "00";
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog opDialog = new OpenFileDialog())
            {
                if (opDialog.ShowDialog() == DialogResult.OK)
                {
                    URItextbox.Text = opDialog.FileName;
                }
            }
        }
    }
}
