﻿using System;
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
    public class CustomerFAQController : Controller
    {
        private EERTEntities2 db = new EERTEntities2();
        // GET: CustomerFAQ
        public ActionResult Index()
        {
            return View(db.FAQs.ToList());
        }
    }
}