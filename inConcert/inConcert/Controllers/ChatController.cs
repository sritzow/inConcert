using inConcert.Helper;
using inConcert.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inConcert.Controllers
{
    public class ChatController : Controller
    {

        // GET: Chat

        public ActionResult Index()
        {
            return View(GetChat());
        }

        public ActionResult ChatBox(Chat chat)
        {
            return View(chat);
        }

        public ActionResult ChatInput()
        {
            return View();
        }

        public ActionResult ContactDialog(Project project)
        {
            return View();
        }

        public ActionResult GenerateMessage(Message msg)
        {

            if (msg.to == null)
            {

                msg.to = "No recipient specified";

            }

            if (msg.from == null)
            {

                msg.from = "no sender specified";

            }

            if (msg.body == null)
            {

                msg.body = "no text provided";

            }

            if (msg.project == null)
            {

                msg.project = "test";

            }

            InsertToMessageTable.UsingMessageModel(msg);

            Chat chat = new Chat();
            chat = GetChat();

            return View("Index", chat);

        }

        public Chat GetChat()
        {
            Chat chat = new Chat();
            List<List<object>> result = DataAccess.DataAccess.Read(Build.StringArray("messages"), Build.StringArray("*"), null, "_time");
            chat.messages = new List<Message>();

            foreach (List<object> row in result)
            {
                Message msg = new Message();
                msg.from = (string)row[1];
                msg.to = (string)row[2];
                msg.body = (string)row[3];
                msg.project = (string)row[4];
                msg.time = (DateTime)row[5];
                chat.messages.Add(msg);
            }
            Chat chat_two = new Chat();
            return chat;

        }

        public ActionResult SetRecipient()
        {

            return View("Index", GetChat());
        }
    }
}