using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Data
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        public DateTime Registered { get; set; }
    }
}
