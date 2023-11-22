using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace TestTask_CRM.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Contact> Contact { get; set; }
        public DBContext() : base("DefaultConnection")
        { 
            Database.CreateIfNotExists(); 
        }
    }
}