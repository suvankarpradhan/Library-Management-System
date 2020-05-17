using Library_Management_System.DbModel;
using Library_Management_System.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Library_Management_System.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(EmployeeRecord record)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                bool isValid = context.employeeRecord.Any(a => a.username == record.username && a.emp_pass == record.emp_pass);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(record.username, false);
                    return RedirectToAction("Index", "Transaction");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username and password");
                    return View();
                }
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}