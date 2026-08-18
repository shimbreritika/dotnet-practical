using Microsoft.AspNetCore.Mvc;
using ShopEase.Models;

namespace ShopEase.Controllers
{
    public class CategoryController : Controller
    {
        static List<Category> categories = new List<Category>()
        {
            new Category{ CategoryId=1, CategoryName="Electronics"},
            new Category{ CategoryId=2, CategoryName="Books"},
            new Category{ CategoryId=3, CategoryName="Fashion"}
        };

        public IActionResult Index()
        {
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            categories.Add(category);
            return RedirectToAction("Index");
        }
    }
}