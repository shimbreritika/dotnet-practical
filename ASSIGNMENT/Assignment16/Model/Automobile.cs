using System.ComponentModel.DataAnnotations;

namespace Assignment16.Model
{
    public class Automobile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vehicle name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Manufacturing year is required")]
        public int Year { get; set; }
    }
}
