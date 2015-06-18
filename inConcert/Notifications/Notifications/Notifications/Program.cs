using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notifications
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection myConnection = new SqlConnection("User Id=Hydrogen;" +
                                                            "Password=Codeflange4life1;" +
                                                            "Server=SQL;" +
                                                            "Database=Hydro_practice; " +
                                                            "Connection Timeout=15");
            try
            {
                myConnection.Open();
                Console.WriteLine("--Connected to DB--");
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from toast_test", myConnection);
                myReader = myCommand.ExecuteReader();
                Int64 unixTimestamp = (Int64)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds; // Current Time
                Int64 lastLogIn = unixTimestamp - 3000000; // Simulated last log-in
                Console.WriteLine("");
                Console.WriteLine("Current Unix Time: {0}", unixTimestamp);
                List<string> changes = new List<string>();
                while (myReader.Read())
                {

                    Int64 timestamp = Convert.ToInt64(myReader["timestamp"].ToString());
                    string content = myReader["content"].ToString();
                    if (timestamp >= lastLogIn)
                    {
                        changes.Add(content);
                    }

                }
                Thread.Sleep(500);
                Console.WriteLine("");
                Console.WriteLine("Changes since your last Log-In:");
                Console.WriteLine("-------------------------------");
                foreach (object o in changes)
                {
                    Console.WriteLine(o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }


    }
}