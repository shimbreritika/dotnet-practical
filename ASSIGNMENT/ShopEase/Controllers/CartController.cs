using Microsoft.AspNetCore.Mvc;
using ShopEase.Models;

namespace ShopEase.Controllers
{
    public class CartController : Controller
    {
        static List<CartItem> cart = new List<CartItem>();

        public IActionResult Index()
        {
            return View(cart);
        }

        public IActionResult Add(Product product)
        {
            cart.Add(new CartItem
            {
                Product = product,
                Quantity = 1
            });

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            cart.Clear();
            return RedirectToAction("Index");
        }
    }
}
