using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library_Management_System.DbModel;
using Library_Management_System.Models;

namespace Library_Management_System.DbOperations
{
    public class EmployeeTable
    {
        public int AddEmployee(EmployeeRecord record)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                employeeRecord emp = new employeeRecord()
                {
                    emp_name = record.emp_name,
                    emp_email = record.emp_email,
                    emp_phone = record.emp_phone,
                    username = record.username,
                    emp_pass = record.emp_pass,
                    emp_add = record.emp_add,
                    role = record.role
                };
                context.employeeRecord.Add(emp);
                context.SaveChanges();
                return emp.emp_id;
            }

        }

        public List<EmployeeRecord> GetAllEmployees()
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.employeeRecord.Select(x => new EmployeeRecord()
                {
                    emp_id = x.emp_id,
                    emp_name = x.emp_name,
                    emp_email = x.emp_email
                }).ToList();
                return record;
            }
        }

        public EmployeeRecord GetEmployee(int Id)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.employeeRecord.Where(x => x.emp_id == Id).Select(x => new EmployeeRecord()
                {
                    emp_id = x.emp_id,
                    emp_name = x.emp_name,
                    emp_email = x.emp_email,
                    emp_phone = x.emp_phone,
                    username = x.username,
                    emp_pass = x.emp_pass,
                    emp_add = x.emp_add,
                    role = x.role
                }).FirstOrDefault();
                return record;
            }
        }
        public EmployeeRecord GetEmployee(string userName)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.employeeRecord.Where(x => x.username == userName).Select(x => new EmployeeRecord()
                {
                    emp_id = x.emp_id,
                    emp_name = x.emp_name,
                    emp_email = x.emp_email,
                    emp_phone = x.emp_phone,
                    username = x.username,
                    emp_pass = x.emp_pass,
                    emp_add = x.emp_add,
                    role = x.role
                }).FirstOrDefault();
                return record;
            }
        }

        public bool UpdateEmployee(int Id, EmployeeRecord record)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var employee = new employeeRecord() { emp_id = Id };
                employee.emp_name = record.emp_name;
                employee.emp_email = record.emp_email;
                employee.emp_phone = record.emp_phone;
                employee.username = record.username;
                employee.emp_pass = record.emp_pass;
                employee.emp_add = record.emp_add;
                employee.role = record.role;
                context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteEmployee(int Id)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var employee = new employeeRecord() { emp_id = Id };
                context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}