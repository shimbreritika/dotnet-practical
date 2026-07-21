using Microsoft.AspNetCore.Mvc;

namespace ShopEase.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin123")
            {
                return RedirectToAction("Dashboard");
            }

            ViewBag.Message = "Invalid Admin Login";
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
