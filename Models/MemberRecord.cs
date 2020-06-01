using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class MemberRecord
    {
        [Display(Name = "Member Id")]
        public int mem_id { get; set; }
        [Required][Display(Name = "Full Name")]
        public string mem_name { get; set; }
        [Required][EmailAddress][Display(Name = "Email")]
        public string mem_email { get; set; }
        [Required][Phone][Display(Name = "Phone")]
        [StringLength(10, ErrorMessage = "The {0} must be 10 digit long", MinimumLength = 10)]
        public string mem_phone { get; set; }
        [Display(Name = "Address")]
        public string mem_add { get; set; }
    }
}