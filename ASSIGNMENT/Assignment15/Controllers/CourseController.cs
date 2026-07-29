using Assignment15.Model;
using Assignment15.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        // View all courses
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            return Ok(_service.GetAll());
        }

        // View one course
        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _service.GetById(id);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        // Register course
        [HttpPost]
        public IActionResult RegisterCourse(Course course)
        {
            _service.Register(course);
            return Ok("Course Registered Successfully");
        }

        // Update Duration
        [HttpPut("{id}")]
        public IActionResult UpdateDuration(int id, int duration)
        {
            _service.UpdateDuration(id, duration);
            return Ok("Duration Updated");
        }

        // Cancel Course
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            _service.Delete(id);
            return Ok("Course Cancelled");
        }
    }
}
