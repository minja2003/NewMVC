using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using NewMVC.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NewMVC.Controllers
{
    public class HomeController : Controller
    {
        private TripContext db = new TripContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            //Models.Trip mytrip = new Models.Trip();
            //Models.Stop mystop = new Models.Stop();

            ViewBag.test = db.Trips;



            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

       
    }
}
