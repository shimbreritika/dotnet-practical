using Assignment19.Model;
using Assignment19.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment19.Controllers
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
        public IActionResult GetCourse()
        {
            var course = service.GetCourse();

            if (course == null)
            {
                return NotFound("Course not found");
            }

            return Ok(course);
        }

     
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            var result = service.AddCourse(course);

            return Ok(result);
        }

       
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            var result = service.UpdateCourse(id, course);

            if (result == null)
            {
                return NotFound("Course not found");
            }

            return Ok(result);
        }

        
        [HttpDelete]
        public IActionResult DeleteCourse(Course course)
        {
            var result = service.DeleteCourse(course);

            if (result == null)
            {
                return NotFound("Course not found");
            }

            return Ok(result);
        }
    }
}
