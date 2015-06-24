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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace inConcert.Controllers
{

        public class NotificationController : Controller
    {

        public ActionResult Index()
        {

            List<List<object>> result = DataAccess.DataAccess.Read(Build.StringArray("Notifications"));

            Notifications Notify = new Notifications();
            Notify.Update = new List<Notification>();

            foreach (List<object> row in result)
            {
                Notification x = new Notification();
                x.notificationMessage = (string)row[1];
                x.ID = (int)row[0];
                x.TimeStamp = (DateTime)row[2];
                Notify.Update.Insert(0,x);
            }
                        
          

            return View("Index",Notify);
            

        }



        //readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //public IEnumerable<Notification> Index()
        //{
        //    var notifications = new List<Notification>();
        //    using (var connection = new SqlConnection(_connString))
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand(@"SELECT [ID], [Notification], [TimeStamp] FROM [dbo].[Notifications]", connection))
        //        {
        //            command.Notification = null;

        //            //var dependency = new SqlDependency(command);
        //            //dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

        //            //if (connection.State == ConnectionState.Closed)
        //            //    connection.Open();

        //            var reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                notifications.Insert(0, (item: new Notification { ID = (int)reader["ID"], Update = (string)reader["Notification"], TimeStamp = Convert.ToDateTime(reader["TimeStamp"]) }));
        //            }
        //        }

        //    }
        //    return notifications;


        //}




    }
}