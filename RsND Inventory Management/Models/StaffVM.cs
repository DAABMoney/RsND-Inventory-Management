using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Models
{
    public class StaffVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Contact Number")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string TRN { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateofBirth { get; set; }
        public DateTime? Registered { get; set; }
    }
}
