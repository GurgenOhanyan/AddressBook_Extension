using AddressBook.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ContactsContext contactsContext = new ContactsContext("Server=COMP-40-85\\MSSQLSERVERGURGE;Database=AddressBook;Trusted_Connection=True;User=COMP-40-85");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}