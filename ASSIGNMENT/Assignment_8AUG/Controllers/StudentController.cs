using Assignment19.Model;
using Assignment19.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service = service;
        }

        
        [HttpGet]
        public IActionResult GetStudent()
        {
            var students = service.GetStudent();

            return Ok(students);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = service.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var result = service.AddStudent(student);

            return Ok(result);
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var result = service.UpdateStudent(id, student);

            if (result == null)
            {
                return NotFound("Student not found");
            }

            return Ok(result);
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = service.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            var result = service.DeleteStudent(id);

            return Ok(result);
        }
    }
}

