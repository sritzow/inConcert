using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using inConcert.Models;

namespace inConcert.Helper
{
    public class InsertToMessageTable
    {
        public static void UsingChatModel(Chat chat)
        {

            string[] message_values = 
            {

                 chat.message.to, 
                 chat.message.from, 
                 chat.message.body, 
                 chat.message.project, 

            };


            string [] column_names = Build.StringArray("_to", "_from", "_body", "_project");

            List<string[]> values = new List<string[]>();

            values.Add(message_values);

            DataAccess.DataAccess.Create(

                "messages",
                column_names,
                values

            );
        }
        public static void UsingMessageModel(Message msg)
        {

            string[] message_values = 
            {

                 msg.to, 
                 msg.from, 
                 msg.body, 
                 msg.project, 

            };


            string [] column_names = Build.StringArray("_to", "_from", "_body", "_project");

            List<string[]> values = new List<string[]>();

            values.Add(message_values);

            DataAccess.DataAccess.Create(

                "messages",
                column_names,
                values

            );
        }
    }
}