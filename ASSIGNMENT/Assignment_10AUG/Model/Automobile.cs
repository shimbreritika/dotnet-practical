using System.ComponentModel.DataAnnotations;

namespace Assignment_10AUG.Model
{
    public class Automobile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Model name is required")]
        [StringLength(50)]
        public string ModelName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required")]
        [StringLength(50)]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(10000, 10000000)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Manufacturing year is required")]
        [Range(1900, 2100)]
        public int ManufacturingYear { get; set; }

        public int CustomerId { get; set; }

        public Customers? Customer { get; set; }

        public int ServiceId { get; set; }

        public AutomobileService? Service {  get; set; }
    }
}
