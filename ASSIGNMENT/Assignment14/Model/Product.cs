using System.ComponentModel.DataAnnotations;

namespace Assignment14.Model
{
    public class Product
    {
        [Required(ErrorMessage = "Product Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Product Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Price is required")]
        [Range(1, 1000000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product Category is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Category must be between 3 and 30 characters")]
        public string Category { get; set; }
    }
}