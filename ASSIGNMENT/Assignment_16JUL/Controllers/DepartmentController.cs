using Assignment_16JUL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_16JUL.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Details()
        {
            List<Department> departments = new List<Department>
            {
                new Department{Name = "IT",DepartmentHead = "Mr. Amit",HeadContact = "9876543210",HeadEmail = "amit@gmail.com" },

                new Department{Name = "HR",DepartmentHead = "Mrs. Neha",HeadContact = "9876543211",HeadEmail = "neha@gmail.com"},

                new Department {Name = "Finance", DepartmentHead = "Mr. Raj",HeadContact = "9876543212", HeadEmail = "raj@gmail.com"}
            };

            return View(departments);
        }
    }
}
