using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using inConcert.Models;

namespace inConcert.Helper
{
    public class InsertToMessageTable
    {
        public static void UsingMessageModel(Message msg)
        {
            msg.time = DateTime.Now;
            List<string[]> values = new List<string[]>();
            string[] message_values = {msg.to, msg.from, msg.body, msg.project, msg.time.ToString()};
            string [] column_names = Build.StringArray("_to", "_from", "_body", "_project", "_time");

            values.Add(message_values);

            DataAccess.DataAccess.Create(

                "messages",
                column_names,
                values

            );
        }

        public static void UsingChatModel(Chat chat)
        {
            chat.message.time = DateTime.Now;
            List<string[]> values = new List<string[]>();
            string[] message_values = {chat.message.to, chat.message.from, chat.message.body, chat.message.project, chat.message.time.ToString()};
            string [] column_names = Build.StringArray("_to", "_from", "_body", "_project", "_time");

            values.Add(message_values);

            DataAccess.DataAccess.Create(

                "messages",
                column_names,
                values

            );
        }
    }
}