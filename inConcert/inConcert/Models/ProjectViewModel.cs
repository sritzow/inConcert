using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace inConcert.Models
{
    public class ProjectViewModel
    {
        public List<ProjectAuth> auths { get; set; }
    }

    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<ProjectAuth> auths { get; set; }
        public List<Calendar> calendars { get; set; }
        public Chat chat { get; set; }
        public Notifications notifications { get; set; }
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
        public int calendarId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime occurencetime { get; set; }
        public DateTime time { get; set; }
    }

    public class Message
    {
        public int id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string body { get; set; }
        public string project { get; set; }
        public DateTime time { get; set; }
    }


    public class Notification
    {
        [Key]
        public int ID { get; set; }

        public string notificationMessage { get; set; }

        public DateTime TimeStamp { get; set; }

        public string notificationFrom { get; set; }
    }
    public class Notifications : DbContext
    {
        public List<Notification> Update { get; set; }
    }

    public class Contacts
    {

    }
   
    public class Chat
    {
        public List<Message> messages;
        public Message message;
        public Chat()
        {
            if (this.message == null)
            {
                this.message = new Message();
            }
        }
    }

    public class Search
    {
        public List<Message> messages = new List<Message>();
        public List<Event> events = new List<Event>();
        public List<User> users = new List<User>();
        public List<Project> projects = new List<Project>();
        public List<dynamic> others = new List<dynamic>();
        public string table { get; set; }
        public string keyword { get; set; }
    }

    public class Other
    {
        public string table { get; set; }
        public List<object> result = new List<object>();

    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
