using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string VINnumber { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        public DateTime MFGDate { get; set; }
        [Required]
        public string Cost { get; set; }
        [Required]
        public string TransmissinType { get; set; }
        [Required]
        public string FuelType { get; set; }
        [Required]
        public string SeatingCapacity { get; set; }


    }
}
