using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using senproject.Models;
namespace senproject.Controllers
{
    public class ChatController : Controller
    {
        private EERTEntities2 db = new EERTEntities2();
        // GET: Chat
        public static int UserID=-1;
       public static int userrole=-1;
        public ActionResult Index()
        {
            return View();
        }
        public ChatController(int userid,int role)
        {
            UserID = userid;
            userrole = role;
        }
        public ChatController()
        { }
        public void SyncToDatabase(string message)
        {
      
            if (userrole == 1)
            {
                CustomerChat temp = new CustomerChat();
                var temps = db.CustomerChats.ToList().ToArray();
                int tempID = temps.Length;
                temp.TempId = tempID;
                temp.UserId = UserID;
                temp.Message = message;
                sync(temp);
            }
        }
        public ActionResult sync([Bind(Include = "TempId,UserId, Message")] CustomerChat chat)
        {

            db.CustomerChats.Add(chat);
            db.SaveChanges();
            return View();
        }
    }
}