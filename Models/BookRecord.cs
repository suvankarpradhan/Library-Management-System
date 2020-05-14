using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management_System.Models
{
    public class BookRecord
    {
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string author_name { get; set; }
        public string category { get; set; }
        public int copies { get; set; }
    }
}