using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using senproject.Models;
using senproject.WordAttribute;

namespace senproject.Controllers
{
    public class EmployeesController : Controller
    {
        private EERTEntities2 db = new EERTEntities2();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Employee2).Include(e => e.Login);
            return View(employees.ToList());
        }

        [WordDocument]
        public ActionResult ReportDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            var reports = db.Reports
                .Where(r => r.Login.UserId
                    == employee.Login.UserId)
                .ToArray();

            var average = reports.Average(r => r.StarRating);
            

            if (employee == null ||
                reports == null)
            {
                return HttpNotFound();
            }
            return View(new EmployeeDetails()
            {
                Id = employee.Id,
                Employee = employee,
                Reports = reports,
                ReportAverage = average
            });
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.ManagerId = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.UserId = new SelectList(db.Logins, "UserId", "UserName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Address,DOB,ManagerId,UserId,Role")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerId = new SelectList(db.Employees, "Id", "FirstName", employee.ManagerId);
            ViewBag.UserId = new SelectList(db.Logins, "UserId", "UserName", employee.UserId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerId = new SelectList(db.Employees, "Id", "FirstName", employee.ManagerId);
            ViewBag.UserId = new SelectList(db.Logins, "UserId", "UserName", employee.UserId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Address,DOB,ManagerId,UserId,Role")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerId = new SelectList(db.Employees, "Id", "FirstName", employee.ManagerId);
            ViewBag.UserId = new SelectList(db.Logins, "UserId", "UserName", employee.UserId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
