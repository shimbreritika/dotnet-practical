using Assignment19.Model;
using Assignment19.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService service;

        public TeacherController(ITeacherService service)
        {
            this.service = service;
        }

       
        [HttpGet]
        public IActionResult GetTeacher()
        {
            var teachers = service.GetTeacher();

            return Ok(teachers);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = service.GetTeacherById(id);

            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }

            return Ok(teacher);
        }

      
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, Teacher teacher)
        {
            service.UpdateTeacher(id, teacher);

            return Ok("Teacher updated successfully");
        }

       
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            service.DeleteTeacher(id);

            return Ok("Teacher deleted successfully");
        }
    }
}
