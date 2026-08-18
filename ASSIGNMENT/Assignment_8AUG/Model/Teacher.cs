using System.ComponentModel.DataAnnotations;

namespace Assignment19.Model
{
    public class Teacher
    {
        public int TeacherId {  get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name {  get; set; }

        [Required(ErrorMessage ="Email is required")]
        public string Email {  get; set; }

        [Range(1,40)]
        public int Experience {  get; set; }

        // One Teacher -> Many Courses
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
