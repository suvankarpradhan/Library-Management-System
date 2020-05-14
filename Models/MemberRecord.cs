using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_System.Models
{
    public class MemberRecord
    {
        public int mem_id { get; set; }
        public string mem_name { get; set; }
        public string mem_email { get; set; }
        public string mem_phone { get; set; }
        public string mem_add { get; set; }
    }
}