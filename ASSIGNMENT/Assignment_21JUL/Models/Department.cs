using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Assignment11.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Department Name is mandatory")]
        public string DeptName { get; set; }

        [Required(ErrorMessage = "Department Head is mandatory")]
        public string DeptHead {  get; set; }


        [Required]
        [Phone]
        public long DeptHeadContact {  get; set; }

        [Required]
        [EmailAddress]
        public string HeadEmail { get; set; }

    }
}
