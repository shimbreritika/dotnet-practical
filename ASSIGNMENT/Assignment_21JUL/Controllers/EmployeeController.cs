using Assignment11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment11.Controllers
{
    public class EmployeeController : Controller
    {
        // Display Registration Form
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Register Employee
        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            if (ModelState.IsValid)
            {
                TempData["EmployeeName"] = employee.EmpName;
                TempData["Department"] = employee.Department;

                return RedirectToAction("Details", "Department");
            }

            return View(employee);
        }
    }
}