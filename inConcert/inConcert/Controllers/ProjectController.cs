using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using inConcert.Models;
using System.Collections.Generic;
using inConcert.Helper;
using inConcert.Models;

namespace inConcert.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ProjectController()
        {
        }

        public ProjectController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public string Index()
        {
            List<string[]> values = new List<string[]>();
            values.Add(new string[] {"A new project", "Some description"});
            values.Add(new string[] {"Another new project", "Some other description"});
            //DataAccess.DataAccess.Create("projects", new string[] { "name", "description" }, values);        

            DataAccess.DataAccess.Update("projects", new string[] { "name" }, new string[] { "UPDATED LOL" }, new string[] { "id = 4" });
            List<List<object>> result = DataAccess.DataAccess.Read(Build.StringArray("projects"));
            string rString = "";
            rString += result.Count + "<br />";
            foreach (List<object> row in result)
            {
                rString += row.Count + "<br />";
                foreach (object col in row)
                {
                    rString += col.ToString() + "<br />";
                }
            }
            return rString;
            
        }

        public string Project(int id)
        {
            Session["ProjectViewed"] = id;
            if (Authorized(id))
                return "Authorized";
            return "Not Authorized";
        }

        private bool Authorized(int projectId)
        {
            List<List<object>> result = DataAccess.DataAccess.Read(Build.StringArray("project_users"), Build.StringArray("*"), Build.StringArray("project_id = " + projectId, "user_id = '" + User.Identity.GetUserId() + "'"));
            return result.Count > 0;  
        }

        public ActionResult Tester()
        {
            Project project = new Project();
            project.calendars = new List<Calendar>();
            project.auths = new List<ProjectAuth>();
            project.description = "This is a static description not being pulled from the database.";
            project.name = "This is a static name";

            List<List<object>> calendarResult = DataAccess.DataAccess.Read(Build.StringArray("Calendars"), Build.StringArray("id"), Build.StringArray("id = 1"));
            foreach (List<object> calendar in calendarResult)
            {
                Calendar cal = new Calendar();
                cal.id = (int) calendar[0];
                cal.events = new List<Event>();
                List<List<object>> eventResult = DataAccess.DataAccess.Read(Build.StringArray("Events"), Build.StringArray("id", "calendar_id", "title", "description", "time"), Build.StringArray("calendar_id = " + cal.id));
                foreach (List<object> evt in eventResult)
                {
                    Event e = new Event();
                    e.id = (int) evt[0];
                    e.calendarId = (int) evt[1];
                    e.title = (string)evt[2];
                    e.description = (string)evt[3];
                    e.time = (long)evt[4];
                    cal.events.Add(e);
                }
                project.calendars.Add(cal);
            }
            

            return View("Mock", project);
        }

        public ActionResult CreateEvent(string title, string description, string time)
        {
            List<string[]> values = new List<string[]>();
            values.Add(Build.StringArray(title, description, time));

            DataAccess.DataAccess.Create("Events", Build.StringArray("title, description, time"), values);
            return Redirect("Tester");
        }

        public ActionResult CalendarTest()
        {
            List<List<object>> result = DataAccess.DataAccess.Read(Build.StringArray("Calendars", "Events"), Build.StringArray("Events.title", "Events.description", "Events.time"), Build.StringArray("Calendars.project_id = 2", "Events.calendar_id = Calendars.id"));
            string rString = "";
            rString += result.Count + "<br />";
            Calendar calendar = new Calendar();
            calendar.events = new List<Event>();
            foreach (List<object> row in result)
            {
                Event e = new Event();
                e.title = (string) row[0];
                e.description = (string) row[1];
                e.time = (long) row[2];
                calendar.events.Add(e);
                rString += row.ToString() + "<br />";
                
                foreach (object col in row)
                {
                    rString += col.ToString() + "<br />";
                }
            }
            return View("Calendar", calendar);
        }
        public void DeleteTest()
        {
            object result = DataAccess.DataAccess.Delete("Events", Build.StringArray("calendar_id=1"));
            
        }

        public string Test()
        {

            return User.Identity.GetUserId();
        }

        public ActionResult Chat()
        {
            Chat chat = new Chat();
            List<List<object>> result = DataAccess.DataAccess.Read(Build.StringArray("messages"), Build.StringArray("*"));
            chat.messages = new List<Message>();

            foreach (List<object> row in result)
            {
                Message msg = new Message();
                msg.from = (string)row[1];
                msg.to = (string)row[2];
                msg.body = (string)row[3];
                msg.project = (string)row[4];
                chat.messages.Add(msg);
            }

            return View("chat", chat);

        }
        public ActionResult CreateMessage()
        {
            return View("CreateMessage");
        }

        public ActionResult GenerateMessage()
        {
            throw new NotImplementedException();
        }
    }
}