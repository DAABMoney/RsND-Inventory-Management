using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Models
{
    public class CustomerVM
    {
      
        public int Id { get; set; }
        [Display(Name ="First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Number")]
        [Required]
        public string ContactNumber { get; set; }

        public DateTime? Registered { get; set; }
    }
}
