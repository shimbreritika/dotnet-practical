using System.ComponentModel.DataAnnotations;

namespace Assignment19.Model
{
    public class Course
    {
        public int CourseId {  get; set; }

        [Required(ErrorMessage ="Course name is required")]
        public string CourseName { get; set; }

        [Range(1,24)]
        public int Duration {  get; set; }

        public int TeacherId {  get; set; }

        // One Teacher -> Many Courses
        public Teacher? Teacher { get; set; }

        // Many Students -> Many Courses
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
