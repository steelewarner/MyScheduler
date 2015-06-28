/* ************************************************************************
 * Author: Steele Warner
 * Created: June 9, 2015
 * Info: This is the Form program for the base UI for MyScheduler app
 * Last Updated: 6/28/2015
 * version: v0.4.3
 * ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MyScheduler
{
    public partial class MySchedulerForm : Form
    {
        //private MySchedulerCalendar DataCalendar = new MySchedulerCalendar();
        private MySchedulerUser User;
        private bool LoadUserOnSetup;
        private string SettingsURI;
        private Process videoplayer;
        /// <summary>
        /// Value used for space between bordering controls
        /// </summary>
        private const int control_padding = 3;

        public MySchedulerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Resizes TaskCalendar cells so that they fill the control
        /// </summary>
        private void ResizeTaskCalendarRows()
        {
            int control_height = TaskCalendar.Height - TaskCalendar.ColumnHeadersHeight;
            
            foreach (DataGridViewRow r in TaskCalendar.Rows)
            {
                r.Height = control_height / 5;
            }
            foreach (DataGridViewColumn c in TaskCalendar.Columns)
            {
                c.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }
        /// <summary>
        /// Sets the calendar to the correct month and dates
        /// </summary>
        private void AddDatesToCalendar()
        {
            MonthLabel.Text = MySchedulerMonth.IntToString(DateTime.Today.Month);
            MonthLabel.Tag = DateTime.Today.Month;
            int days = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            //DayOfWeek firstday = MySchedulerMonth.FindFirstDay(DateTime.Today);
            DayOfWeek firstday = (new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)).DayOfWeek;
            int j = 0;
            for (int i = 1; i <= days; i++)
            {
                TaskCalendar.Rows[j].Cells[((int)firstday + i - 1) % 7].Value = i.ToString() + Environment.NewLine;
                if (((int)firstday + i) % 7  == 0)
                {
                    j++;
                    if (j>TaskCalendar.Rows.Count)
                    {
                        TaskCalendar.Rows.Add();
                        ResizeTaskCalendarRows();
                    }
                }
            }
        }

        private void LoadSettings()
        {
            XmlReader reader = XmlReader.Create(SettingsURI);

            LoadUserOnSetup = reader.ReadElementContentAsBoolean("LoadUserOnSetup", "MyScheduler");

            if (LoadUserOnSetup)
            {

            }
            else
            {
                User = new MySchedulerUser("", "John", "Doe");
                User.Calendar.CreateFullCalendar(DateTime.Today.Year);
                User.TaskCreated += User_TaskCreated;
            }
        }

        private void User_TaskCreated(object sender, EventArgs e)
        {
            UpdateTaskCalendar(((TaskEventArgs)e).ArgsTask);
            UpdateTaskScheduler(((TaskEventArgs)e).ArgsTask);
        }

        private void UpdateTaskCalendar(Task t)
        {
            if ((int)MonthLabel.Tag == t.Date.Month)
            {
                DayOfWeek firstday = MySchedulerMonth.FindFirstDay(t.Date);
                int row = (int)(t.Date.Day / 7);//finds corresponding row from month and date
                int column = ((int)firstday + t.Date.Day - 1) % 7;//finds corresponding column from month and date
                TaskCalendar.Rows[row].Cells[column].Value += t.Name + Environment.NewLine;
                TaskCalendar.Rows[row].Cells[column].Tag = t;
            }
        }

        private void UpdateTaskScheduler(Task t)
        {
            string[] subitms = { t.Name, t.Date.ToString(), t.Description };
            ListViewSchedule.Items.Add(t.GetType().Name).SubItems.AddRange(subitms);//Adds a new item to schedule with info subitems
        }

        private void ListViewScheduleInitializer()
        {
            ListViewSchedule.View = View.Details;
            //Column headers for schedule task list
            ListViewSchedule.Columns.Add("Task", 200, HorizontalAlignment.Center);
            ListViewSchedule.Columns.Add("Name", 200, HorizontalAlignment.Center);
            ListViewSchedule.Columns.Add("Date", 200, HorizontalAlignment.Center);
            ListViewSchedule.Columns.Add("Description", 200, HorizontalAlignment.Left);

            foreach (Task t in User.Tasklist)//Adds all tasks in the user's tasklist to schedule
            {
                ListViewItem itm = new ListViewItem(t.GetType().Name);
                itm.SubItems.Add(t.Name);
                itm.SubItems.Add(t.Date.ToString());
                itm.SubItems.Add(t.Description);
                ListViewSchedule.Items.Add(itm);
            }
        }

        private void SaveSettings()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /******************************
                     Load Settings
             ******************************/
            //LoadSettings();
            User = new MySchedulerUser("", "John", "Doe");
            User.Calendar.CreateFullCalendar(DateTime.Today.Year);
            User.TaskCreated += User_TaskCreated;

            /******************************
                   TabCalendar Setup
             ******************************/
            TaskCalendar.Columns.Add("Sunday", "Sunday");
            TaskCalendar.Columns.Add("Monday", "Monday");
            TaskCalendar.Columns.Add("Tuesday", "Tuesday");
            TaskCalendar.Columns.Add("Wednesday", "Wednesday");
            TaskCalendar.Columns.Add("Thursday", "Thursday");
            TaskCalendar.Columns.Add("Friday", "Friday");
            TaskCalendar.Columns.Add("Saturday", "Saturday");

            TaskCalendar.Rows.Add(5);

            ResizeTaskCalendarRows();

            AddDatesToCalendar();

            
            /******************************
                   TabSchedule Setup
             ******************************/
            ListViewScheduleInitializer();

            /******************************
                    TabMedia Setup
             ******************************/
            MediaTab.Resize += MediaTab_Resize;
            MediaTab_Resize(this, new EventArgs());
            User.MediaAdded += User_MediaAdded;

            panel1.Controls.Add(new AddTV("AddAnime"));
            ((AddTV)panel1.Controls["AddAnime"]).AcceptButton.Click += AddAnimeAcceptButton_Click;
            ((AddTV)panel1.Controls["AddAnime"]).CancelButton.Click += AddAnimeCancelButton_Click;

            panel1.Controls.Add(new AddTV("AddTV"));
            ((AddTV)panel1.Controls["AddTV"]).AcceptButton.Click += AddTVAcceptButton_Click;
            ((AddTV)panel1.Controls["AddTV"]).CancelButton.Click += AddTVCancelButton_Click;

            panel1.Controls.Add(new AddMovie("AddMovie"));
            ((AddMovie)panel1.Controls["AddMovie"]).AcceptButton.Click += AddMovieAcceptButton_Click;
            ((AddMovie)panel1.Controls["AddMovie"]).CancelButton.Click += AddMovieCancelButton_Click;
            
        }

        private void AddMovieCancelButton_Click(object sender, EventArgs e)
        {
            panel1.Controls["webBrowser1"].Visible = true;
            panel1.Controls["AddMovie"].Visible = false;
        }

        private void AddTVCancelButton_Click(object sender, EventArgs e)
        {
            panel1.Controls["webBrowser1"].Visible = true;
            panel1.Controls["AddTV"].Visible = false;
        }

        private void AddAnimeCancelButton_Click(object sender, EventArgs e)
        {
            panel1.Controls["webBrowser1"].Visible = true;
            panel1.Controls["AddAnime"].Visible = false;
        }

        void User_MediaAdded(object sender, EventArgs e)
        {
            var args = e as MediaEventArgs;

            if (args.ArgsMedia is Anime)
            {
                MediaList.Nodes["AnimeNode"].Nodes.Add(args.ArgsMedia.Title);//adds anime node to treeview
                MediaList.Nodes["AnimeNode"].Nodes[MediaList.Nodes["AnimeNode"].Nodes.Count - 1].Tag = args.ArgsMedia as Anime;//sets node's tag to anime object
            }
            else if (args.ArgsMedia is TVshow)
            {
                MediaList.Nodes["TV"].Nodes.Add(args.ArgsMedia.Title);//adds TV node to treeview
                MediaList.Nodes["TV"].Nodes[MediaList.Nodes["TV"].Nodes.Count - 1].Tag = args.ArgsMedia as TVshow ;//sets node's tag to TVshow object
            }
            else if (args.ArgsMedia is Movie)
            {
                MediaList.Nodes["Movies"].Nodes.Add(args.ArgsMedia.Title);//adds movie node to treeview
                MediaList.Nodes["Movies"].Nodes[MediaList.Nodes["Movies"].Nodes.Count - 1].Tag = args.ArgsMedia as Movie;//sets node's tag to movie object
            }
        }

        private void AddAnimeAcceptButton_Click(object sender, EventArgs e)
        {
            AddTV japanesecartoon = panel1.Controls["AddAnime"] as AddTV;
            if (japanesecartoon.Result == DialogResult.OK)//Makes sure the control has acceptable information
            {
                Anime otaku = new Anime(japanesecartoon.TitleTextbox.Text, japanesecartoon.Date, (int)japanesecartoon.TotalEpisodesNumUpDown.Value);//creates new anime object with info entered in control
                otaku.WatchedEpisodes = (int)japanesecartoon.WatchedEpisodesNumUpDown.Value;//sets the amount of watched episodes
                otaku.URI = new Uri(japanesecartoon.URItextbox.Text);//creates new uri based off string entered
                otaku.Status = (ShowStatus)japanesecartoon.StatusListBox.SelectedItem;//sets status
                otaku.Description = japanesecartoon.DescriptionTextbox.Text;//sets the description
                User.AddMedia(otaku);//Adds anime to user's media list
                /*Using User_MediaAdded method above prevents duplicates*/
                panel1.Controls["webBrowser1"].Visible = true;
                panel1.Controls["AddAnime"].Visible = false;
            }
            
        }
        
        private void AddTVAcceptButton_Click(object sender, EventArgs e)
        {
            AddTV showcontrol = panel1.Controls["AddTV"] as AddTV;
            if (showcontrol.Result == DialogResult.OK)
            {
                TVshow show = new TVshow(showcontrol.TitleTextbox.Text, showcontrol.Date, (int)showcontrol.TotalEpisodesNumUpDown.Value);//creates new tvshow object from info entered in control
                show.WatchedEpisodes = (int)showcontrol.WatchedEpisodesNumUpDown.Value;//sets the amount of watched episodes
                show.URI = new Uri(showcontrol.URItextbox.Text);//creates new uri based of string entered
                show.Status = (ShowStatus)showcontrol.StatusListBox.SelectedItem;//sets the show status
                show.Description = showcontrol.DescriptionTextbox.Text;//sets description
                User.AddMedia(show);//Adds show to user's media list
                panel1.Controls["webBrowser1"].Visible = true;
                panel1.Controls["AddTV"].Visible = false;
            }
            
        }
        
        private void AddMovieAcceptButton_Click(object sender, EventArgs e)
        {
            AddMovie cinema = panel1.Controls["AddMovie"] as AddMovie;

            if (cinema.Result == DialogResult.OK)
            {
                Movie mover = new Movie(cinema.Title, cinema.Runtime);//creates new movie object with info from control
                mover.Description = cinema.Description;//sets movie description
                mover.Status = cinema.Status;//sets movie status
                User.AddMedia(mover);//adds movie to medialist
                panel1.Controls["webBrowser1"].Visible = true;//changes display
                panel1.Controls["AddMovie"].Visible = false;
            }
        }
        
        private void MediaTab_Resize(object sender, EventArgs e)
        {
            MediaList.Left = control_padding;//left edge is padding distance away from container edge
            MediaList.Top = control_padding;//Top edge is padding distance away from container top
            MediaList.Height = (mediaInfo1.Top - MediaList.Top) - control_padding;

            mediaInfo1.Left = control_padding;//left edge is padding distance away from container edge
            mediaInfo1.Width = MediaTab.Width - control_padding;//width has padding distance on both sides

            panel1.Left = MediaList.Right + control_padding;//left edge is padding distance away from MediaList edge
            panel1.Top = control_padding;//Top edge is padding distance away from container top
            panel1.Width = (MediaTab.Width - MediaList.Width) - (control_padding * 2);//width has padding distance on both sides
            panel1.Height = (mediaInfo1.Top - panel1.Top) - control_padding;


        }

        private void TabCalendar_Click(object sender, EventArgs e)
        {
            
        }

        private void TaskCalendar_Resize(object sender, EventArgs e)
        {
            this.ResizeTaskCalendarRows();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void ScheduleTab_Click(object sender, EventArgs e)
        {

        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AddTaskForm addForm = new AddTaskForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    //User.AddTask(addForm.GetSelectedTask());
                    User.Calendar.GetMonth(addForm.Date.Month).GetDay(addForm.Date.Day).AddTask(addForm.GetSelectedTask());
                }
            }
        }

        private void loadUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserSetup uSetup = new UserSetup())
            {
                if (uSetup.ShowDialog() == DialogResult.OK)
                {
                    User.Username = uSetup.Username;
                    User.FirstName = uSetup.Firstname;
                    User.LastName = uSetup.Lastname;
                    this.Text = User.FirstName + " " +  User.LastName;
                }
            }
        }

        private void removeTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ListViewSchedule_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 2)
            {
                //sorting algorithm of choice for date
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                //videoplayer = Process.Start("C:\\Program Files (x86)\\Daum\\PotPlayer\\PotPlayerMini.exe");
                //videoplayer.WaitForInputIdle();

            }
        }

        private void MediaList_Resize(object sender, EventArgs e)
        {
            panel1.Left = MediaList.Right + control_padding;
        }

        private void MySchedulerForm_Resize(object sender, EventArgs e)
        {

        }

        private void addAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.Name.Equals("AddAnime"))
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
            
        }
        private void addTVShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.Name.Equals("AddTV"))
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
        } 
        private void addMovieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.Name.Equals("AddMovie"))
                {
                    c.Visible = true;
                }
                else
                {
                    c.Visible = false;
                }
            }
        }

        private void MediaList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)//Exits method if clicked node is one of the empty parent nodes
            {
                return;
            }
            //Sets the media info control information corresponding to the selected listview node
            switch (e.Node.Parent.Text)
            {
                case "Anime": var obj = e.Node.Tag as Anime;//sets as anime object if in anime tree
                    mediaInfo1.TitleLabel.Text = obj.Title;//sets title label
                    mediaInfo1.StatusLabel.Text = obj.Status.ToString();//sets status label
                    mediaInfo1.DownloadLabel.Text = "Downloaded: " + obj.Downloaded.ToString();//shows download status
                    mediaInfo1.DownloadLabel.Visible = true;
                    mediaInfo1.SetEpisodes(obj.WatchedEpisodes, obj.TotalEpisodes);//sets episodes
                    mediaInfo1.AirtimeLabel.Text = obj.Airtime.DayOfWeek.ToString() + " " + obj.Airtime.ToShortTimeString();//sets airtime label
                    mediaInfo1.AirtimeLabel.Visible = true;
                    mediaInfo1.richTextBoxDescription.Text = obj.Description;//sets description
                    mediaInfo1.MediaInfo_Resize(mediaInfo1, new EventArgs());//Sets label in their correct positions
                    break;
                case "TV Shows": var TVobj = e.Node.Tag as TVshow;
                    mediaInfo1.TitleLabel.Text = TVobj.Title;
                    mediaInfo1.StatusLabel.Text = TVobj.Status.ToString();
                    mediaInfo1.DownloadLabel.Visible = false;
                    mediaInfo1.SetEpisodes(TVobj.WatchedEpisodes, TVobj.TotalEpisodes);
                    mediaInfo1.AirtimeLabel.Text = TVobj.Airtime.DayOfWeek.ToString() + " " + TVobj.Airtime.ToShortTimeString();
                    mediaInfo1.AirtimeLabel.Visible = true;
                    mediaInfo1.richTextBoxDescription.Text = TVobj.Description;
                    mediaInfo1.MediaInfo_Resize(mediaInfo1, new EventArgs());//Sets label in their correct positions
                    break;
                case "Movies": var MOVobj = e.Node.Tag as Movie;
                    mediaInfo1.TitleLabel.Text = MOVobj.Title;
                    mediaInfo1.StatusLabel.Text = MOVobj.Status.ToString();
                    mediaInfo1.DownloadLabel.Visible = false;
                    mediaInfo1.SetEpisodes(1, 1);//a movie only has one "episode"
                    mediaInfo1.AirtimeLabel.Text = MOVobj.Runtime.ToString();
                    mediaInfo1.AirtimeLabel.Visible = true;
                    mediaInfo1.richTextBoxDescription.Text = MOVobj.Description;
                    mediaInfo1.MediaInfo_Resize(mediaInfo1, new EventArgs());//Sets label in their correct positions
                    break;
            }
        }          
    }
}
