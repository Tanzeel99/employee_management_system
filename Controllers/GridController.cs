using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using AssignMVC.Models;
using System.Data.Entity;
using AssignMVC;

namespace Grid_Telerik_Mvc_App.Controllers
{
    public partial class GridController : Controller
    {
        public JsonResult Orders_Read([DataSourceRequest] DataSourceRequest request)
        {
            assignEntities db = new assignEntities();
            var emp = db.Employee.Select(p => new Employees
            {
                EmployeeID = p.EmployeeID,
                FirstName = p.FirstName,
                LastName = p.LastName,
                EmailID = p.EmailID,
                ContactNo = (long)p.ContactNo,
                DepartmentName = p.Department.DepartmentName,
                Status = (bool)p.Status
            });

            return Json(emp.ToDataSourceResult(request));

        }
        public ActionResult Chart()
        {
            return View();
        }
    }
}
