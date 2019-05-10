using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class ContactModel
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        public string  ContactNumber { get; set; }
        public int UserId { get; set; }
    }
}
