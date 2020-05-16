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
    public class MemberController : Controller
    {
        MemberTable memberTable = null;
        public MemberController()
        {
            memberTable = new MemberTable();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MemberRecord record)
        {
            if (ModelState.IsValid)
            {
                int Id = memberTable.AddMember(record);
                if (Id > 0)
                {
                    ModelState.Clear();
                }
            }
            return View();
        }

        public ActionResult GetAllMembers()
        {
            var record = memberTable.GetAllMembers();

            return View(record);
        }
        public ActionResult Details(int id)
        {
            var Member = memberTable.GetMember(id);
            return View(Member);
        }
        public ActionResult Edit(int id)
        {
            var Member = memberTable.GetMember(id);
            return View(Member);
        }
        [HttpPost]
        public ActionResult Edit(MemberRecord record)
        {
            if (ModelState.IsValid)
            {
                memberTable.UpdateMember(record.mem_id, record);
                return RedirectToAction("GetAllMembers");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            memberTable.DeleteMember(id);
            return RedirectToAction("GetAllMembers");
        }
    }
}
