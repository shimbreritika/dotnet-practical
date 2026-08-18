using System.ComponentModel.DataAnnotations;

namespace Assignment17.Model
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage ="Department code is required")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department status must contain valid values. ")]
        [RegularExpression("Active|Inactive")]
        public string Status { get; set; } = string.Empty;

    }
}
