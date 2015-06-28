/******************************************
 * Author: Steele Warner
 * Created: June 25, 2015
 *****************************************/
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
    public partial class MediaInfo : UserControl
    {
        private bool scrollableLabels;
        private int episodes_watched;
        private int total_episodes;
        /// <summary>
        /// Gets the number of episodes watched being displayed
        /// </summary>
        public int EpisodesWatched
        {
            get { return episodes_watched; }
            //set { episodes_watched = value; }
        }
        /// <summary>
        /// Gets the number of total episodes being displayed
        /// </summary>
        public int TotalEpisodes
        {
            get { return total_episodes; }
            //set { total_episodes = value; }
        }

        public MediaInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sets the number of episodes watched and total episodes for media display
        /// </summary>
        /// <param name="episodesWatched">Number of episodes watched</param>
        /// <param name="totalEpisodes">Total number of episodes of media</param>
        public void SetEpisodes(int episodesWatched, int totalEpisodes)
        {
            if (episodesWatched > totalEpisodes)
            {
                episodes_watched = totalEpisodes;
                total_episodes = totalEpisodes;
            }
            else
            {
                episodes_watched = episodesWatched;
                total_episodes = totalEpisodes;
            }

            EpisodeLabel.Text = episodes_watched.ToString() + "/" + total_episodes.ToString();
        }

        private void MediaInfo_Load(object sender, EventArgs e)
        {
            scrollableLabels = false;
            DownloadLabel.Visible = false;
            AirtimeLabel.Visible = false;

            TitleLabel.Left = this.Left;
            DashLabel.Left = TitleLabel.Right;
            StatusLabel.Left = DashLabel.Right;
            DownloadLabel.Left = StatusLabel.Right;
            AirtimeLabel.Left = DownloadLabel.Right;

            if (ProgressLabel.Left < EpisodeLabel.Left)
            {
                richTextBoxDescription.Width = ProgressLabel.Left - richTextBoxDescription.Left;
            }
            else
            {
                richTextBoxDescription.Width = EpisodeLabel.Left - richTextBoxDescription.Left;
            }
        }

        public void MediaInfo_Resize(object sender, EventArgs e)
        {
            TitleLabel.Left = this.Left;
            DashLabel.Left = TitleLabel.Right;
            StatusLabel.Left = DashLabel.Right;
            DownloadLabel.Left = StatusLabel.Right;
            AirtimeLabel.Left = DownloadLabel.Right;

            if (ProgressLabel.Left < EpisodeLabel.Left)
            {
                richTextBoxDescription.Width = ProgressLabel.Left - richTextBoxDescription.Left;
            }
            else
            {
                richTextBoxDescription.Width = EpisodeLabel.Left - richTextBoxDescription.Left;
            }
            
        }

        private void Check_Label_Width(object sender, EventArgs e)
        {
            int labelswidth = TitleLabel.Width + DashLabel.Width + StatusLabel.Width
                                + DownloadLabel.Width + AirtimeLabel.Width;
            if (labelswidth > this.Width)
            {
                scrollableLabels = true;
            }
        }

        private void Label_Scroll(object sender, EventArgs e)
        {
            if (scrollableLabels)
            {
                Point ControlMousePosition = PointToClient(MousePosition);

                while (ControlMousePosition.Y <= TitleLabel.Bottom && ControlMousePosition.Y >= 0)
                {
                    if (AirtimeLabel.Right > this.Right)
                    {
                        TitleLabel.Left -= 1;
                        DashLabel.Left -= 1;
                        StatusLabel.Left -= 1;
                        DownloadLabel.Left -= 1;
                        AirtimeLabel.Left -= 1;
                    }
                    System.Threading.Thread.Sleep(10);
                    this.Refresh();
                    ControlMousePosition = PointToClient(MousePosition);
                }
            }
                this.MediaInfo_Resize(this, e);
        }

        private void EpisodeCount_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Value = (int)(((double)episodes_watched / (double)total_episodes) * 100);
        }
    }
}
