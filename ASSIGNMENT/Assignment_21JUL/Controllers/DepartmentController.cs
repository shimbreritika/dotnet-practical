using Assignment11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment11.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Details()
        {
            if (TempData["EmployeeName"] == null)
            {
                return RedirectToAction("Register", "Employee");
            }

            TempData.Keep();

            List<Department> departments = new List<Department>()
            {
                new Department { DeptName = "HR", DeptHead = "Rahul Sharma", DeptHeadContact = 9876543210,  HeadEmail = "sharmarahul@gmail.com" },
                
                new Department {DeptName = "Finance",  DeptHead = "Amit Verma",DeptHeadContact = 9875376435 , HeadEmail = "vermaamit@gmail.com" },

                new Department { DeptName = "Marketing",  DeptHead = "Priya Singh", DeptHeadContact = 9876543212, HeadEmail = "singhpriya@gmail.com" },
            
                new Department { DeptName = "Sales",  DeptHead = "Omkar Rothe", DeptHeadContact = 9764563212,HeadEmail = "rotheomkar@gmail.com" }
               
            };

            return View(departments);
        }
    }
}
