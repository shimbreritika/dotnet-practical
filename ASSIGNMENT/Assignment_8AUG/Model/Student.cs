using System.ComponentModel.DataAnnotations;

namespace Assignment19.Model
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage ="First name is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string Email {  get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        public long Phone {  get; set; }

        [Required]
        public DateTime DateOfBirth {  get; set; }
        public int BatchId {  get; set; }

        // Relationship
        public Batch Batch { get; set; }

        // Many-to-Many
        public ICollection<Course> Courses { get; set; } = new List<Course>();


    }
}
