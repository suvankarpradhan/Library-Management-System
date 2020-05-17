using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class EmployeeRecord
    {
        public int emp_id { get; set; }
        [Required]
        public string emp_name { get; set; }
        [Required][EmailAddress]
        public string emp_email { get; set; }
        [Required][Phone]
        public string emp_phone { get; set; }
        [Required]
        public string emp_pass { get; set; }
        public string emp_add { get; set; }
        [Required]
        public string role { get; set; }
        [Required]
        public string username { get; set; }
    }
    public enum role { Admin, Employee }
}