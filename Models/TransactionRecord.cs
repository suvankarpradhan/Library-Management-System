using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class TransactionRecord
    {
        public int trans_id { get; set; }
        [Required][Display(Name ="Employee Id")]
        public int emp_id { get; set; }
        [Required][Display(Name = "Book Id")]
        public int book_id { get; set; }
        [Required][Display(Name = "Member Id")]
        public int mem_id { get; set; }
        [DataType(DataType.Date)][Display(Name = "Issue Date")]
        public System.DateTime issue_date { get; set; }
        [DataType(DataType.Date)][Display(Name = "Return Date")]
        public System.DateTime return_date { get; set; }
        [DataType(DataType.Date)][Display(Name = "Last date")]
        public System.DateTime last_date { get; set; }
        [Display(Name = "Penalty")]
        public string penalty { get; set; }
        [Required][Display(Name ="Book Name")]
        public string book_name { get; set; }
    }
}