using Assignment10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departments = new List<Department>()
            {
                new Department{DeptName="Finance",DeptHead="Rahul Verma",HeadContact=9876543211,HeadEmail="vermarahul@gmail.com"},
                new Department{DeptName="HR",DeptHead="Neha Gupta",HeadContact=9876543212,HeadEmail="guptaneha@gmail.com"},
                new Department{DeptName="Marketing",DeptHead="Amit Patil",HeadContact=9876543213,HeadEmail="patilamit@gmail.com"},
                new Department{DeptName="IT",DeptHead="Sneha Kulkarni",HeadContact=9876543214,HeadEmail="kulkarnisneha@gmail.com"},
                new Department{DeptName="Sales",DeptHead="Kiran Mehta",HeadContact=9876543215,HeadEmail="mehtakiran@gmail.com"},
                new Department{DeptName="Customer Support",DeptHead="Anil Joshi",HeadContact=9876543216,HeadEmail="joshianil@gmail.com"}

            };
            return View(departments);
        }
    }
}
