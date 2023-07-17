using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignMVC.Models
{
    public class JoinTable
    {
        public Employee emp { get; set; }
        public Department depart { get; set; }
    }
}