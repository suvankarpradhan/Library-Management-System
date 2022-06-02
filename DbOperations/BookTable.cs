using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library_Management_System.DbModel;
using Library_Management_System.Models;

namespace Library_Management_System.DbOperations
{
    public class BookTable
    {
        public int AddBook(BookRecord record)
        {
            using(var context = new Library_Management_SystemEntities())
            {
                bookRecod book = new bookRecod()
                {
                    book_name = record.book_name,
                    author_name = record.author_name,
                    category = record.category,
                    copies = record.copies,
                    available_copies = record.copies
                };
                context.bookRecod.Add(book);
                context.SaveChanges();
                return book.book_id;
            }
        }
        public List<BookRecord> GetAllBooks()
        {
            using(var context = new Library_Management_SystemEntities())
            {
                var record = context.bookRecod.Select(b => new BookRecord()
                {
                    book_id = b.book_id,
                    book_name = b.book_name,
                    author_name = b.author_name
                }).ToList();
                return record;
            }
        }
        public List<BookRecord> GetBooks(string category)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.bookRecod.Where(b => b.category == category).Select(b => new BookRecord()
                {
                    book_name = b.book_name,
                    author_name = b.author_name,
                    available_copies=b.available_copies
                }).ToList();
                return record;
            }
        }
        public BookRecord GetBook(int id)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.bookRecod.Where(b => b.book_id == id).Select(b => new BookRecord()
                {
                    book_id = b.book_id,
                    book_name = b.book_name,
                    author_name = b.author_name,
                    category = b.category,
                    copies = b.copies,
                    available_copies=b.available_copies
                }).FirstOrDefault();
                return record;
            }
        }
        public bool UpdateBook(int id, BookRecord record)
        {
            using(var context = new Library_Management_SystemEntities())
            {
                var book = new bookRecod() { book_id = id };
                book.book_name = record.book_name;
                book.author_name = record.author_name;
                book.category = record.category;
                book.copies = record.copies;
                context.Entry(book).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteBook(int id)
        {
            using(var context = new Library_Management_SystemEntities())
            {
                var book = new bookRecod() { book_id = id };
                context.Entry(book).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}