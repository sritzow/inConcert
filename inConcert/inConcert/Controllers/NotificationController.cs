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

namespace inConcert.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public string Index()
        {
            
            List<List<object>> result = DataAccess.DataAccess.Read(Build.StringArray("Notifications"));
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