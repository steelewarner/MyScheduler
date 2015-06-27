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
    public partial class AddAnime : UserControl
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
        public AddAnime()
        {
            InitializeComponent();
            this.Name = "AddAnime";//Defaule control name
            _Date = new DateTime();
            ReturnStatus = DialogResult.Cancel;
        }

        private void AddAnime_Load(object sender, EventArgs e)
        {
            WatchedEpisodesNumUpDown.Maximum = TotalEpisodesNumUpDown.Value;

            StatusListBox.Items.Add(ShowStatus.Airing);
            StatusListBox.Items.Add(ShowStatus.Completed);
            StatusListBox.Items.Add(ShowStatus.FinishedAiring);
            StatusListBox.Items.Add(ShowStatus.PlanToWatch);
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
                ReturnStatus = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                ReturnStatus = DialogResult.Cancel;
            }
        }
    }
}
