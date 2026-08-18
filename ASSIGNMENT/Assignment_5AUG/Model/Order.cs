using System.ComponentModel.DataAnnotations;

namespace Assignment_5AUG.Model
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is mandatory")]
        [StringLength(50, ErrorMessage = "Customer name must be below 50 characters", MinimumLength = 3)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Product name is mandatory")]
        [StringLength(50, ErrorMessage = "Product name must be below 50 characters", MinimumLength = 2)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Order quantity is mandatory")]
        [Range(1, 1000, ErrorMessage = "Quantity cannot be below 1 and above 1000")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Order price is mandatory")]
        [Range(1, 1000000, ErrorMessage = "Price can be between 1 to 1000000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Order date is mandatory")]
        public DateTime OrderDate { get; set; }
    }
}
