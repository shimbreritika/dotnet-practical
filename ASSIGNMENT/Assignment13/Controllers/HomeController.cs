using Assignment13.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment13.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        // POST : Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "12345")
            {
                HttpContext.Session.SetString("User", username);

                return RedirectToAction("Login", "Stationary");
            }

            ViewBag.Message = "Invalid Username or Password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
