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
        public static DateTime startTime;
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
        {
            startTime = DateTime.Now;
        }
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
        public static void feedback(int stars)
        {
            EERTEntities2 db = new EERTEntities2();
            Report temp = new Report();
            var allReports = db.Reports.ToList().ToArray();
            int tempid = allReports.Length;
            DateTime currtime = DateTime.Now;
            DateTime Starttime = ChatController.startTime;
            int uid = UserID;
            temp.Date = DateTime.Today;
            temp.Id = tempid;
            temp.ResolutionEndTime =TimeSpan.Parse( currtime.ToString());
            temp.ResolutionStartTime = TimeSpan.Parse(Starttime.ToString());
            temp.UserId = uid;
            temp.StarRating = stars;
            SaveFeedback(temp);
        }
        public static void SaveFeedback([Bind(Include ="UserId,StarRating,ResolutionStartTime,ResolutionEndTime,Date,ID")] Report report)
        {
            EERTEntities2 db = new EERTEntities2();
            db.Reports.Add(report);
            db.SaveChanges();
        }
    }
}