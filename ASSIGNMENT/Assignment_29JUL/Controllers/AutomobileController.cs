using Assignment16.Model;
using Assignment16.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assignment16.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomobileController : ControllerBase
    {
        private readonly IAutomobileService _service;

        public AutomobileController(IAutomobileService service)
        {
            _service = service;
        }

        [HttpGet]

        public IActionResult getAutomobile()
        {
            return Ok(_service.getAutomobile());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById(int id)
        {
            var automobile = _service.getById(id);

            if (automobile == null)
                return NotFound();

            return Ok(automobile);
        }

        [HttpGet("name/{name}")]

        public IActionResult GetByName(string name)
        {
            var automobile = _service.getByName(name);

            if (automobile == null)
                return NotFound();

            return Ok(automobile);
        }

        [HttpPost]
        public IActionResult Post(Automobile automobile)
        {
            _service.addAutomobile(automobile);

            return Ok("Automobile Added Successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Automobile automobile)
        {
            _service.UpdateAutomobile(id, automobile);

            return Ok("Automobile Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteAutomobile(id);

            return Ok("Automobile Deleted Successfully");
        }



    }
}
