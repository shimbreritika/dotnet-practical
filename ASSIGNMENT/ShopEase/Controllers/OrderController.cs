using Microsoft.AspNetCore.Mvc;
using ShopEase.Models;

namespace ShopEase.Controllers
{
    public class OrderController : Controller
    {
        static List<Order> orders = new List<Order>();

        public IActionResult Index()
        {
            return View(orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            orders.Add(order);
            return RedirectToAction("Index");
        }
    }
}
