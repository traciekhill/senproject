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
    public class GenReportController : Controller
    {
        private EERTEntities2 db = new EERTEntities2();
        // GET: GenReport

        private List<Employee> GetEmployees()
        {
            var employees = db.Employees.Include(e => e.Employee2).Include(e => e.Login);
            return (employees.ToList());
        }
        private List<Report> GetReport()
        {
            var reports = db.Reports.Include(r => r.Login);
            return (reports.ToList());
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Call Center Employee Report";
            
            ViewBag.Employee = GetEmployees();
            ViewBag.Report = GetReport();
            return View();
        }
        
       
    }
}