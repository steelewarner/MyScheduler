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
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();
        }
        public AddTaskForm(DateTime day) : this()
        {
            _date = day;
            _timelength = new TimeSpan();
            _title = "";
            _desc = "";
            _course = "";
            _materialcovered = "";
        }

        private DateTime _date;
        private TimeSpan _timelength;
        private string _title;
        private string _desc;
        private string _course;
        private string _materialcovered;
        private Task _task;

        /// <summary>
        /// Gets the date that was entered for in the box labeled "Date"
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
        }
        /// <summary>
        /// Gets the TimeSpan object created from amount entered in "Length"
        /// </summary>
        public TimeSpan Timelength
        {
            get { return _timelength; }
        }
        /// <summary>
        /// Gets the name entered in the box labeled "Name"
        /// </summary>
        public string Title
        {
            get { return _title; }
        }
        /// <summary>
        /// Gets the description entered in the box labeled "Description"
        /// </summary>
        public string Description
        {
            get { return _desc; }
        }
        /// <summary>
        /// Gets the course name or number from the box labeled "Course"
        /// </summary>
        public string Course
        {
            get { return _course; }
        }
        /// <summary>
        /// Gets the newly created task with the entered parameters
        /// </summary>
        /// <returns>Task with entered parameters</returns>
        public Task GetSelectedTask()
        {
            return _task;
        }
        /// <summary>
        /// Creates new DateTime according to string
        /// </summary>
        /// <param name="date">Date in the form of a string in the MM/DD/YYYY format</param>
        /// <returns></returns>
        private DateTime ParseDateClock()
        {
            //string[] arr = date.Split('/');

            return new DateTime(int.Parse(dateClock1.textBox1.Text), int.Parse(dateClock1.textBox2.Text),
                int.Parse(dateClock1.textBox3.Text), int.Parse(dateClock1.textBox4.Text), int.Parse(dateClock1.textBox5.Text), 0);
        }

        private void DisplayAssignmentUI()
        {
            label3.Text = "Course";
            label4.Text = "Due Date";
            label5.Text = "Material Covered";

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = true;
            numericUpDown1.Visible = false;
            dateTimePicker1.Visible = true;
            dateClock1.Visible = false;
        }

        private void DisplayLectureUI()
        {
            label3.Text = "Course";
            label4.Text = "Start Time";
            label5.Text = "Length (Minutes)";
            dateClock1.textBox1.Text = "MM";
            dateClock1.textBox2.Text = "DD";
            dateClock1.textBox3.Text = "YYYY";
            dateClock1.textBox4.Text = "hh";
            dateClock1.textBox5.Text = "mm";

            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            dateTimePicker1.Visible = false;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            numericUpDown1.Visible = true;
            dateClock1.Visible = true;
        }

        private void DisplayMiscellaneousUI()
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            numericUpDown1.Visible = false;
            dateTimePicker1.Visible = false;
            dateClock1.Visible = false;
        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {
            textBox4.Text = "MM/DD/YYYY";
            DisplayAssignmentUI();
            listBox1.SelectedItem = listBox1.Items[0];
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0: DisplayAssignmentUI();
                    break;
                case 1: DisplayLectureUI();
                    break;
                case 2: DisplayMiscellaneousUI();
                    break;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                _title = TitleTextBox.Text;
                _desc = DescriptionTextBox.Text;
                _course = textBox3.Text;
                _date = dateTimePicker1.Value;
                _materialcovered = textBox5.Text;

                switch (listBox1.SelectedIndex)
                {
                    case 0: _task = new Assignment(_title, _desc, _course, _date);
                        break;
                    case 1: _date = ParseDateClock();
                        _task = new Lecture(_title, _desc, _course, _date, _timelength);
                        break;
                    case 2: _task = new Miscellaneous(_title, _desc);
                        break;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(FormatException)
            {
                MessageBox.Show("Incorrect Input", "Unacceptable Format");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
