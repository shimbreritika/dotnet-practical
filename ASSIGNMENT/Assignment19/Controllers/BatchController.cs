using Assignment19.Model;
using Assignment19.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly IBatchService service;

        public BatchController(IBatchService service)
        {
            this.service = service;
        }

       
        [HttpGet]
        public IActionResult GetBatch()
        {
            var batch = service.GetBatch();

            if (batch == null)
            {
                return NotFound("Batch not found");
            }

            return Ok(batch);
        }

       
        [HttpPost]
        public IActionResult AddBatch(Batch batch)
        {
            var result = service.AddBatch(batch);

            return Ok(result);
        }

      
        [HttpPut]
        public IActionResult UpdateBatch(int id ,Batch batch)
        {
            var result = service.UpdateBatch(id ,batch);

            if (result == null)
            {
                return NotFound("Batch not found");
            }

            return Ok(result);
        }

       
        [HttpDelete]
        public IActionResult DeleteBatch(Batch batch)
        {
            var result = service.DeleteBatch(batch);

            if (result == null)
            {
                return NotFound("Batch not found");
            }

            return Ok(result);
        }
    }
}
