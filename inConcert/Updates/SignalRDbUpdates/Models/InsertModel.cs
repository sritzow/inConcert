//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace SignalRDbUpdates.Models
//{
//    public class InsertModel
//    {
//        [Required]
//        [Display(Update = "Update:")]
//        public string Update { get; set; }
       
//        public int Insert(string _update)
//        {
//            SqlConnection cn = new SqlConnection(@"Data Source=SQL;User Id=Hydrogen;Password=Codeflange4life1;DataBase=Hydro_practice");
//            SqlCommand cmd = new SqlCommand("Insert Into Messages(Message)Values('"+_update+"')", cn);
//            cn.Open();
//            return cmd.ExecuteNonQuery();
//        }
//    }
//}
//