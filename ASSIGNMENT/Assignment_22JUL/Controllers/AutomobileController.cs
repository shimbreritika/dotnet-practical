
using Assignment12.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileManagementSystem.Controllers
{
    public class AutomobileController : Controller
    {
        // Display Registration Form
        public IActionResult Register()
        {
            return View();
        }

        // Accept Automobile Details
        [HttpPost]
        public IActionResult Register(Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                // Store Vehicle Name and Brand
                TempData["VehicleName"] = automobile.VehicleName;
                TempData["Brand"] = automobile.Brand;

                return RedirectToAction("Success");
            }

            return View(automobile);
        }

        // Success Page
        public IActionResult Success()
        {
            if (TempData["VehicleName"] == null)
            {
                return RedirectToAction("Register");
            }

            TempData.Keep();

            return View();
        }
    }
}
