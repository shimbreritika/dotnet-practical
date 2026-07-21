using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> empolyee = new List<Employee>()
            {
                new Employee{ EmpId = 2324, EmpName = "Rakesh", Department = "IT", Salary = 56000, Email = "vermarakesh@gmail.com" },
                new Employee{ EmpId = 2325, EmpName = "Janvi", Department = "HR", Salary = 60000, Email = "kapoorjanvi@gmail.com" },
                new Employee{ EmpId = 2326, EmpName = "Deepika", Department = "IT", Salary = 56000, Email = "singhdeepika@gmail.com" },
                new Employee{ EmpId = 2327, EmpName = "Kalyani", Department = "IT", Salary = 56000, Email = "shindekalyani@gmail.com" },
                new Employee{ EmpId = 2328, EmpName = "Omkar", Department = "HR", Salary = 60000, Email = "rotheomkar@gmail.com" }
            };
            return View();
        }

      
    }
}
