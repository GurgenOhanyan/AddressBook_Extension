using AddressBook.App_Start;
using AddressBook.Factory;
using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private IContactFactory _contactFactory;
        public ContactController(IContactFactory contactFactory)
        {
            _contactFactory = contactFactory;
        }
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ViewResult> GetAll()
        {
            var task = _contactFactory.GetAll();
            var contacts = await task;

            return View(contacts);
        }
        [HttpGet]
        public async Task<ViewResult> GetSingle(int id)
        {
            var task = _contactFactory.GetSingle(id);
            var contact = await task;

            return View(contact);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactFactory.Create(contact);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ServerSideValidation = ex.Message;
                return View("CreateValidation");
            }
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public ViewResult Edit(Contact contact)
        {
            return View(contact);
        }
        [HttpPost]
        public async Task<ActionResult> EditPost(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactFactory.Update(contact);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ServerSideValidation = ex.Message;
                return View("EditValidation", contact);
            }
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _contactFactory.Delete(id);
            }
            return RedirectToAction("GetAll");
        }
    }
}