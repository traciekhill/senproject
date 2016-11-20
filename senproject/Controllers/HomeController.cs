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
   
    public class HomeController : Controller
    {
        EERTEntities2 db = new EERTEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult CSRChat()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
        public  ActionResult feedback(int stars)
        {
            EERTEntities2 db = new EERTEntities2();
            Report temp = new Report();
            var allReports = db.Reports.ToList().ToArray();
            int tempid = allReports.Length;
            DateTime currtime = DateTime.Now;
            TimeSpan currtimeSPAN = new TimeSpan(currtime.Hour, currtime.Minute, currtime.Second);
            DateTime Starttime = ChatController.startTime;
            TimeSpan StartTime = new TimeSpan(Starttime.Hour, Starttime.Minute, Starttime.Second);
            int uid = ChatController.UserID;
            temp.Date = DateTime.Today;
            temp.Id = tempid;
            temp.ResolutionEndTime = currtimeSPAN;
            temp.ResolutionStartTime = StartTime;
            temp.UserId = uid;
            temp.StarRating = stars;
            SaveFeedback(temp);
            return View("Index");
        }
        public void SaveFeedback([Bind(Include = "UserId,StarRating,ResolutionStartTime,ResolutionEndTime,Date,ID")] Report report)
        {
            EERTEntities2 db = new EERTEntities2();
            db.Reports.Add(report);
            db.SaveChanges();
        }
    }
}