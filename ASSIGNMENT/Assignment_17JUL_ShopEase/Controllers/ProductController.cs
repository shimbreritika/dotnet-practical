using Microsoft.AspNetCore.Mvc;
using ShopEase.Models;

namespace ShopEase.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product
            {
                ProductId = 1001,
                Name = "Laptop",
                Category = "Electronics",
                Description = "Dell Inspiron",
                Price = 65000,
                Quantity = 20,
                Brand = "Dell",
                Discount = 10,
                Rating = 4.6
            }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            products.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);

            if (product != null)
                products.Remove(product);

            return RedirectToAction("Index");
        }
    }
}
