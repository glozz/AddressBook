using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class UpdateModel
    {
        public UserModel userModel { get; set; }
        public List<ContactModel> contactModel { get; set; }
        public List<EmailModel> emailModel { get; set; }
        //public MappingModel mappingModel { get; set; }
    }
}
