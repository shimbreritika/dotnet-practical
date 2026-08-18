using Assignment17.Model;
using Assignment17.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_service.GetEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _service.GetEmployee(id);

            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _service.AddEmployee(employee);
            return Ok("Employee Added Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var result = _service.UpdateEmployee(id, employee);

            if (result == null)
            {
                return NotFound("Employee not found.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            bool result = _service.DeleteEmployee(id);

            if (!result)
            {
                return NotFound("Employee not found.");
            }

            return Ok("Employee Deleted Successfully");
        }

        [HttpGet("SearchByName/{name}")]
        public IActionResult SearchByName(string name)
        {
            return Ok(_service.SearchByName(name));
        }

        [HttpGet("SearchByDepartment/{departmentId}")]
        public IActionResult SearchByDepartment(int departmentId)
        {
            return Ok(_service.SearchByDepartment(departmentId));
        }

        [HttpGet("SearchByEmail/{email}")]
        public IActionResult SearchByEmail(string email)
        {
            var employee = _service.SearchByEmail(email);

            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            return Ok(employee);
        }

        [HttpGet("SearchByStatus/{status}")]
        public IActionResult SearchByStatus(string status)
        {
            return Ok(_service.SearchByStatus(status));
        }
    }
}
