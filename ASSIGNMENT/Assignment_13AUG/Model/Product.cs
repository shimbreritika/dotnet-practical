using System.ComponentModel.DataAnnotations;

namespace Assignment_13AUG.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Range(1, 10000000)]
        public decimal Price { get; set; }

        [Range(0, 100000)]
        public int Stock { get; set; }
    }
}
