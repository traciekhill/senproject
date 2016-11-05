using System;
using System.Web;
using Microsoft.AspNet.SignalR;

using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;

using System.Web.Mvc;
using senproject.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using senproject.Models;
using senproject.Controllers;
namespace senproject
{
    public class ChatHub : Hub
    {
        protected EERTEntities2 db = new EERTEntities2();

        public void Send(string name, string message, int userID)
        {
            ChatController chatty = new ChatController();
            // Call the addNewMessageToPage method to update clients.
            if (ChatController.userrole == -1)
            {
                Clients.All.addNewMessageToPage("SYSTEM", "There is currently no CSR on duty. Please try again later.");
            }
            else
            {
                chatty.SyncToDatabase(message);
                Clients.All.addNewMessageToPage(name, message);
            }
        }

        public void Create([Bind(Include = "UserId, Message")] CustomerChat chat)
        {
            
            db.CustomerChats.Add(chat);
            db.SaveChanges();
        }

    }
}

