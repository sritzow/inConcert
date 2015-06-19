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

        public string Test()
        {

            return User.Identity.GetUserId();
        }
    }
}