/* ************************************************************************
 * Author: Steele Warner
 * Created: June 9, 2015
 * Info: This is the Form program for the base UI for MyScheduler app
 * Last Updated: 7/6/2015
 * version: v0.8.12
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
using System.IO;
using System.Xml.Linq;


namespace MyScheduler
{
    public partial class MySchedulerForm : Form
    {
        //private MySchedulerCalendar DataCalendar = new MySchedulerCalendar();
        private MySchedulerUser User;
        private bool LoadUserOnSetup;
        private string DefaultPath;
        private Process videoplayer;
        private DateTime CurrentDate;
        /// <summary>
        /// Value used for space between bordering controls
        /// </summary>
        private const int control_padding = 3;

        public MySchedulerForm()
        {
            InitializeComponent();
            CurrentDate = DateTime.Today;
        }

        /// <summary>
        /// Resizes TaskCalendar cells so that they fill the control
        /// </summary>
        private void ResizeTaskCalendarRows()
        {
            int control_height = TaskCalendar.Height - TaskCalendar.ColumnHeadersHeight;
            
            foreach (DataGridViewRow r in TaskCalendar.Rows)
            {
                r.Height = control_height / TaskCalendar.Rows.Count;
            }
            foreach (DataGridViewColumn c in TaskCalendar.Columns)
            {
                c.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }
        /// <summary>
        /// Sets the calendar to the correct month and dates
        /// </summary>
        private void AddDatesToCalendar(DateTime d)
        {
            CurrentDate = d;
            MonthLabel.Text = MySchedulerMonth.IntToString(d.Month) + ", " + d.Year.ToString();
            MonthLabel.Tag = d.Month;
            int days = DateTime.DaysInMonth(d.Year, d.Month);
            DayOfWeek firstday = MySchedulerMonth.FindFirstDay(d);
            //DayOfWeek firstday = (new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)).DayOfWeek;
            int j = 1;
            for (int i = 1; i <= days; i++)
            {
                TaskCalendar.Rows[j-1].Cells[((int)firstday + i - 1) % 7].Value = i.ToString() + Environment.NewLine;
                if (((int)firstday + i) % 7  == 0)
                {
                    j++;
                    if ((j>TaskCalendar.Rows.Count) && (i < days))
                    {
                        TaskCalendar.Rows.Add();
                        ResizeTaskCalendarRows();
                    }
                }
            }
        }

        private void LoadSettings()
        {
            var reader = XDocument.Load("SettingsXML.xml");

            LoadUserOnSetup = (bool)reader.Element("Settings").Element("LoadUserOnSetup");
            
            if (LoadUserOnSetup)
            {
                DefaultPath = reader.Element("Settings").Element("DefaultPath").Value;
                LoadUser(new FileStream(DefaultPath, FileMode.Open));
            }
            else
            {
                User = new MySchedulerUser("", "John", "Doe");
                User.Calendar.CreateFullCalendar(DateTime.Today.Year);
                User.TaskCreated += User_TaskCreated;
                User.TaskRemoved += User_TaskRemoved;
                User.PropertyChanged += User_PropertyChanged;
                User.MediaAdded += User_MediaAdded;
                User.MediaRemoved += User_MediaRemoved;
            }
        }

        private void LoadUser(Stream filepath)
        {
            var doc = XDocument.Load(filepath);

            var uElement = doc.Element("MyScheduler").Element("User");
            if (null == User)
            {
                User = new MySchedulerUser(uElement.Attribute("username").Value,
                                            uElement.Attribute("firstname").Value,
                                            uElement.Attribute("lastname").Value);
            }
            else
            {
                User.Username = uElement.Attribute("username").Value;
                User.FirstName = uElement.Attribute("firstname").Value;
                User.LastName = uElement.Attribute("lastname").Value;
            }
            User.Calendar.CreateFullCalendar(DateTime.Today.Year);
            User.TaskCreated += User_TaskCreated;
            User.TaskRemoved += User_TaskRemoved;
            User.PropertyChanged += User_PropertyChanged;
            User.MediaAdded += User_MediaAdded;
            User.MediaRemoved += User_MediaRemoved;
            
            //gets all task objects for tasklist
            Task t;
            foreach (XElement e in doc.Element("MyScheduler").Element("User").Elements("Task"))
            {
                if (e.Value.Equals("Assignment"))
                {
                    t = new Assignment(e.Attribute("name").Value,
                                        e.Attribute("description").Value,
                                        e.Attribute("course").Value,
                                        (DateTime)e.Attribute("date"));
                    t.Priority = Task.StringToPriorityStatus(e.Attribute("priority").Value);
                    ((Assignment)t).MaterialCovered = e.Attribute("material").Value;
                    t.TaskComplete = bool.Parse(e.Attribute("taskcomplete").Value);
                    User.AddTask(t);
                }
                else if (e.Value.Equals("Lecture"))
                {
                    t = new Lecture(e.Attribute("name").Value,
                                        e.Attribute("description").Value,
                                        e.Attribute("course").Value,
                                        (DateTime)e.Attribute("date"),
                                        (TimeSpan)e.Attribute("length"));
                    t.TaskComplete = bool.Parse(e.Attribute("taskcomplete").Value);
                    t.Priority = Task.StringToPriorityStatus(e.Attribute("priority").Value);
                    foreach (XElement days in e.Elements("days"))
                    {
                        ((Lecture)t).AddDays(days.Value);
                    }
                    User.AddTask(t);
                }
                else if (e.Value.Equals("Miscellaneous"))
                {
                    t = new Miscellaneous(e.Attribute("name").Value,
                                        e.Attribute("description").Value);
                    t.TaskComplete = bool.Parse(e.Attribute("taskcomplete").Value);
                    t.Date = (DateTime)e.Attribute("date");
                    t.Priority = Task.StringToPriorityStatus(e.Attribute("priority").Value);
                    User.AddTask(t);
                }
                //User.AddTask(t);
            }

            //Gets all media objects for medialist
            Media m;
            foreach (XElement e in doc.Element("MyScheduler").Element("User").Elements("Media"))
            {
                if (e.Value.Equals("Movie"))
                {
                    m = new Movie(e.Attribute("title").Value, (int)e.Attribute("runtime"));
                    m.Description = e.Attribute("description").Value;
                    m.Status = Media.StringToStatus(e.Attribute("status").Value);
                    User.AddMedia(m);
                }
                else if (e.Value.Equals("TVshow"))
                {
                    m = new TVshow(e.Attribute("title").Value,
                        (DateTime)e.Attribute("airtime"),
                        (int)e.Attribute("totalepisodes"));
                    ((TVshow)m).WatchedEpisodes = (int)e.Attribute("watchedepisodes");
                    ((TVshow)m).URI = new Uri(e.Attribute("uri").Value);
                    m.Description = e.Attribute("description").Value;
                    m.Status = Media.StringToStatus(e.Attribute("status").Value);
                    User.AddMedia(m);
                }
                else if (e.Value.Equals("Anime"))
                {
                    m = new Anime(e.Attribute("title").Value,
                        (DateTime)e.Attribute("airtime"),
                        (int)e.Attribute("totalepisodes"));
                    ((Anime)m).WatchedEpisodes = (int)e.Attribute("watchedepisodes");
                    ((Anime)m).URI = new Uri(e.Attribute("uri").Value);
                    ((Anime)m).Downloaded = bool.Parse(e.Attribute("downloaded").Value);
                    m.Description = e.Attribute("description").Value;
                    m.Status = Media.StringToStatus(e.Attribute("status").Value);
                    User.AddMedia(m);
                }
            }
            filepath.Close();
        }

        private void User_MediaRemoved(object sender, EventArgs e)
        {
            
        }

        private void User_TaskCreated(object sender, EventArgs e)
        {
            UpdateTaskCalendar(((TaskEventArgs)e).ArgsTask);
            UpdateTaskScheduler(((TaskEventArgs)e).ArgsTask);
        }
        
        private void User_TaskRemoved(object sender, EventArgs e)
        {
            Task t = ((TaskEventArgs)e).ArgsTask;
            if ((int)MonthLabel.Tag == t.Date.Month)
            {
                DayOfWeek firstday = MySchedulerMonth.FindFirstDay(t.Date);
                int row = (int)(t.Date.Day / 7);//finds corresponding row from month and date
                int column = ((int)firstday + t.Date.Day - 1) % 7;//finds corresponding column from month and date
                TaskCalendar.Rows[row].Cells[column].Value = ((string)TaskCalendar.Rows[row].Cells[column].Value).Replace(Environment.NewLine + t.Name, "");
            }
        }
        /// <summary>
        /// Adds newly created task to task calendar
        /// </summary>
        /// <param name="t">New task</param>
        private void UpdateTaskCalendar(Task t)
        {
            if ((int)MonthLabel.Tag == t.Date.Month)
            {
                DayOfWeek firstday = MySchedulerMonth.FindFirstDay(t.Date);
                int row = (int)(t.Date.Day / 7);//finds corresponding row from month and date
                int column = ((int)firstday + t.Date.Day - 1) % 7;//finds corresponding column from month and date
                TaskCalendar.Rows[row].Cells[column].Value += t.Name + Environment.NewLine;
                if (TaskCalendar.Rows[row].Cells[column].Tag is List<Task>)
                {
                    ((List<Task>)TaskCalendar.Rows[row].Cells[column].Tag).Add(t);//adds new cell
                }
                else
                {
                    TaskCalendar.Rows[row].Cells[column].Tag = new List<Task>();//creates list of tasks for specific cell
                    ((List<Task>)TaskCalendar.Rows[row].Cells[column].Tag).Add(t);//adds new task to cell tag
                }
                
            }
        }
        /// <summary>
        /// Adds newly created task to scheduler
        /// </summary>
        /// <param name="t">New task</param>
        private void UpdateTaskScheduler(Task t)
        {
            string[] subitms = { t.Name, t.Date.ToString(), t.Description };
            ListViewSchedule.Items.Add(t.GetType().Name).SubItems.AddRange(subitms);//Adds a new item to schedule with info subitems
            ListViewSchedule.Items[ListViewSchedule.Items.Count - 1].Tag = t;
        }

        private void ListViewScheduleInitializer()
        {
            ListViewSchedule.View = View.Details;
            //Column headers for schedule task list
            ListViewSchedule.Columns.Add("Task", 200, HorizontalAlignment.Center);
            ListViewSchedule.Columns.Add("Name", 200, HorizontalAlignment.Center);
            ListViewSchedule.Columns.Add("Date", 200, HorizontalAlignment.Center);
            ListViewSchedule.Columns.Add("Description", 200, HorizontalAlignment.Left);
            /*
            foreach (Task t in User.Tasklist)//Adds all tasks in the user's tasklist to schedule
            {
                ListViewItem itm = new ListViewItem(t.GetType().Name);
                itm.SubItems.Add(t.Name);
                itm.SubItems.Add(t.Date.ToString());
                itm.SubItems.Add(t.Description);
                ListViewSchedule.Items.Add(itm);
            }*/
        }

        private void SaveSettings(XmlWriter writer)
        {
            writer.WriteStartElement("Settings");

            //Writes LoadUserOnSetup value to Settings xml file
            writer.WriteStartElement("LoadUserOnSetup");
            writer.WriteValue(LoadUserOnSetup);
            writer.WriteEndElement();

            //Writes default path to load user on setup
            writer.WriteStartElement("DefaultPath");
            writer.WriteValue(DefaultPath);
            writer.WriteEndElement();
            //Will add more settings later

            writer.WriteEndElement();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

            AddDatesToCalendar(DateTime.Today);

            
            /******************************
                   TabSchedule Setup
             ******************************/
            ListViewScheduleInitializer();

            /******************************
                    TabMedia Setup
             ******************************/
            MediaTab.Resize += MediaTab_Resize;
            MediaTab_Resize(this, new EventArgs());
            //User.MediaAdded += User_MediaAdded;

            panel1.Controls.Add(new AddTV("AddAnime"));
            ((AddTV)panel1.Controls["AddAnime"]).AcceptButton.Click += AddAnimeAcceptButton_Click;
            ((AddTV)panel1.Controls["AddAnime"]).CancelButton.Click += AddAnimeCancelButton_Click;

            panel1.Controls.Add(new AddTV("AddTV"));
            ((AddTV)panel1.Controls["AddTV"]).AcceptButton.Click += AddTVAcceptButton_Click;
            ((AddTV)panel1.Controls["AddTV"]).CancelButton.Click += AddTVCancelButton_Click;

            panel1.Controls.Add(new AddMovie("AddMovie"));
            ((AddMovie)panel1.Controls["AddMovie"]).AcceptButton.Click += AddMovieAcceptButton_Click;
            ((AddMovie)panel1.Controls["AddMovie"]).CancelButton.Click += AddMovieCancelButton_Click;
            
            /******************************
                     Load Settings
             ******************************/
            LoadSettings();
        }

        void User_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Text = User.FirstName + " " + User.LastName;
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

        private void User_MediaAdded(object sender, EventArgs e)
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
                japanesecartoon.Clear();
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
                showcontrol.Clear();
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
                cinema.Clear();
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
                    User.AddTask(addForm.GetSelectedTask());
                    //User.Calendar.GetMonth(addForm.Date.Month).GetDay(addForm.Date.Day).AddTask(addForm.GetSelectedTask());
                }
            }
        }

        private void loadUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog opDialog = new OpenFileDialog())
            {
                opDialog.Filter = "xml file (*.xml)|*.xml";
                if (opDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadUser(new FileStream(opDialog.FileName, FileMode.Open));
                }
            }
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserSetup uSetup = new UserSetup(User.Username, User.FirstName, User.LastName))
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

        private void ListViewSchedule_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 2)
            {
                //sorting algorithm of choice for date
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0: MonthLabel.Visible = true;
                    PreviousMonthButton.Visible = true;
                    NextMonthButton.Visible = true;
                    break;
                case 1: MonthLabel.Visible = false;
                    PreviousMonthButton.Visible = false;
                    NextMonthButton.Visible = false;
                    break;
                case 2: MonthLabel.Visible = false;
                    PreviousMonthButton.Visible = false;
                    NextMonthButton.Visible = false;
                    break;

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
        /// <summary>
        /// Sets all controls' in panel1 visible property to false
        /// </summary>
        private void HidePanel1Controls()
        {
            foreach (Control c in panel1.Controls)
            {
                c.Visible = false;
            }
        }

        private void MediaList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag == null)//Exits method if clicked node is one of the empty parent nodes
            {
                HidePanel1Controls();
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
                    DisplayEpisodeFiles(obj.URI);
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
                    DisplayEpisodeFiles(TVobj.URI);
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

        private void DisplayEpisodeFiles(Uri u)
        {
            if (Uri.UriSchemeFile == u.Scheme)
            {
               listBox1.Items.Clear();
               HidePanel1Controls();
               listBox1.Visible = true;
               string[] filenames = Directory.GetFiles(u.LocalPath);
               foreach (string s in filenames)
               {
                   listBox1.Items.Add(Path.GetFileName(s));
               }
            }
            else if (Uri.UriSchemeHttp == u.Scheme || Uri.UriSchemeHttps == u.Scheme)
            {
                HidePanel1Controls();
                webBrowser1.Visible = true;
            }
        }
        
        private void MediaList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (null == e.Node.Tag)//Exits method if clicked node is one of the empty parent nodes
            {
                return;
            }
            //Sets the media info control information corresponding to the selected listview node
            switch (e.Node.Parent.Text)
            {
                case "Anime": var obj = e.Node.Tag as Anime;//sets as anime object if in anime tree
                    LaunchMedia(obj.URI);
                    break;
                case "TV Shows":
                    var TVobj = e.Node.Tag as TVshow;//sets as anime object if in anime tree
                    LaunchMedia(TVobj.URI);
                    break;
                case "Movies":
                    var MOVobj = e.Node.Tag as Movie;//sets as anime object if in anime tree
                    HidePanel1Controls();
                    webBrowser1.Visible = true;
                    webBrowser1.Url = new Uri("http://www.imdb.com/");
                    break;
            }
        }

        private void MediaList_DoubleClick(object sender, EventArgs e)
        {

        }
        
        private void LaunchMedia(Uri u)
        {
            if (Uri.UriSchemeFile == u.Scheme)
            {
                
                videoplayer = Process.Start(u.AbsoluteUri);


                //videoplayer = Process.Start("C:\\Program Files (x86)\\Daum\\PotPlayer\\PotPlayerMini.exe");
                //videoplayer.WaitForInputIdle();
            }
            else if (Uri.UriSchemeHttp == u.Scheme || Uri.UriSchemeHttps == u.Scheme)
            {
                webBrowser1.Url = u;
            }
        }

        private void NextMonthButton_Click(object sender, EventArgs e)
        {
            //clears task calendar
            int counter = TaskCalendar.Rows.Count;
            for (int i = 0; i < counter; i++)
            {
                TaskCalendar.Rows.RemoveAt(0);
            }
            TaskCalendar.Rows.Add();//Adds one needed row to calendar to prevent exception in AddDatesToCalendar

            if ((int)MonthLabel.Tag == 12)
            {
                //Fixes calendar and month label display with rollover for next year
                AddDatesToCalendar(new DateTime(CurrentDate.Year + 1, 1, 1));       
            }
            else
            {
                //Fixes calendar and month label display
                AddDatesToCalendar(new DateTime(CurrentDate.Year, (int)MonthLabel.Tag + 1, 1));
            }

            foreach (Task t in User.Calendar.GetMonth(CurrentDate.Year, (int)MonthLabel.Tag).MonthTasks)
            {
                if (t != null)
                {
                    UpdateTaskCalendar(t);
                }               
            }
            
        }
        
        private void PreviousMonthButton_Click(object sender, EventArgs e)
        {
            //clears task calendar
            int counter = TaskCalendar.Rows.Count;
            for (int i = 0; i < counter; i++)
            {
                TaskCalendar.Rows.RemoveAt(0);
            }
            TaskCalendar.Rows.Add();//Adds one needed row to calendar to prevent exception in AddDatesToCalendar

            if ((int)MonthLabel.Tag == 1)
            {
                //Fixes calendar and month label display with rollover for previous year
                AddDatesToCalendar(new DateTime(CurrentDate.Year - 1, 12, 1));
            }
            else
            {
                //Fixes calendar and month label display
                AddDatesToCalendar(new DateTime(CurrentDate.Year, (int)MonthLabel.Tag - 1, 1));
            }

            foreach (Task t in User.Calendar.GetMonth(CurrentDate.Year, (int)MonthLabel.Tag).MonthTasks)
            {
                if (t != null)
                {
                    UpdateTaskCalendar(t);
                }
            }
        } 

        private void removeTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task rTask;
            if (ListViewSchedule.SelectedItems.Count == 0)
            {
                MessageBox.Show("No task selected", "Invalid Operation");
            }
            else
            {
                foreach (ListViewItem itm in ListViewSchedule.SelectedItems)
                {
                    rTask = itm.Tag as Task;
                    User.RemoveTask(rTask);
                    itm.Remove();
                }
            }
        }

        private void MonthLabel_SizeChanged(object sender, EventArgs e)
        {
            PreviousMonthButton.Left = MonthLabel.Left - (PreviousMonthButton.Width + control_padding);
            NextMonthButton.Left = MonthLabel.Right + control_padding;
        }

        private void removeMediaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == MediaList.SelectedNode || null == MediaList.SelectedNode.Parent)
            {
                MessageBox.Show("No Media Selected", "Invalid Operation");
                return;
            }
            else
            {
                User.RemoveMedia((Media)MediaList.SelectedNode.Tag);
                MediaList.SelectedNode.Remove();

                mediaInfo1.TitleLabel.Text = "Title";//sets title label
                mediaInfo1.StatusLabel.Text = "Status";//sets status label
                mediaInfo1.DownloadLabel.Visible = false;
                mediaInfo1.SetEpisodes(0, 1);//sets episodes to 1 to avoid divide by zero exception
                mediaInfo1.EpisodeLabel.Text = "ep/Ep";
                mediaInfo1.AirtimeLabel.Visible = false;
                mediaInfo1.richTextBoxDescription.Text = "";//sets description
                mediaInfo1.MediaInfo_Resize(mediaInfo1, new EventArgs());//Sets label in their correct positions
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm sForm = new SettingsForm())
            {
                if (sForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUserOnSetup = sForm.LoadUserOnSetup;
                    DefaultPath = sForm.LoadUserFilePath;

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    XmlWriter writer = XmlWriter.Create(new FileStream("SettingsXML.xml",FileMode.Open), settings);
                    writer.WriteStartDocument();
                    SaveSettings(writer);
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        private void saveUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sDialog = new SaveFileDialog())
            {
                sDialog.Filter = "xml file (*.xml)|*.xml";
                sDialog.FilterIndex = 2;

                if (sDialog.ShowDialog() == DialogResult.OK)
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    XmlWriter writer = XmlWriter.Create(sDialog.FileName, settings);

                    writer.WriteStartDocument();
                    writer.WriteStartElement("MyScheduler");

                    writer.WriteStartElement("User");//starts an element for the user
                    writer.WriteAttributeString("username", User.Username);
                    writer.WriteAttributeString("firstname", User.FirstName);
                    writer.WriteAttributeString("lastname", User.LastName);

                    foreach (Task t in User.Tasklist)//loop to write all the tasks to xml file
                    {
                        writer.WriteStartElement("Task");
                        writer.WriteAttributeString("name", t.Name);
                        writer.WriteAttributeString("description", t.Description);
                        writer.WriteStartAttribute("priority");
                        writer.WriteValue(t.Priority.ToString());
                        writer.WriteEndAttribute();
                        writer.WriteStartAttribute("date");
                        writer.WriteValue(t.Date);
                        writer.WriteEndAttribute();
                        writer.WriteStartAttribute("taskcomplete");
                        writer.WriteValue(t.TaskComplete);
                        writer.WriteEndAttribute();
                        if (t is Assignment)
                        {
                            writer.WriteAttributeString("course",((Assignment)t).Course);
                            writer.WriteAttributeString("material",((Assignment)t).MaterialCovered);
                            writer.WriteValue("Assignment");
                        }
                        else if (t is Lecture)
                        {
                            writer.WriteAttributeString("course",((Lecture)t).Course);
                            writer.WriteStartAttribute("length");
                            writer.WriteValue(((Lecture)t).Length);
                            writer.WriteEndAttribute();
                            foreach (DayOfWeek d in ((Lecture)t).Weekdays)
                            {
                                writer.WriteStartElement("days");
                                writer.WriteValue(d);
                                writer.WriteEndElement();
                            }
                            
                            writer.WriteValue("Lecture");
                        }
                        else
                        {
                            writer.WriteValue("Miscellaneous");
                        }
                        writer.WriteEndElement();
                    }

                    foreach (Media m in User.Medialist)//loop for every media object
                    {
                        writer.WriteStartElement("Media");
                        writer.WriteAttributeString("title", m.Title);
                        writer.WriteAttributeString("description", m.Description);
                        writer.WriteStartAttribute("status");
                        writer.WriteValue(m.Status.ToString());
                        writer.WriteEndAttribute();
                        if (m is Movie)
                        {
                            writer.WriteStartAttribute("runtime");
                            writer.WriteValue(((Movie)m).Runtime);
                            writer.WriteEndAttribute();
                            writer.WriteValue("Movie");
                        }
                        else if (m is TVshow)
                        {
                            var tv = m as TVshow;
                            writer.WriteStartAttribute("airtime");
                            writer.WriteValue(tv.Airtime);
                            writer.WriteEndAttribute();
                            writer.WriteStartAttribute("totalepisodes");
                            writer.WriteValue(tv.TotalEpisodes);
                            writer.WriteEndAttribute();
                            writer.WriteStartAttribute("watchedepisodes");
                            writer.WriteValue(tv.WatchedEpisodes);
                            writer.WriteEndAttribute();
                            writer.WriteStartAttribute("uri");
                            writer.WriteValue(tv.URI);
                            writer.WriteEndAttribute();
                            if (m is Anime)
                            {
                                writer.WriteStartAttribute("downloaded");
                                writer.WriteValue(((Anime)m).Downloaded);
                                writer.WriteEndAttribute();
                                writer.WriteValue("Anime");
                            }
                            else
                            {
                                writer.WriteValue("TVshow");
                            }
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    SaveSettings(writer);

                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (null == listBox1.SelectedItem)
            {
                return;
            }

            try
            {
                TVshow tv = (TVshow)MediaList.SelectedNode.Tag;
                videoplayer = Process.Start(tv.URI.AbsoluteUri + "/" + listBox1.SelectedItem.ToString());
            }
            catch(InvalidCastException)
            {
                return;
            }
        }
         
    }
}
