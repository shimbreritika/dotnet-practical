using Microsoft.AspNetCore.Mvc;
using ShopEase.Models;

namespace ShopEase.Controllers
{
    public class AccountController : Controller
    {
        static List<Customer> customers = new List<Customer>();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            customers.Add(customer);
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = customers.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user != null)
                return RedirectToAction("Index", "Home");

            ViewBag.Message = "Invalid Login";
            return View();
        }
    }
}
