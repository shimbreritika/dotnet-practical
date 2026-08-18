using System.ComponentModel.DataAnnotations;

namespace Assignment18.Model
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(50,ErrorMessage = "Course Name must be between 3 and 50 characters.", MinimumLength = 3)]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course Code is required")]
        [StringLength(10,ErrorMessage = "Course Code cannot exceed 10 characters.")]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 24,  ErrorMessage = "Duration must be between 1 and 24 months.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Course Fee is required")]
        [Range(1000, 1000000,   ErrorMessage = "Course Fee must be between 1000 and 1000000.")]
        public decimal CourseFee { get; set; }

        [Required(ErrorMessage = "Trainer Name is required")]
        [StringLength(50, ErrorMessage = "Trainer Name must be between 3 and 50 characters.", MinimumLength = 3)]
        public string TrainerName { get; set; }
    }
}
