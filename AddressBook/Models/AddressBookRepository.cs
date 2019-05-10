using AddressBook.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{

    public class AddressBookRepository
    {
        public List<ContactListModel> GetContactList( AddressBookContext _context)
        {
            ///get the current user (LoggedinUserId)
            int loggedInUserId = 1;// this value is hardcoded because we dont have functionality to login 

            var listofUsers = _context.Mapping.Where(c => c.MainUserId == loggedInUserId).ToList().Select(c => c.UserId);

            var currentUserContact = _context.User
                      .Where(m => listofUsers.Contains(m.UserId))
                      .ToList();

            var contactListModel = from user in currentUserContact
                        join contact in _context.Contact on user.UserId equals contact.UserId
                        join email in _context.Email on user.UserId equals email.UserId
                        select (new ContactListModel
                        {
                            UserId =  user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            ContactNumber = contact.ContactNumber,
                            EmailAddress = email.EmailAddress,
                            Address = user.Address
                        });

            return contactListModel.ToList();
        }

        public void SaveUser(AddressBookModel model, AddressBookContext _context)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {

                    SaveUser(model.userModel, _context);

                    model.emailModel.UserId = model.userModel.UserId;
                    model.contactModel.UserId = model.userModel.UserId;

                    var mappingModel = new MappingModel()
                    {
                        UserId = model.userModel.UserId,
                        MainUserId = 1//model.userModel.CurrentUserId;  this value is hardcoded because we dont have functionality to login 
                    };

                    SaveEmail(model.emailModel, _context);

                    SaveContact(model.contactModel, _context);

                    SaveMapping(mappingModel, _context);

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }

        private void SaveUser(UserModel model, AddressBookContext _context)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void SaveContact(ContactModel model, AddressBookContext _context)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void SaveEmail(EmailModel model, AddressBookContext _context)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void SaveMapping(MappingModel model, AddressBookContext _context)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
