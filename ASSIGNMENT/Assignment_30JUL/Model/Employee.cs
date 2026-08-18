using System.ComponentModel.DataAnnotations;

namespace Assignment17.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="Employee first name is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Employee last name is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Employee email address is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string MobileNumber { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        [Required]
        public DateTime DateOfJoining { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public string Designation { get; set; } = string.Empty;

        public string Status { get; set; } = "Active";

    }
    }


