using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class ProjectViewModel
    {
        
    }

    public class Project
    {
        public int id { get; set; }
        public int name { get; set; }
        public int description { get; set; }
        public List<ProjectAuth> auths { get; set; }
        public List<Calendar> calendars { get; set; }
    }

    public class ProjectAuth
    {
        public int projectId { get; set; }
        public int userId { get; set; }
        public int permessions { get; set; }
    }

    public class Calendar
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public string name { get; set; }
        public List<Event> events { get; set; }
        public List<Milestone> milestones { get; set; }
    }

    public class Milestone
    {
        public int id { get; set; }
        public int calendarId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<Tasks> tasks { get; set; }
    }

    public class Tasks
    {
        public int id { get; set; }
        public int milestoneId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int hours { get; set; }
        public List<TaskUser> taskUsers { get; set; }
    }

    public class TaskUser
    {
        public int id { get; set; }
        public int taskId { get; set; }
        public int userId { get; set; }
    }

    public class Event
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public long time { get; set; }
    }
}