using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class EmployeeRecord
    {
        [Display(Name = "Employee Id")]
        public int emp_id { get; set; }

        [Required][Display(Name = "Full Name")]
        public string emp_name { get; set; }

        [Required][EmailAddress][Display(Name = "Email")]
        public string emp_email { get; set; }

        [Required][Phone]
        [StringLength(10, ErrorMessage = "The {0} must be 10 digit long", MinimumLength = 10)]
        [Display(Name = "Phone No.")]
        public string emp_phone { get; set; }

        [Required][Display(Name = "Password")]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.Maximum Length = 15", MinimumLength = 6)]
        public string emp_pass { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("emp_pass", ErrorMessage = "The password and confirmation password do not match.")]
        public string con_pass { get; set; }

        [Display(Name = "Address")]
        public string emp_add { get; set; }

        [Required][Display(Name = "Role")]
        public string role { get; set; }

        [Required][Display(Name = "Username")]
        public string username { get; set; }
    }
    public enum role { Admin, Employee }
}