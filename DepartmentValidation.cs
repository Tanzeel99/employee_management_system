using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AssignMVC
{
    public class DepartmentValidation
    {
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
    [MetadataType(typeof(DepartmentValidation))]
    public partial class Department
    {

    }
}