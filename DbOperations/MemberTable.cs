using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library_Management_System.Models;
using Library_Management_System.DbModel;

namespace Library_Management_System.DbOperations
{
    public class MemberTable
    {
        public int AddMember(MemberRecord record)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                memberRecord mem = new memberRecord()
                {
                    mem_name = record.mem_name,
                    mem_email = record.mem_email,
                    mem_phone = record.mem_phone,
                    mem_add = record.mem_add
                };
                context.memberRecord.Add(mem);
                context.SaveChanges();
                return mem.mem_id;
            }

        }

        public List<MemberRecord> GetAllMembers()
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.memberRecord.Select(x => new MemberRecord()
                {
                    mem_id = x.mem_id,
                    mem_name = x.mem_name,
                    mem_email = x.mem_email
                }).ToList();
                return record;
            }
        }

        public MemberRecord GetMember(int Id)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var record = context.memberRecord.Where(x => x.mem_id == Id).Select(x => new MemberRecord()
                {
                    mem_id = x.mem_id,
                    mem_name = x.mem_name,
                    mem_email = x.mem_email,
                    mem_phone = x.mem_phone,
                    mem_add = x.mem_add
                }).FirstOrDefault();
                return record;
            }
        }

        public bool UpdateMember(int Id, MemberRecord record)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var member = new memberRecord() { mem_id = Id };
                member.mem_name = record.mem_name;
                member.mem_email = record.mem_email;
                member.mem_phone = record.mem_phone;
                member.mem_add = record.mem_add;
                context.Entry(member).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteMember(int Id)
        {
            using (var context = new Library_Management_SystemEntities())
            {
                var member = new memberRecord() { mem_id = Id };
                context.Entry(member).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}