using Assignment17.Model;
using Assignment17.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(_service.GetDepartments());
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _service.GetDepartment(id);

            if (department == null)
            {
                return NotFound("Department not found.");
            }

            return Ok(department);
        }

        [HttpPost]
        public IActionResult AddDepartment(Department department)
        {
            _service.AddDepartment(department);
            return Ok("Department Added Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, Department department)
        {
            var result = _service.UpdateDepartment(id, department);

            if (result == null)
            {
                return NotFound("Department not found.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            bool result = _service.DeleteDepartment(id);

            if (!result)
            {
                return NotFound("Department not found.");
            }

            return Ok("Department Deleted Successfully");
        }

    }
}
