using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext()
        {
        }

        public AddressBookContext(DbContextOptions<AddressBookContext> options)
              : base(options)



        {
            }

            public DbSet<AddressBook.Models.ContactModel> Contact { get; set; }
            public DbSet<AddressBook.Models.UserModel> User { get; set; }
            public DbSet<AddressBook.Models.EmailModel> Email { get; set; }
            public DbSet<AddressBook.Models.MappingModel> Mapping { get; set; }
    }
}
