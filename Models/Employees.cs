using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignMVC.Models
{
    public class Employees
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public long ContactNo { get; set; }
        public string DepartmentName { get; set; }
        public bool Status { get; set; }
        public string StrgContactNo
        {
            get
            {
                return this.ContactNo.ToString();
            }
        }
    }
}