using Assignment_10AUG.Model;
using Assignment_10AUG.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_10AUG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobileController : ControllerBase
    {
        private readonly IAutomobileService service;

        public AutomobileController(IAutomobileService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateAutomobile(Automobile automobile)
        {
            try
            {
                var result = service.CreateAutomobile(automobile);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAutomobiles()
        {
            var automobiles = service.GetAutomobiles();

            return Ok(automobiles);
        }

        [HttpGet("{id}")]
        public IActionResult GetAutomobileById(int id)
        {
            var automobile = service.GetAutomobileById(id);

            if (automobile == null)
            {
                return NotFound("Automobile not found");
            }

            return Ok(automobile);
        }
    }
}
