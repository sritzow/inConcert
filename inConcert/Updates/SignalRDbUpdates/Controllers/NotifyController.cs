using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRDbUpdates.Controllers
{
    public class NotifyController : Controller
    {
        // GET: Notify
        public string Index()
        {
            //List<string[]> values = new List<string[]>();
            //values.Add(new string[] {"A new project", "Some description"});
            //values.Add(new string[] {"Another new project", "Some other description"});
            //DataAccess.DataAccess.Create("projects", new string[] { "name", "description" }, values);        

            //DataAccess.DataAccess.Update("projects", new string[] { "name" }, new string[] { "UPDATED LOL" }, new string[] { "id = 4" });
            List<List<object>> result = DataAccess.DataAccess.Read(new string[] { "Messages" });
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
    }
}