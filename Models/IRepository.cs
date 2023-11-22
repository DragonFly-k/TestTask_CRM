using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_CRM.Models
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetContactList();
        T GetContact(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        bool Save();
    }
}