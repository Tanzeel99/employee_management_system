﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssignMVC;

namespace AssignMVC.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private assignEntities db = new assignEntities();

        // GET: Departments
        public ActionResult Index()
        {
            return View(db.Department.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,DepartmentName,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Status")] Department department)
        {
            if (ModelState.IsValid)
            {
                department.CreatedBy = "Tanzeel";
                department.CreatedDate = DateTime.Now;
                department.UpdatedBy = "Tanzeel";
                department.UpdatedDate = DateTime.Now;
                department.Status = true;
                db.Department.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Department.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentID,DepartmentName,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,Status")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
             public ActionResult Delete(int? id)
                {
                  /*  if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Department department = db.Department.Find(id);
                    if (department == null)
                    {
                        return HttpNotFound();
                    }
                    return View(department);*/
                assignEntities db = new assignEntities();
                var depart = db.Department.Find(id);
                depart.Status = !depart.Status;
                db.Entry(depart).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
    }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*            Department department = db.Department.Find(id);
                        db.Department.Remove(department);
                        db.SaveChanges();
                        return RedirectToAction("Index");*/
            assignEntities db = new assignEntities();
            var depart = db.Department.Find(id);
            depart.Status = false;
            db.Entry(depart).State = System.Data.Entity.EntityState.Modified;
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
