using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class AddressBookModel
    {
        public UserModel userModel { get; set; }
        public ContactModel contactModel { get; set; }
        public EmailModel emailModel { get; set; }
        public MappingModel mappingModel { get; set; }
        public List<ContactListModel> ContactListModel { get;set;}
    }
}
