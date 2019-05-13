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

        [HttpPost]
        public IActionResult AddContact(string userId, string contactNo)
        {
            var contactModel = new ContactModel()
            {
                UserId = Convert.ToInt16(userId),
                ContactNumber = contactNo
            };

            _repository.SaveContact(contactModel, _context);
           
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult UpdateContact(string contactId, string contactNo)
        {
            var contactModel = new ContactModel()
            {
                ContactId = Convert.ToInt16(contactId),
                ContactNumber = contactNo
            };

            _repository.UpdateContact(contactModel, _context);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateEmail(string emailId, string emailAddress)
        {
            var emailModel = new EmailModel()
            {
                EmailId = Convert.ToInt16(emailId),
                EmailAddress = emailAddress
            };

            _repository.UpdateEmail(emailModel, _context);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddEmail(string userId, string emailAddress)
        {
            var contactModel = new EmailModel()
            {
                UserId = Convert.ToInt16(userId),
                EmailAddress = emailAddress
            };

            _repository.SaveEmail(contactModel, _context);

            return RedirectToAction("Index");
        }
        public ActionResult EditUserContact(int id)
        {
            UpdateModel model = new UpdateModel();

            model.userModel = _repository.GetUserById(id, _context);

            model.emailModel = _repository.GetEmailByUserId(id, _context);

            model.contactModel = _repository.GetContactByUserId(id, _context);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUserContact(UpdateModel model)
        {
            _repository.UpdateUser(model.userModel, _context);

            return RedirectToAction("Index");
        }
    
        public ActionResult DeleteUserContact(int id)
        {
            UpdateModel model = new UpdateModel();


            _repository.DeleteContact(id, _context);

            _repository.DeleteEmail(id, _context);

            _repository.DeleteMapping(id, _context);

            _repository.DeleteUser(id, _context);

            return RedirectToAction("Index");
        }

      
    }
}