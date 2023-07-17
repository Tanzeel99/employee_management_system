using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignMVC.Models;
using Newtonsoft.Json;
using PagedList;
using PagedList.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace AssignMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        assignEntities db = new assignEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            assignEntities db = new assignEntities();
            var DepartList = db.Department.ToList();
            ViewBag.DepartName = new SelectList(DepartList, "DepartmentID", "DepartmentName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            ViewBag.DepartName = new SelectList(db.Department.ToList(), "DepartmentID", "DepartmentName");
            if (ModelState.IsValid)
            {
                emp.CreatedBy = "Tanzeel";
                emp.CreatedDate = DateTime.Now;
                emp.UpdatedBy = "Tanzeel";
                emp.UpdatedDate = DateTime.Now;
                emp.Status = true;
                assignEntities db = new assignEntities();
                db.Employee.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
        public ActionResult List()
        {
            assignEntities db = new assignEntities();
            IQueryable<Employee> list = from s in db.Employee select s;
            return View(list.ToList());
        }

        public ActionResult Edit(int id)
        {
            assignEntities db = new assignEntities();
            ViewBag.DepartName = new SelectList(db.Department.ToList(), "DepartmentID", "DepartmentName");
            var emp = db.Employee.Find(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {

            assignEntities db = new assignEntities();
            ViewBag.DepartName = new SelectList(db.Department.ToList(), "DepartmentID", "DepartmentName");
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            assignEntities db = new assignEntities();
            var emp = db.Employee.Find(id);
            emp.Status = !emp.Status;
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DeleteConfirmed(int id)
        {
            assignEntities db = new assignEntities();
            var emp = db.Employee.Find(id);
            emp.Status = false;
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Chartdata()
        {
            var emp = db.Employee.Include("Department").GroupBy(x => x.Department.DepartmentName).Select(y => new DepartmentTotal
            {
                DepartmentName = y.Key,
                Total = y.Count()
            }).ToList().OrderByDescending(y => y.Total);
            /*            return View(emp);*/
            /*            var json = JsonConvert.SerializeObject(emp);*/
            return Json(emp, JsonRequestBehavior.AllowGet);
            /*            return View();*/
        }
    }
}


