using System.ComponentModel.DataAnnotations;

namespace Assignment12.Models
{
    public class Manufacturer
    {
        [Required(ErrorMessage = "Manufacturer name is required ")]
        public string ManufacturerName { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public long ContactNo { get; set; }

        [Required]
        public string EmailAddr { get; set; }
    }
}
