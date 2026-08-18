using Assignment_5AUG.Model;
using Assignment_5AUG.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_5AUG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = service.GetOrder(id);

            if (order == null)
                return NotFound("Order is not available");

            return Ok(order);
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            service.AddOrder(order);

            return Ok(order);
        }

        [HttpPut]
        public IActionResult UpdateOrder(Order order)
        {
            service.UpdateOrder(order);

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            service.DeleteOrder(id);

            return Ok("Order deleted successfully");
        }
    }
}
