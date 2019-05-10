using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class MappingModel
    {
        [Key]
        public int MappingId { get; set; }
        public int MainUserId { get; set; }
        public int UserId { get; set; }
    }
}
