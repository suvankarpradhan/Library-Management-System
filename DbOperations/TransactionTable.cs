using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library_Management_System.Models;
using Library_Management_System.DbModel;

namespace Library_Management_System.DbOperations
{
    public class TransactionTable
    {
        public int AddTransaction(TransactionRecord record)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                transactionRecord tran = new transactionRecord()
                {
                   emp_id = record.emp_id,
                   book_id = record.book_id,
                   mem_id = record.mem_id,
                   issue_date = record.issue_date,
                   return_date = record.return_date,
                   last_date = record.last_date,
                   penalty = record.penalty,
                   book_name = record.book_name
                };
                context.transactionRecord.Add(tran);
                context.SaveChanges();
                return tran.trans_id;
            }

        }
        public bool UpdateTransaction(int Id, TransactionRecord record)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var transaction = new transactionRecord() { trans_id = Id };
                transaction.emp_id = record.emp_id;
                transaction.book_id = record.book_id;
                transaction.mem_id = record.mem_id;
                transaction.issue_date = record.issue_date;
                transaction.return_date = record.return_date;
                transaction.last_date = record.last_date;
                transaction.penalty = record.penalty;
                transaction.book_name = record.book_name;
                context.Entry(transaction).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
        public TransactionRecord GetTransaction(int Id)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.transactionRecord.Where(x => x.trans_id == Id).Select(x => new TransactionRecord()
                {
                    trans_id = x.trans_id,
                    emp_id = x.emp_id,
                    book_id = x.book_id,
                    mem_id = x.mem_id,
                    issue_date = x.issue_date,
                    return_date = x.return_date,
                    last_date = x.last_date,
                    penalty = x.penalty,
                    book_name = x.book_name
                }).FirstOrDefault();
                return record;
            }
        }
        public List<TransactionRecord> GetAllTransactions()
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.transactionRecord.Select(x => new TransactionRecord()
                {
                    trans_id = x.trans_id,
                    emp_id = x.emp_id,
                    book_id = x.book_id,
                    mem_id = x.mem_id,
                    issue_date = x.issue_date,
                    return_date = x.return_date,
                    last_date = x.last_date,
                    penalty = x.penalty,
                    book_name = x.book_name
                }).ToList();
                return record;
            }
        }
        public List<TransactionRecord> GetHistory(int Mid)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.transactionRecord.Where(x => x.mem_id == Mid).Select(x => new TransactionRecord()
                {
                    trans_id = x.trans_id,
                    issue_date = x.issue_date,
                    last_date = x.last_date,
                    penalty = x.penalty,
                    book_name = x.book_name
                }).ToList();
                return record;
            }
        }

        public bool DeleteTransaction(int Id)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var transaction = new transactionRecord() { trans_id = Id };
                context.Entry(transaction).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}