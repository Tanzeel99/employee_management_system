using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AssignMVC
{
    public class EmployeeValidation
    {
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Last Name")]
/*        [RegularExpression("^[A-Z][a-zA-Z]*$", ErrorMessage = "Enter Valid Last Name")]*/
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Email ID")]
        [EmailAddress]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Contact No.")]
/*        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Contact No")]*/
        public Nullable<long> ContactNo { get; set; }
    }
    [MetadataType(typeof(EmployeeValidation))]
    public partial class Employee
    {

    }
}