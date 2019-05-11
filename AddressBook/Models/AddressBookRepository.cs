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
        public List<ContactListModel> GetContactList(AddressBookContext _context)
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
                                       UserId = user.UserId,
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       ContactNumber = contact.ContactNumber,
                                       EmailAddress = email.EmailAddress,
                                       Address = user.Address
                                   });

            return contactListModel.ToList();
        }

        public UserModel GetUserById(int id, AddressBookContext _context)
        {
            try
            {
                var user = _context.User.FirstOrDefault(c => c.UserId == id);

                return user;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<EmailModel> GetEmailByUserId(int id, AddressBookContext _context)
        {
            try
            {
                var model = new List<EmailModel>();

                var email = _context.Email.Where(c => c.UserId == id);
                
                foreach (var item in email)
                {
                    List<EmailModel> emailList = new List<EmailModel>
                    {
                        new EmailModel {EmailId = item.EmailId , EmailAddress = item.EmailAddress,UserId = item.UserId ,},
                    };
                    model.AddRange(emailList);
                }

                return model;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<ContactModel> GetContactByUserId(int id, AddressBookContext _context)
        {
            try
            {
                var contact = _context.Contact.Where(c => c.UserId == id);

                var model = new List<ContactModel>();

                foreach (var item in contact)
                {
                    List<ContactModel> contactList = new List<ContactModel>
                    {
                        new ContactModel {ContactId = item.ContactId,ContactNumber = item.ContactNumber},
                    };
                    model.AddRange(contactList);
                }
                return model;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateUserContact(UpdateModel model, AddressBookContext _context)
        {
            UpdateUser(model.userModel, _context);

            foreach (var item in model.contactModel)
            {
                UpdateContact(item, _context);
            }

            foreach (var item in model.emailModel)
            {
                UpdateEmail(item, _context);
            }
        }

        private static void UpdateUser(UserModel model, AddressBookContext _context)
        {
            try
            {
                var user = _context.User.Where(s => s.UserId == model.UserId).First();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Address = model.Address;

                _context.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateContact(ContactModel model, AddressBookContext _context)
        {
            var contact = _context.Contact.Where(s => s.UserId == model.UserId).First();

            contact.ContactNumber = model.ContactNumber;
            _context.Update(contact);
            _context.SaveChanges();
        }

        public void UpdateEmail(EmailModel model, AddressBookContext _context)
        {
            var email = _context.Email.Where(s => s.UserId == model.UserId).First();
            _context.Update(email);
            _context.SaveChanges();
        }

        public void DeleteUser(int id, AddressBookContext _context)
        {
            var user = _context.User.Where(s => s.UserId == id).First();
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public void DeleteContact(int id, AddressBookContext _context)
        {
            var contact = _context.Contact.Where(s => s.UserId == id).ToList();
            _context.Contact.RemoveRange(contact);
            _context.SaveChanges();
        }
        public void DeleteEmail(int id, AddressBookContext _context)
        {
            var email = _context.Email.Where(s => s.UserId == id).ToList();
            _context.Email.RemoveRange(email);
            _context.SaveChanges();
        }

        public void DeleteMapping(int id, AddressBookContext _context)
        {
            var mapping = _context.Mapping.Where(s => s.UserId == id).First();
            _context.Mapping.Remove(mapping);
            _context.SaveChanges();
        }
        public void SaveUserContact(AddressBookModel model, AddressBookContext _context)
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
