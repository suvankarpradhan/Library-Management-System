using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_System.Models
{
    public class TransactionRecord
    {
        public int trans_id { get; set; }
        public int emp_id { get; set; }
        public int book_id { get; set; }
        public int mem_id { get; set; }
        public System.DateTime issue_date { get; set; }
        public System.DateTime return_date { get; set; }
        public System.DateTime last_date { get; set; }
        public string penalty { get; set; }
    }
}