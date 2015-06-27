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

        public MediaInfo()
        {
            InitializeComponent();
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

            if (ProgressLabel.Left < EpisodeCount.Left)
            {
                richTextBoxDescription.Width = ProgressLabel.Left - richTextBoxDescription.Left;
            }
            else
            {
                richTextBoxDescription.Width = EpisodeCount.Left - richTextBoxDescription.Left;
            }
        }

        private void MediaInfo_Resize(object sender, EventArgs e)
        {
            TitleLabel.Left = this.Left;
            DashLabel.Left = TitleLabel.Right;
            StatusLabel.Left = DashLabel.Right;
            DownloadLabel.Left = StatusLabel.Right;
            AirtimeLabel.Left = DownloadLabel.Right;

            if (ProgressLabel.Left < EpisodeCount.Left)
            {
                richTextBoxDescription.Width = ProgressLabel.Left - richTextBoxDescription.Left;
            }
            else
            {
                richTextBoxDescription.Width = EpisodeCount.Left - richTextBoxDescription.Left;
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

                while (ControlMousePosition.Y <= TitleLabel.Bottom && ControlMousePosition.Y >= 0 
                            && AirtimeLabel.Right > this.Right)
                {
                    TitleLabel.Left -= 1;
                    DashLabel.Left -= 1;
                    StatusLabel.Left -= 1;
                    DownloadLabel.Left -= 1;
                    AirtimeLabel.Left -= 1;
                    System.Threading.Thread.Sleep(10);
                    this.Refresh();
                    ControlMousePosition = PointToClient(MousePosition);
                }
            }
                this.MediaInfo_Resize(this, e);
        }
    }
}
