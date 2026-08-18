using Assignment14.Model;
using Assignment14.Model;
using Microsoft.AspNetCore.Mvc;

namespace _27JUL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product(){ Id = 101, Name = "Eraser", Price = 40, Category = "stationary" },
            new Product(){ Id = 102, Name = "Pen", Price = 100, Category = "stationary" },
            new Product(){ Id = 103, Name = "Shoes", Price = 3000, Category = "Fashion" },
            new Product(){ Id = 104, Name = "Book", Price = 500, Category = "staionary" }
        };

        // Get all products
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        // Get product by Id
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(product);
        }

        // Add new product
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            products.Add(product);
            return Ok(product);
        }

        // Update product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var product1 = products.FirstOrDefault(x => x.Id == id);

            if (product1 == null)
            {
                return NotFound("Product not found.");
            }

            product1.Name = product.Name;
            product1.Price = product.Price;
            product1.Category = product.Category;

            return Ok(product1);
        }

        // Delete product
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            products.Remove(product);

            return Ok("Product deleted successfully.");
        }

        // Get products by Category
        [HttpGet("Category/{category}")]
        public IActionResult GetProductByCategory(string category)
        {
            var result = products.Where(p =>
                p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!result.Any())
            {
                return NotFound("No products found in this category.");
            }

            return Ok(result);
        }

        // Get products by Price
        [HttpGet("Price/{price}")]
        public IActionResult GetProductByPrice(decimal price)
        {
            var result = products.Where(p => p.Price == price).ToList();

            if (!result.Any())
            {
                return NotFound("No products found with this price.");
            }

            return Ok(result);
        }
    }
}