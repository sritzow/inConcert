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

        

        //void Initialization()
        //{
            
        //    SqlDependency.Start(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //}

        //void SomeMethod()
        //{
        //    // Assume connection is an open SqlConnection.

        //    // Create a new SqlCommand object.
        //    using (SqlCommand command = new SqlCommand(
        //        "SELECT ID, Notification, TimeStamp FROM dbo.Notifications"))
        //    {

        //        // Create a dependency and associate it with the SqlCommand.
        //        SqlDependency dependency = new SqlDependency(command);
        //        // Maintain the refence in a class member.

        //        // Subscribe to the SqlDependency event.
        //        dependency.OnChange += new
        //           OnChangeEventHandler(OnDependencyChange);

        //        // Execute the command.
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            // Process the DataReader.
        //        }
        //    }
        //}

        //// Handler method
        //void OnDependencyChange(object sender,
        //   SqlNotificationEventArgs e)
        //{
        //    // Handle the event (for example, invalidate this cache entry).
        //    Response.Redirect(Request.RawUrl);
        //}

        //void Termination()
        //{
        //    SqlDependency.Stop(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //}




        //public IEnumerable<Notification> GetAllMessages()
        //{
        //    var updates = new List<Notification>();
        //    using (var connection = new SqlConnection(_connString))
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand(@"SELECT [ID], [Notification], [TimeStamp] FROM [dbo].[Notifications]", connection))
        //        {
        //            command.Notification = null;

        //            var dependency = new SqlDependency(command);
        //            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

        //            if (connection.State == ConnectionState.Closed)
        //                connection.Open();

        //            var reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                updates.Insert(0, (item: new Notification { ID = (int)reader["ID"], notificationMessage = (string)reader["Notification"], TimeStamp = Convert.ToDateTime(reader["TimeStamp"]) }));
        //            }
        //        }

        //    }
        //    return updates;


        //}
        //private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        //{
        //    if (e.Type == SqlNotificationType.Change)
        //    {
        //        IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();
        //        context.Clients.All.updateMessages();
        //    }
        //}




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