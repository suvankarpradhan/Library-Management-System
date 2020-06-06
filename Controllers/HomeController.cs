using Library_Management_System.Models;
using Library_Management_System.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.bookRecod.Select(b => new BookRecord()
                {
                    category = b.category
                }).Distinct().ToList();
                ViewBag.Category = record;
                return View();
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}