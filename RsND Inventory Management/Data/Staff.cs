using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Data
{
    public class Staff : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TRN { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime Registered { get; set; }
    }
}
