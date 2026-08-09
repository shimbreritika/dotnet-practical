using System.ComponentModel.DataAnnotations;

namespace Assignment19.Model
{
    public class Batch
    {
        public int BatchId { get; set; }

        [Required(ErrorMessage ="Batch name is required")]
        public string BatchName { get; set; }

        [Required(ErrorMessage ="Start date is required")]
        public DateTime StartDate {  get; set; }

        // One Batch -> Many Students
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
