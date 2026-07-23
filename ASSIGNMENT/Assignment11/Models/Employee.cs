using System.ComponentModel.DataAnnotations;

namespace Assignment11.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="Employee ID is mandatory")]
        public int EmpId { get; set; }

        [Required(ErrorMessage ="Employee name is mandatory")]
        [StringLength(20,MinimumLength =3,ErrorMessage = "Employee name cannot exceed 20 characters ")]
        public string EmpName { get; set; }

        [Required(ErrorMessage ="Employee department is mandatory")]
        public string Department { get; set; }

        [Required(ErrorMessage ="Employee salary is mandatory")]
        [Range(1000, 1000000, ErrorMessage = "Enter a valid salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage ="Employee email is mandatory")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }
    }
}
