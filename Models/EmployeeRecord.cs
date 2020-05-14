using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_System.Models
{
    public class EmployeeRecord
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_email { get; set; }
        public string emp_phone { get; set; }
        public string emp_pass { get; set; }
        public string emp_add { get; set; }
    }
}