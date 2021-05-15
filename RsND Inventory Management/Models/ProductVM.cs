using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Display(Name = "VIN Number")]
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
        [Display(Name = "Manufacturer Date")]
        [Required]
        public DateTime MFGDate { get; set; }
        [Required]
        public string Cost { get; set; }
        [Display(Name = "Transmission Type")]
        [Required]
        public string TransmissinType { get; set; }
        [Display(Name = "Fuel Type")]
        [Required]
        public string FuelType { get; set; }
        [Display(Name = "Seating Capacity")]
        [Required]
        public string SeatingCapacity { get; set; }
    }
}
