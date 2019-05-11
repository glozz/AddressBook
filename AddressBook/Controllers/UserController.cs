using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using AddressBook.DAL;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Controllers
{
    public class UserController : Controller
    {


        private readonly AddressBookContext _context;


        public UserController(AddressBookContext context)
        {
            _context = context;
        }

        AddressBookRepository _repository = new AddressBookRepository();

        public IActionResult Index(AddressBookModel model)
        {
            var ContactList = _repository.GetContactList(_context);

            model.ContactListModel = ContactList;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddUser(AddressBookModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveUserContact(model, _context);
                ModelState.Clear();
            }
            else
            {
                var ContactList = _repository.GetContactList(_context);

                model.ContactListModel = ContactList;

                return View(nameof(Index), model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            UpdateModel model = new UpdateModel();

            model.userModel = _repository.GetUserById(id, _context);

            model.emailModel = _repository.GetEmailByUserId(id, _context);

            model.contactModel = _repository.GetContactByUserId(id, _context);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UpdateModel model)
        {
            _repository.UpdateUserContact(model, _context);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditContact(string id, string value)
        {

            return Ok();
        }
        public ActionResult DeleteContact(int id)
        {
            UpdateModel model = new UpdateModel();


            _repository.DeleteContact(id, _context);

            _repository.DeleteEmail(id, _context);

            _repository.DeleteMapping(id, _context);

            _repository.DeleteUser(id, _context);


            return View(model);
        }
    }
}