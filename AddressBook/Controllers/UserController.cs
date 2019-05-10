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
                _repository.SaveUser(model, _context);
                ModelState.Clear();
            }
            else
            {
                var ContactList = _repository.GetContactList(_context);

                model.ContactListModel = ContactList;

                return View(nameof(Index), model);
            }
            return View(nameof(Index), model);
        }
    }
}