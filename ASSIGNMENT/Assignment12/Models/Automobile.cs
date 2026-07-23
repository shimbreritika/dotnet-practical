using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace Assignment12.Models
{
    public class Automobile
    {
        [Required(ErrorMessage ="Vehicle ID is mandatory")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage ="Vehicle name is mandatory")]
        [StringLength(50)]
        public string VehicleName { get; set; }

        [Required(ErrorMessage ="vehicle brand is mandatory")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "vehicle model year is mandatory")]
        [Range(2000, 2035)]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "vehicle price is mandatory")]
        [Range(50000, 10000000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "vehicle fuel type is mandatory")]
        public string FuelType { get; set; }

    }
}
