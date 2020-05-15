using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class BookRecord
    {
        public int book_id { get; set; }
        [Required(ErrorMessage ="Please Enter Book Name")]
        public string book_name { get; set; }
        public string author_name { get; set; }
        [Required(ErrorMessage ="Please Enter Book Category")]
        public string category { get; set; }
        [Required(ErrorMessage ="Please Enter number of Copies")]
        public int copies { get; set; }
    }
}