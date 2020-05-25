using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class BookRecord
    {
        [Display(Name ="Book Id")]
        public int book_id { get; set; }

        [Required(ErrorMessage ="Please Enter Book Name")][Display(Name = "Book Name")]
        public string book_name { get; set; }

        [Display(Name = "Author Name")]
        public string author_name { get; set; }

        [Required(ErrorMessage ="Please Enter Book Category")][Display(Name = "Category")]
        public string category { get; set; }

        [Required(ErrorMessage ="Please Enter number of Copies")][Display(Name = "No of Copies")]
        public int copies { get; set; }
    }
}