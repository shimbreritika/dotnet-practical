using Assignment_16JUL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_16JUL.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {

            List<Employee> employees = new List<Employee>
            {
                new Employee{EmployeeId = 1,Name = "Ritika",Department = "IT",Salary = 50000, Email = "ritika@gmail.com" },

                new Employee{ EmployeeId = 2,Name = "Rahul",Department = "HR",Salary = 45000,Email = "rahul@gmail.com"},

                new Employee { EmployeeId = 3,Name = "Priya",Department = "Finance",Salary = 55000,Email = "priya@gmail.com" }
            };
            return View(employees);
        }
    }
}
