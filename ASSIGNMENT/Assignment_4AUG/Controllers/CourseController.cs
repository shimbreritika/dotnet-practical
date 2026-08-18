using Assignment18.Model;
using Assignment18.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService service;

        public CourseController(ICourseService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = service.GetCourse(id);

            if (course == null)
                return NotFound("Course not found");

            return Ok(course);
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            service.AddCourse(course);
            return Ok(course);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            if (id != course.Id)
                return BadRequest("Id mismatch");

            var existing = service.GetCourse(id);

            if (existing == null)
                return NotFound("Course not found");

            service.UpdateCourse(course);
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var course = service.GetCourse(id);

            if (course == null)
                return NotFound("Course not found");

            service.DeleteCourse(id);
            return Ok("Course Deleted Successfully");
        }
    }
}
