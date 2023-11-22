using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;

namespace TestTask_CRM.Models
{
    public class ContactRepository : IRepository<Contact>
    {
        private DBContext db;
        public ContactRepository()
        {
            this.db = new DBContext();
        }
        public void Create(Contact item)
        {
            db.Contact.Add(item);
        }

        public void Delete(int id)
        {
            Contact contactToDelete = GetContact(id);
            db.Entry(contactToDelete).State = EntityState.Deleted;
        }

        public Contact GetContact(int id)
        {
            return db.Contact.Find(id);
        }

        public IEnumerable<Contact> GetContactList()
        {
            return db.Contact;
        }

        public bool Save()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return false;
            }
        }

        public void Update(Contact item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}