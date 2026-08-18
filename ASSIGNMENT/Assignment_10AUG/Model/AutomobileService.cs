using System.ComponentModel.DataAnnotations;

namespace Assignment_10AUG.Model
{
    public class AutomobileService
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Service name is required")]
        [StringLength(100)]
        public string ServiceName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Service cost is required")]
        [Range(1, 100000)]
        public decimal Cost { get; set; }

        public List<Automobile>? Automobiles { get; set; }
    }
}
