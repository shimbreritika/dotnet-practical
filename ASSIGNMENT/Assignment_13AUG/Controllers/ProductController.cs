using Assignment_13AUG.Dto;
using Assignment_13AUG.Model;
using Assignment_13AUG.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_13AUG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        // Customer + Admin
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }

        // Customer + Admin
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var product = service.GetById(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        // Only Admin
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(ProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };

            service.Add(product);

            return Ok("Product added successfully");
        }

        // Only Admin
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDto dto)
        {
            var product = service.GetById(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            service.Update(product);

            return Ok("Product updated successfully");
        }

        // Only Admin
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = service.GetById(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            service.Delete(product);

            return Ok("Product deleted successfully");
        }

    }
    }
