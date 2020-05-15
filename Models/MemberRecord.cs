using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class MemberRecord
    {
        public int mem_id { get; set; }
        [Required]
        public string mem_name { get; set; }
        [Required][EmailAddress]
        public string mem_email { get; set; }
        [Required][Phone]
        public string mem_phone { get; set; }
        public string mem_add { get; set; }
    }
}