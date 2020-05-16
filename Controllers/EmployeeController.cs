using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models;
using Library_Management_System.DbOperations;

namespace Library_Management_System.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        EmployeeTable employeeTable = null;
        public EmployeeController()
        {
            employeeTable = new EmployeeTable();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeRecord record)
        {
            if (ModelState.IsValid)
            {
                int Id = employeeTable.AddEmployee(record);
                if (Id > 0)
                {
                    ModelState.Clear();
                }
            }
            return View();
        }

        public ActionResult GetAllEmployees()
        {
            var record = employeeTable.GetAllEmployees();

            return View(record);
        }
        public ActionResult Details(int id)
        {
            var employee = employeeTable.GetEmployee(id);
            return View(employee);
        }
        public ActionResult Edit(int id)
        {
            var employee = employeeTable.GetEmployee(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeRecord record)
        {
            if (ModelState.IsValid)
            {
                employeeTable.UpdateEmployee(record.emp_id, record);
                return RedirectToAction("GetAllEmployees");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            employeeTable.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployees");
        }
    }
}
