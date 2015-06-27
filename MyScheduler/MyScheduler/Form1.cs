/* ************************************************************************
 * Author: Steele Warner
 * Created: June 9, 2015
 * Info: This is the Form program for the base UI for MyScheduler app
 * Last Updated: 6/25/2015
 * version: v0.3.3
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
            DayOfWeek firstday = MySchedulerMonth.FindFirstDay(DateTime.Today);
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
                int row = (int)(t.Date.Day / 7);
                int column = ((int)firstday + t.Date.Day - 1) % 7;
                TaskCalendar.Rows[row].Cells[column].Value += t.Name + Environment.NewLine;
                TaskCalendar.Rows[row].Cells[column].Tag = t;
            }
        }

        private void UpdateTaskScheduler(Task t)
        {
            string[] subitms = { t.Name, t.Date.ToString(), t.Description };
            ListViewSchedule.Items.Add(t.GetType().Name).SubItems.AddRange(subitms);
        }

        private void ListViewScheduleInitializer()
        {
            ListViewSchedule.View = View.Details;

            ListViewSchedule.Columns.Add("Task", 200, HorizontalAlignment.Center);
            ListViewSchedule.Columns.Add("Name", 200, HorizontalAlignment.Center);
            ListViewSchedule.Columns.Add("Date", 200, HorizontalAlignment.Center);
            ListViewSchedule.Columns.Add("Description", 200, HorizontalAlignment.Left);

            foreach (Task t in User.Tasklist)
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
            panel1.Controls.Add(new AddAnime());
            ((AddAnime)panel1.Controls["AddAnime"]).AcceptButton.Click += AddAnimeAcceptButton_Click;
            //Will add more controls after i have created them
        }

        void User_MediaAdded(object sender, EventArgs e)
        {
            
        }

        void AddAnimeAcceptButton_Click(object sender, EventArgs e)
        {
            AddAnime japanesecartoon = panel1.Controls["AddAnime"] as AddAnime;
            if (japanesecartoon.Result == DialogResult.OK)
            {
                Anime otaku = new Anime(japanesecartoon.TitleTextbox.Text, japanesecartoon.Date, (int)japanesecartoon.TotalEpisodesNumUpDown.Value);
                otaku.WatchedEpisodes = (int)japanesecartoon.WatchedEpisodesNumUpDown.Value;
                otaku.URI = new Uri(japanesecartoon.URItextbox.Text);
                otaku.Status = (ShowStatus)japanesecartoon.StatusListBox.SelectedItem;
                otaku.Description = japanesecartoon.DescriptionTextbox.Text;
                User.AddMedia(otaku);
                MediaList.Nodes["AnimeNode"].Nodes.Add(japanesecartoon.TitleTextbox.Text);
                MediaList.Nodes["AnimeNode"].Nodes[MediaList.Nodes["AnimeNode"].Nodes.Count - 1].Tag = otaku;


            }
        }

        void MediaTab_Resize(object sender, EventArgs e)
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
    }
}
