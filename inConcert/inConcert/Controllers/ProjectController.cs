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
            values.Add(new string[] { "A new project", "Some description" });
            values.Add(new string[] { "Another new project", "Some other description" });
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
                e.title = (string)row[0];
                e.description = (string)row[1];
                e.time = (long)row[2];
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
        public string TableTest()
        {
            List<List<object>> tableslist = DataAccess.DataAccess.ListTables();
            string rString = "";
            foreach (List<object> tables in tableslist)
            {
                foreach (object table in tables)
                {
                    if (!(table.ToString().StartsWith("Asp") || table.ToString().StartsWith("__")))
                    {
                        rString += table.ToString() + "<br />";
                        List<List<object>> columnslist = DataAccess.DataAccess.ListColumns(table.ToString());
                        foreach (List<object> columns in columnslist)
                        {
                            foreach (object column in columns)
                            {
                                rString += "---" + column.ToString() + "<br />";
                            }
                        }
                    }
                }
                rString += "<br />";
            }
            return rString;
        }
        public string Search(string keyword)
        {
            List<List<object>> results = new List<List<object>>{};
            List<List<object>> tableslist = DataAccess.DataAccess.ListTables();
            foreach (List<object> tables in tableslist)
            {
                foreach (object table in tables)
                {
                    if (!(table.ToString().StartsWith("Asp") || table.ToString().StartsWith("__")))
                    {
                        List<List<object>> columnslist = DataAccess.DataAccess.ListColumns(table.ToString());
                        foreach (List<object> columns in columnslist)
                        {
                            foreach (object column in columns)
                            {List<List<object>> queryresults =DataAccess.DataAccess.Read(Build.StringArray(table.ToString()), new string[] { }, Build.StringArray(column.ToString() + "=" + keyword));
                                List<List<object>> concatresults = results.Concat(queryresults).ToList();
                                results = concatresults;
                            }

                        }
                    }
                }
               
            }

            string rString = "";
            rString += results.Count + "<br />";
            foreach (List<object> row in results)
            {
                rString += row.Count + "<br />";
                foreach (object col in row)
                {
                    rString += col.ToString() + "<br />";
                }
            }
            return rString;
        }


    }
}