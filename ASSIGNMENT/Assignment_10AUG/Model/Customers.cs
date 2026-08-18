using System.ComponentModel.DataAnnotations;

namespace Assignment_10AUG.Model
{
    public class Customers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        public List<Automobile>? Automobiles { get; set; }
    }
}
