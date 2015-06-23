/* Author: Steele Warner
 * Created: June 9, 2015
 * Info: This is the Form program for the base UI for MyScheduler app
 * Last Updated: 6/23/2015
 * version: v0.2.1
 */

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

namespace MyScheduler
{
    public partial class MySchedulerForm : Form
    {
        //private MySchedulerCalendar DataCalendar = new MySchedulerCalendar();
        private MySchedulerUser User;
        private bool LoadUserOnSetup;
        private string SettingsURI;

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
            if ((int)MonthLabel.Tag == t.GetDate().Month)
            {
                DayOfWeek firstday = MySchedulerMonth.FindFirstDay(t.GetDate());
                int row = (int)(t.GetDate().Day / 7);
                int column = ((int)firstday + t.GetDate().Day - 1) % 7;
                TaskCalendar.Rows[row].Cells[column].Value += t.Name + Environment.NewLine;
                TaskCalendar.Rows[row].Cells[column].Tag = t;
            }
        }

        private void UpdateTaskScheduler(Task t)
        {
            ListViewItem itm = new ListViewItem(t.GetType().Name);
            itm.SubItems.Add(t.Name);
            itm.SubItems.Add(t.GetDate().ToString());
            itm.SubItems.Add(t.Description);
            ListViewSchedule.Items.Add(itm);
        }

        private void ListViewScheduleInitializer()
        {
            ListViewSchedule.View = View.Details;

            ColumnHeader[] colhead = new ColumnHeader[4];
            colhead[0].Text = "Task";
            colhead[1].Text = "Name";
            colhead[2].Text = "Date";
            colhead[3].Text = "Description";

            ListViewSchedule.Columns.AddRange(colhead);

            foreach (Task t in User.Tasklist)
            {
                ListViewItem itm = new ListViewItem(t.GetType().Name);
                itm.SubItems.Add(t.Name);
                itm.SubItems.Add(t.GetDate().ToString());
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

        }

        #region TabCalendar

        private void TabCalendar_Click(object sender, EventArgs e)
        {
            
        }

        #endregion TabCalendar

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
    }
}
