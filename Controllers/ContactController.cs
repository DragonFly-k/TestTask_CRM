using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TestTask_CRM.Models;

namespace TestTask_CRM.Controllers
{
    public class ContactController : Controller
    {
        ContactRepository ContactRepository = new ContactRepository();

        public ActionResult Index()
        {
            ViewBag.data = ContactRepository.GetContactList();
            return View();
        }
       
        public ActionResult Add(string name, string mobilePhone, string jobTitle, DateTime birthDate)
        {
            Contact directory = new Contact
            {
                Name = name,
                MobilePhone = mobilePhone,
                JobTitle = jobTitle,
                BirthDate = birthDate
            };
            ContactRepository.Create(directory);

            if (!ContactRepository.Save()) 
                return new HttpStatusCodeResult(400);
            return Redirect("/Contact/Index");
        }
        public ActionResult Update(int id, string name, string mobilePhone, string jobTitle, DateTime birthDate)
        {
            Contact directory = new Contact
            {
                Id = id,
                Name = name,
                MobilePhone = mobilePhone,
                JobTitle = jobTitle,
                BirthDate = birthDate
            };
            ContactRepository.Update(directory);

            if (!ContactRepository.Save()) 
                return new HttpStatusCodeResult(400);
            return Redirect("/Contact/Index");
        }
        public ActionResult Delete(int id)
        {
            ContactRepository.Delete(id);
            if (!ContactRepository.Save()) 
                return new HttpStatusCodeResult(400);
            return Redirect("/Contact/Index");
        }
    }
}