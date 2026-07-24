using Assignment13.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment13.Controllers
{
    public class StationaryController : Controller
    {
        public IActionResult Login()
        {
            //check the login
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return RedirectToAction("Login", "Home");
            }

            List<Stationary> stationary = new List<Stationary>()
            {
                new Stationary{ID=1002, Name="Pensil", Price =10, Stock =46 },
                new Stationary{ID=1003, Name="Notebook", Price =150,Stock=89},
                new Stationary{ID=1104, Name="Marker", Price =50, Stock=34},
                new Stationary{ID=1005, Name="Scale", Price =20,Stock=34 },
                new Stationary{ID=1006, Name="Eraser", Price=25 , Stock=70 }
            };
            return View("Details", stationary);
        }
    }
}
