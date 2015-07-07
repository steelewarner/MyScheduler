/* Author: Steele Warner
 * Created: June 9, 2015
 * Info: This is the class library for MyScheduler app. It includes User, Task, Media, and Calenedar objects
 * Last Updated: 7/6/15
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MyScheduler
{
    public enum PriorityStatus { Low = 0, Medium = 1, High = 2 };
    public enum ShowStatus { Airing, FinishedAiring, Completed, PlanToWatch };
    
    public sealed class MySchedulerUser : INotifyPropertyChanged
    {
        /// <summary>
        /// Creates a new user with given parameters
        /// </summary>
        /// <param name="username">Username of new user</param>
        /// <param name="fname">First name of new user</param>
        /// <param name="lname">Last name of new user</param>
        public MySchedulerUser(string username, string fname, string lname)
        {
            _username = username;
            _firstname = fname;
            _lastname = lname;
            _taskList = new List<Task>();
            _medialist = new List<Media>();
            _calendar = new MySchedulerCalendar();
            _calendar.TaskAdded += _calendar_TaskAdded;
            _calendar.TaskRemoved += _calendar_TaskRemoved;
        }

        private void _calendar_TaskRemoved(object sender, EventArgs e)
        {
            
        }

        private void _calendar_TaskAdded(object sender, EventArgs e)
        {
            //AddTask(((TaskEventArgs)e).ArgsTask);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler TaskCreated;
        public event EventHandler TaskRemoved;
        public event EventHandler TaskCompleted;
        public event EventHandler MediaAdded;
        public event EventHandler MediaRemoved;

        private string _username;
        private string _firstname;
        private string _lastname;
        private List<Task> _taskList;
        private List<Media> _medialist;
        private MySchedulerCalendar _calendar;

        /// <summary>
        /// Handler for when a new task is created
        /// </summary>
        /// <param name="newTask">Task that was just created</param>
        private void OnTaskCreated(Task newTask)
        {
            EventHandler handler = TaskCreated;
            if (handler != null)
            {
                handler(this, new TaskEventArgs(newTask));
            }
        }

        private void OnTaskRemoved(Task removedTask)
        {
            EventHandler handler = TaskRemoved;
            if (null != handler)
            {
                handler(this, new TaskEventArgs(removedTask));
            }
        }

        private void OnTaskCompleted(Task completedTask)
        {
            EventHandler handler = TaskCompleted;
            if (handler != null)
            {
                handler(this, new TaskEventArgs(completedTask));
            }
        }

        private void OnMediaAdded(Media addedMedia)
        {
            EventHandler handler = MediaAdded;
            if (handler != null)
            {
                handler(this, new MediaEventArgs(addedMedia));
            }
        }

        private void OnMediaRemoved(Media removeMedia)
        {
            EventHandler handler = MediaRemoved;
            if (null != handler)
            {
                handler(this, new MediaEventArgs(removeMedia));
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// Gets or sets the username of this user
        /// </summary>
        public string Username
        {
            get { return _username; }
            set 
            { 
                if (_username != value)
                { 
                    _username = value;
                    OnPropertyChanged("Username");
                }
                
            }
        }
        /// <summary>
        /// Gets or sets the user's first name
        /// </summary>
        public string FirstName
        {
            get { return _firstname; }
            set 
            {
                if (_firstname !=  value)
                {
                    _firstname = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        /// <summary>
        /// Gets or sets the user's last name
        /// </summary>
        public string LastName
        {
            get { return _lastname; }
            set 
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        /// <summary>
        /// Gets the list of tasks this user has
        /// </summary>
        public List<Task> Tasklist
        {
            get { return _taskList; }
        }
        /// <summary>
        /// Gets the list containing all media objects for this user
        /// </summary>
        public List<Media> Medialist
        {
            get { return _medialist; }
        }
        /// <summary>
        /// Gets this User's calendar
        /// </summary>
        public MySchedulerCalendar Calendar
        {
            get { return _calendar; }
        }
        /// <summary>
        /// Adds a new task to this user's task list if the list does not already contain that task
        /// </summary>
        /// <param name="t">Task to be added</param>
        public void AddTask(Task t)
        {
            if (!_taskList.Contains(t))
            {
                _taskList.Add(t);
                this._calendar.GetMonth(t.Date.Year, t.Date.Month).GetDay(t.Date.Day).AddTask(t);
                OnTaskCreated(t);
                _taskList[_taskList.Count - 1].TaskCompleted += MySchedulerUser_TaskComplete;
            }
        }
        /// <summary>
        /// Adds a new media object to Medialist. Does not add duplicates.
        /// </summary>
        /// <param name="m">media object to be added</param>
        public void AddMedia(Media m)
        {
            if (_medialist.Contains(m))
            {
                return;
            }
            _medialist.Add(m);
            OnMediaAdded(m);
        }
        /// <summary>
        /// Removes task from task list and calendar
        /// </summary>
        /// <param name="t">Task to be removed</param>
        public void RemoveTask(Task t)
        {
            _taskList.Remove(t);
            this._calendar.GetMonth(t.Date.Year, t.Date.Month).GetDay(t.Date.Day).RemoveTask(t);
            OnTaskRemoved(t);
        }
        /// <summary>
        /// Removes media item from media list
        /// </summary>
        /// <param name="m">Media item to be removed</param>
        public void RemoveMedia(Media m)
        {
            _medialist.Remove(m);
            OnMediaRemoved(m);
        }

        public void MySchedulerUser_TaskComplete(object sender, EventArgs e)
        {
            OnTaskCompleted(((TaskEventArgs)e).ArgsTask);
            _taskList.Remove(((TaskEventArgs)e).ArgsTask);
        }
        public override bool Equals(object obj)
        {
            try
            {
                if (this.Username.Equals(((MySchedulerUser)obj).Username))
                {
                    return true;
                }
            }
            catch (InvalidCastException) { return false; }
            return false;
        }
    }

    #region Tasks


    public class TaskEventArgs : EventArgs
    {
        public TaskEventArgs(Task newTask) : base()
        {
            _task = newTask;
        }

        private Task _task;
        /// <summary>
        /// Gets a copy of the task that launched the event
        /// </summary>
        public Task ArgsTask
        {
            get { return _task; }
        }
    }

    /// <summary>
    /// Base Task class for object used in to-do list, calendar
    /// </summary>
    public abstract class Task
    {
        protected Task(string name, string description)
        {
            _name = name;
            _description = new StringBuilder(description);
            _priority = PriorityStatus.Medium;
            _taskcomplete = false;
        }
        public override bool Equals(object obj)
        {
            if (this.Name.Equals(((Task)obj).Name) && this.Description.Equals(((Task)obj).Description)
                    && this.Date.Equals(((Task)obj).Date)) 
            { return true; }
            return false;
        }

        public event EventHandler TaskCompleted;
        protected bool _taskcomplete;
        protected string _name;//name of task
        protected StringBuilder _description;//description of task
        protected  PriorityStatus _priority;//the priority of the task
        protected DateTime _date;

        /// <summary>
        /// Gets or sets the name of the task
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Gets or sets the string for the description of the task
        /// </summary>
        public string Description
        {
            get { return _description.ToString(); }
            set
            {
                _description.Clear();
                _description = new StringBuilder(value);
            }
        }
        /// <summary>
        /// Gets or sets the priority for this task
        /// </summary>
        public PriorityStatus Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        /// <summary>
        /// Gets or sets the date for this task
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        /// <summary>
        /// Gets or sets whether the task is finished and triggers TaskCompleted event
        /// </summary>
        public bool TaskComplete
        {
            get { return _taskcomplete; }
            set 
            { 
                _taskcomplete = value;
                if (value)
                {
                    OnTaskComplete();
                }
            }
        }

        protected void OnTaskComplete()
        {
            EventHandler handler = TaskCompleted;
            if (handler != null)
            {
                handler(this, new TaskEventArgs(this));
            }
        }
        /// <summary>
        /// Converts a string to PriorityStatus
        /// </summary>
        /// <param name="str">string to be converted</param>
        /// <returns></returns>
        public static PriorityStatus StringToPriorityStatus(string str)
        {
            switch(str)
            {
                case "High": return PriorityStatus.High;
                case "Medium": return PriorityStatus.Medium;
                case "Low": return PriorityStatus.Low;
            }
            return 0;
        }
    }

    public class Miscellaneous : Task
    {
        public Miscellaneous(string name, string desc) : base(name, desc)
        {

        }

    }

    /// <summary>
    /// A task that is in the form of an assignment (ie Homework, Quiz, Test, etc)
    /// </summary>
    public class Assignment : Task
    {
        public Assignment(string name, string desc, string course, DateTime due) : base(name, desc)
        {
            _course = course;
            _date = due;
            _materialcovered = new StringBuilder(string.Empty);
        }
        public Assignment(string name, string desc, string course, DateTime due, string material) : base(name, desc)
        {
            _course = course;
            _date = due;
            _materialcovered = new StringBuilder(material);
        }

        private string _course;
        //private DateTime _duedate;
        private StringBuilder _materialcovered;

        /// <summary>
        /// Gets or sets the course for which the assignment was assigned
        /// </summary>
        public string Course
        {
            get { return _course; }
            set { _course = value; }
        }
        /// <summary>
        /// Gets or sets the material covered for this assignment
        /// </summary>
        public string MaterialCovered
        {
            get { return _materialcovered.ToString(); }
            set
            {
                _materialcovered.Clear();
                _materialcovered.Append(value);
            }
        }
    }

    public class Lecture : Task
    {
        public Lecture(string name, string desc, string course, DateTime time, TimeSpan length) : base(name, desc)
        {
            _course = course;
            _date = time;
            _length = length;
            _days = new List<DayOfWeek>();
        }

        private string _course;
        private TimeSpan _length;
        private List<DayOfWeek> _days;

        /// <summary>
        /// Gets or sets the lecture course name or number
        /// </summary>
        public string Course
        {
            get { return _course; }
            set { _course = value; }
        }

        /// <summary>
        /// Gets or sets the length of the lecture
        /// </summary>
        public TimeSpan Length
        {
            get { return _length; }
            set { _length = value; }
        }
        /// <summary>
        /// Gets the list of days of the week the lecture is on
        /// </summary>
        public List<DayOfWeek> Weekdays
        {
            get { return _days; }
        }

        /// <summary>
        /// Adds a day of the week for the lecture
        /// </summary>
        /// <param name="weekday">Day to be added</param>
        public void AddDays(DayOfWeek weekday)
        {
            if (!_days.Contains(weekday))
            {
                _days.Add(weekday);
            }
        }
        public void AddDays(string weekday)
        {
            switch(weekday)
            {
                case "Sunday": AddDays(DayOfWeek.Sunday);
                    break;
                case "Monday": AddDays(DayOfWeek.Monday);
                    break;
                case "Tuesday": AddDays(DayOfWeek.Tuesday);
                    break;
                case "Wednesday": AddDays(DayOfWeek.Wednesday);
                    break;
                case "Thursday": AddDays(DayOfWeek.Thursday);
                    break;
                case "Friday": AddDays(DayOfWeek.Friday);
                    break;
                case "Saturday": AddDays(DayOfWeek.Saturday);
                    break;
            }
        }
        /// <summary>
        /// Removes the specific day of the week from lecture days
        /// </summary>
        /// <param name="weekday">day to be removed</param>
        public void RemoveDays(DayOfWeek weekday)
        {
            if (_days.Contains(weekday))
            {
                _days.Remove(weekday);
            }
        }
        /// <summary>
        /// Number of days the lecture appears per week
        /// </summary>
        /// <returns></returns>
        public int NumberofDays()
        {
            return _days.Count;
        } 
    }


    #endregion Tasks

    #region Media

    public class MediaEventArgs : EventArgs
    {
        public MediaEventArgs(Media m) : base()
        {
            medObject = m;
        }

        private Media medObject;
        /// <summary>
        /// Gets a copy of the media object that was added to medialist
        /// </summary>
        public Media ArgsMedia
        {
            get { return medObject; }
        }
    }

    /// <summary>
    /// Base class for media object, ie tv show/movie/song
    /// </summary>
    public abstract class Media
    {
        public Media(string title)
        {
            _title = title;
            _description = string.Empty;
            _status = ShowStatus.PlanToWatch;
        }
        public Media(string title, string description)
        {
            _title = title;
            _description = description;
            _status = ShowStatus.PlanToWatch;
        }

        public event EventHandler StatusChanged;
 
        protected string _title;
        protected ShowStatus _status;
        protected string _description;
        //Add a genre field

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// Gets or sets the description of this media object
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public ShowStatus Status
        {
            get { return _status; }
            set 
            { 
                if (_status != value)
                {
                    _status = value;
                    OnStatusChanged(value);
                }
                 
            }
        }

        private void OnStatusChanged(ShowStatus status)
        {
            EventHandler handler = StatusChanged;
            if (handler != null)
            {
                handler(this, new StatusChangedEventArgs(status));
            }
        }

        public override bool Equals(object obj)
        {
            try
            {
                if (this.Title.Equals(((Media)obj).Title) && this.Description.Equals(((Media)obj).Description))
                {
                    return true;
                }
            }
            catch (InvalidCastException)
            {
                return false;
            }
            return false;
        }
        public static ShowStatus StringToStatus(string stringtostatus)
        {
            switch (stringtostatus)
            {
                case "Airing": return ShowStatus.Airing;
                case "FinishAiring": return ShowStatus.FinishedAiring;
                case "Completed": return ShowStatus.Completed;
                case "PlanToWatch": return ShowStatus.PlanToWatch;
            }
            return 0;
        }
    }

    internal sealed class StatusChangedEventArgs: EventArgs
    {
        /// <summary>
        /// Event args for status change in media object
        /// </summary>
        /// <param name="status">New status of media object</param>
        public StatusChangedEventArgs(ShowStatus status) : base()
        {
            _status = status;
        }

        private ShowStatus _status;
        /// <summary>
        /// Gets the new status of the media object
        /// </summary>
        public ShowStatus Status
        {
            get { return _status; }
        }
    }

    /// <summary>
    /// Anime object inherited from the media class
    /// </summary>
    public class Anime : TVshow
    {
        public Anime(string title, DateTime airtime, int episodes) : base(title, airtime, episodes)
        {
            _downloaded = false;
        }

        public event EventHandler DownloadCompleted;

        private bool _downloaded;

        /// <summary>
        /// Whether the episode has been downloaded or not
        /// </summary>
        public bool Downloaded
        {
            get { return _downloaded; }
            set 
            { 
                _downloaded = value;
                if (value)
                {
                    OnDownloadComplete();   
                }
            }
        }

        private void OnDownloadComplete()
        {
            EventHandler handler = DownloadCompleted;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
    /// <summary>
    /// Class for Movie objects
    /// </summary>
    public class Movie : Media
    {
        public Movie(string title, int movielength) : base(title)
        {
            _runtime = movielength;
        }

        private int _runtime;

        /// <summary>
        /// Gets or sets the movie runtime in seconds
        /// </summary>
        public int Runtime
        {
            get { return _runtime; }
            set { _runtime = value; }
        }
    }
    /// <summary>
    /// Class for a TV show object
    /// </summary>
    public class TVshow : Media
    {
        public TVshow(string title, DateTime airtime, int totalepisodes) : base(title)
        {
            _airtime = airtime;
            _totalEpisodes = totalepisodes;
            _watchedEpisodes = 0;
            //_uri = new Uri(Uri.UriSchemeFile);
        }

        public event EventHandler EpisodeWatched;

        protected DateTime _airtime;
        protected int _totalEpisodes;
        protected int _watchedEpisodes;
        protected Uri _uri;

        /// <summary>
        /// Time for when the first episode airs
        /// </summary>
        public DateTime Airtime
        {
            get { return _airtime; }
            set { _airtime = value; }
        }
        /// <summary>
        /// Total number of episodes this show has
        /// </summary>
        public int TotalEpisodes
        {
            get { return _totalEpisodes; }
            set { _totalEpisodes = value; }
        }
        /// <summary>
        /// Number of episodes watched by the user
        /// </summary>
        public int WatchedEpisodes
        {
            get { return _watchedEpisodes; }
            set 
            { 
                if (_watchedEpisodes != value)
                {
                    _watchedEpisodes = value;
                    OnEpisodeWatched(value);
                }
                 
            }
        }
        /// <summary>
        /// Gets or sets the uri/path for this show
        /// </summary>
        public Uri URI
        {
            get { return _uri; }
            set { _uri = value; }
        }

        private void OnEpisodeWatched(int episode_number)
        {
            EventHandler handler = EpisodeWatched;
            if (handler != null)
            {
                handler(this, new EpisodeWatchedEventArgs(episode_number));
            }
        }
    }

    internal sealed class EpisodeWatchedEventArgs : EventArgs
    {
        public EpisodeWatchedEventArgs(int episode_number) : base()
        {
            _episodewatched = episode_number;
        }

        private int _episodewatched;
        /// <summary>
        /// Gets the episode number that was just watched
        /// </summary>
        public int EpisodeWatched
        {
            get { return _episodewatched; }
        }
    }

    #endregion Media

    #region Alerts

    /// <summary>
    /// Base class used for alerts for the user
    /// </summary>
    public abstract class Alert
    {

    }

    /*A GOOD ALERT WOULD BE IF THE UI CALENDAR IS OUTSIDE OF DATA CALENDAR*/

    #endregion Alerts

    #region Calendar

    /// <summary>
    /// Represents and stores one calendar year of MyScheduler objects
    /// </summary>
    public class MySchedulerCalendar
    {
        public MySchedulerCalendar()
        {
            //_months = new MySchedulerMonth[12];
            _years = new Dictionary<int, MySchedulerMonth[]>();
        }

        public event EventHandler TaskAdded;
        public event EventHandler TaskRemoved;

        //private MySchedulerMonth[] _months;
        private Dictionary<int, MySchedulerMonth[]> _years;
        /// <summary>
        /// Gets the month from the corresponding month number
        /// </summary>
        /// <param name="month_number">number of the month desired</param>
        /// <returns></returns>
        public MySchedulerMonth GetMonth(int year, int month_number)
        {
            if (month_number > 0 && month_number < 13)
            {
                try
                {
                    if (null == _years[year][month_number - 1])
                    {
                        SetMonth(year, new MySchedulerMonth(new DateTime(year, month_number, 1)));
                    }
                    return _years[year][month_number - 1];
                }
                catch(KeyNotFoundException)
                {
                    SetMonth(year, new MySchedulerMonth(new DateTime(year, month_number, 1)));
                    return _years[year][month_number - 1];
                }
                
            }

            return null;
        }
        /// <summary>
        /// Sets the month that is passed by value
        /// </summary>
        /// <param name="month">Month to be added to calendar</param>
        public void SetMonth(int year, MySchedulerMonth month)
        {
            try
            {
                if (null == _years[year])
                {
                    _years.Add(year, new MySchedulerMonth[12]);
                }
            }
            catch(KeyNotFoundException)
            {
                _years.Add(year, new MySchedulerMonth[12]);
            }
            _years[year][month.Month - 1] = month;
            _years[year][month.Month - 1].TaskAdded += MySchedulerCalendar_TaskAdded;
            _years[year][month.Month - 1].TaskRemoved += MySchedulerCalendar_TaskRemoved;
        }

        
        /// <summary>
        /// Checks if there is already a specific month set in this calendar
        /// </summary>
        /// <param name="monthnumber">number of the year the month is</param>
        /// <returns></returns>
        public bool isMonthSet(int year, int monthnumber)
        {
            try
            {
                return (_years[year][monthnumber - 1] != null);
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch(NullReferenceException)
            {
                return false;
            }
            catch(KeyNotFoundException)
            {
                return false;
            }
        }
        /// <summary>
        /// Initializes all months for the specified calendar year
        /// </summary>
        /// <param name="year">Given year for the calendar</param>
        public void CreateFullCalendar(int year)
        {
            for (int i = 1; i < 13; i++)
            {
                if (!isMonthSet(year, i))
                {
                    this.SetMonth(year, new MySchedulerMonth(new DateTime(year, i, 1)));
                    //this.GetMonth(i).TaskAdded += MySchedulerCalendar_TaskAdded;
                }
            }
        }

        void MySchedulerCalendar_TaskAdded(object sender, EventArgs e)
        {
            EventHandler handler = TaskAdded;
            if (null != handler)
            {
                handler(sender, e);
            }
        }
        void MySchedulerCalendar_TaskRemoved(object sender, EventArgs e)
        {
            EventHandler handler = TaskRemoved;
            if (null != handler)
            {
                handler(sender, e);
            }
        }
    }

    public class MySchedulerMonth
    {
        /// <summary>
        /// Creates a new instance of MySchedulerMonth
        /// </summary>
        /// <param name="FirstDay">The first day of the month</param>
        public MySchedulerMonth(DateTime FirstDay)
        {
            _month = FirstDay.Month;
            _numberofdays = DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month);
            _days = new MySchedulerDay[31];
            InitializeMonth(FirstDay);
            _tasks = new List<Task>();
        }

        public event EventHandler TaskAdded;
        public event EventHandler TaskRemoved;
        private int _month;
        private int _numberofdays;
        private List<Task> _tasks;
        private MySchedulerDay[] _days;//An array of all the days within the month
                                       //Data layer will not be in a form of a calendar

        /// <summary>
        /// Gets or sets the month as an integer
        /// </summary>
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }
        /// <summary>
        /// Gets the number of days this month has
        /// </summary>
        public int NumberOfDays
        {
            get { return _numberofdays; }
        }
        /// <summary>
        /// Gets the list of the tasks for this month
        /// </summary>
        public List<Task> MonthTasks
        {
            get { return _tasks; }
        }

        private void InitializeMonth(DateTime FirstDay)
        {
            for (int i = 0; i < _numberofdays; i++)//Initializes each day object and sets their events
            {
                _days[i] = new MySchedulerDay(FirstDay.AddDays(i));
                _days[i].TaskAdded += MySchedulerMonth_TaskAdded;
                _days[i].TaskRemoved += MySchedulerMonth_TaskRemoved;
            }
        }

        void MySchedulerMonth_TaskRemoved(object sender, EventArgs e)
        {
            _tasks.Remove(((TaskEventArgs)e).ArgsTask);//removes task from month task list
            EventHandler handler = TaskRemoved;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        private void MySchedulerMonth_TaskAdded(object sender, EventArgs e)
        {
            _tasks.Add(((TaskEventArgs)e).ArgsTask);//Adds task to month task list
            EventHandler handler = TaskAdded;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
        /// <summary>
        /// Gets the list of days objects
        /// </summary>
        public MySchedulerDay GetDay(int date)
        {
            try
            {
                return _days[date - 1];
            }
            catch(IndexOutOfRangeException)
            {
                return null;
            }
        }
        /// <summary>
        /// Returns the month number as it's name
        /// </summary>
        /// <returns>A string of the month's name</returns>
        public override string ToString()
        {
            switch (_month)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
            }
            return "No Month Selected";
        }
        /// <summary>
        /// Takes in an integer and returns the correct name of the month
        /// </summary>
        /// <param name="MonthNumber">Number representation of a month</param>
        /// <returns>Name of the month or Incorrect Input if out of range</returns>
        public static string IntToString(int MonthNumber)
        {
            switch (MonthNumber)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
            }
            return "Incorrect Input";
        }
        /// <summary>
        /// Finds the weekday of the first day of the month given the datetime of today
        /// </summary>
        /// <param name="today">Today's datetime</param>
        /// <returns>Returns the day of the week of the first day</returns>
        public static DayOfWeek FindFirstDay(DateTime today)
        {
            /*
            if (today.Day.Equals(1))
            {
                return today.DayOfWeek;
            }
            
            int x = (today.Day - 1) % 7;
            return (DayOfWeek)(today.DayOfWeek - x);//this produced a negative number on sunday june 28 but never any other time
            */
            return (new DateTime(today.Year, today.Month, 1)).DayOfWeek;
        }
        /// <summary>
        /// Takes in a string of a month's name and returns the corresponding integer
        /// </summary>
        /// <param name="monthname">Name of month</param>
        /// <returns>month as an int, 0 if incorrect input</returns>
        public static int StringToInt(string monthname)
        {
            switch (monthname.ToLower())
            {
                case "january": return 1;
                case "february": return 2;
                case "march": return 3;
                case "april": return 4;
                case "may": return 5;
                case "june": return 6;
                case "july": return 7;
                case "august": return 8;
                case "september": return 9;
                case "october": return 10;
                case "november": return 11;
                case "december": return 12;
                default: return 0;
            }
        }
    }

    public class MySchedulerDay
    {
        public MySchedulerDay(DateTime date)
        {
            _tasklist = new List<Task>();
            _date = date;
        }

        public event EventHandler TaskAdded;
        public event EventHandler TaskRemoved;
        private List<Task> _tasklist;
        private DateTime _date;


        private void OnTaskAdd(Task t)
        {
            EventHandler handler = TaskAdded;
            if (handler != null)
            {
                handler(this, new TaskEventArgs(t));
            }
        }
        private void OnTaskRemove(Task t)
        {
            EventHandler handler = TaskRemoved;
            if (handler != null)
            {
                handler(this, new TaskEventArgs(t));
            }
        }
        /// <summary>
        /// Gets list of tasks for the day
        /// </summary>
        public List<Task> Tasklist
        {
            get { return _tasklist; }
        }
        /// <summary>
        /// Adds a task to this day's tasklist
        /// </summary>
        /// <param name="newTask">Task to be added</param>
        public void AddTask(Task newTask)
        {
            _tasklist.Add(newTask);
            OnTaskAdd(newTask);
        }
        /// <summary>
        /// Removes the task from the tasklist
        /// </summary>
        /// <param name="oldTask">Desired task to be removed</param>
        public void RemoveTask(Task oldTask)
        {
            _tasklist.Remove(oldTask);
            OnTaskRemove(oldTask);
        }
        /// <summary>
        /// Gets the day's date
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
        }
        /// <summary>
        /// Gets the day of the week
        /// </summary>
        public DayOfWeek WeekDay
        {
            get { return _date.DayOfWeek; }
        }
    }

    #endregion Calendar
}