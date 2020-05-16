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
    public class BookController : Controller
    {
        BookTable bookTable = null;
        public BookController()
        {
            bookTable = new BookTable();
        }       

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookRecord record)
        {
            if (ModelState.IsValid)
            {
                int Id = bookTable.AddBook(record);
                if (Id > 0)
                {
                    ModelState.Clear();
                }
            }
            return View();            
        }

        // GET: Book
        public ActionResult GetAllBooks()
        {
            var record = bookTable.GetAllBooks();
            return View(record);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = bookTable.GetBook(id);
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookTable.GetBook(id);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookRecord record)
        {
            if(ModelState.IsValid)
            {
                bookTable.UpdateBook(record.book_id, record);
                return RedirectToAction("GetAllBooks");
            }
            return View();
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            bookTable.DeleteBook(id);
            return RedirectToAction("GetAllBooks");
        }
    }
}
