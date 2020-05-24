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
    public class TransactionController : Controller
    {
        TransactionTable transactionTable = null;
        public TransactionController()
        {
            transactionTable = new TransactionTable();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var transaction = transactionTable.GetTransaction(id);
            if(transaction != null)
            {
                return View(transaction);
            }
            else
            {
                return RedirectToAction("NotFound");
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TransactionRecord record)
        {
            if (ModelState.IsValid)
            {
                int Id = transactionTable.AddTransaction(record);
                if (Id > 0)
                {
                    ModelState.Clear();
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var transaction = transactionTable.GetTransaction(id);
            return View(transaction);
        }

        [HttpPost]
        public ActionResult Edit(TransactionRecord record)
        {
            if (ModelState.IsValid)
            {
                transactionTable.UpdateTransaction(record.trans_id, record);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult GetAllTransactions()
        {
            var record = transactionTable.GetAllTransactions();
            return View(record);
        }
        public ViewResult NotFound()
        {
            return View();
        }
    }
}
