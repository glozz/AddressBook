using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class EmailModel
    {

        [Key]
        public int EmailId { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public int UserId { get; set; }
    }
}
