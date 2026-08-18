using Assignment12.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileManagementSystem.Controllers
{
    public class ManufacturerController : Controller
    {
        // Display Manufacturer Form
        [HttpGet]
        public IActionResult Details()
        {
            // Allow only after Automobile Registration
            if (TempData["VehicleName"] == null)
            {
                return RedirectToAction("Register", "Automobile");
            }

            TempData.Keep();

            return View();
        }

        // Accept Manufacturer Details
        [HttpPost]
        public IActionResult Details(Manufacturer manufacturer)
        {
            if (TempData["VehicleName"] == null)
            {
                return RedirectToAction("Register", "Automobile");
            }

            TempData.Keep();

            if (ModelState.IsValid)
            {
                return View("ManufacturerDetails", manufacturer);
            }

            return View(manufacturer);
        }
    }
}
