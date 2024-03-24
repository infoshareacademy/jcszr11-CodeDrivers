using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodeDriversMVC.Controllers
{
    public class CarSearchController : Controller
    {
        public readonly CarService _carService;
        public CarSearchController(CarService carService)
        {
            _carService = carService;
        }
        // GET: CarSearchController

        // POST: CarSearchController
        [HttpPost]
        public IActionResult Search()
        {
            return View(new Car());
        }


        // POST: CarSearchController/Reservation
        [HttpPost]
        public ActionResult Reservation(int Id, DateTime startTime, DateTime endTime)
        {
            startTime = (startTime < DateTime.Now) ? DateTime.Now : startTime;
            endTime = (endTime < DateTime.Now) ? DateTime.Now : endTime;
            return RedirectToAction("Create", "Reservation", new { carId = Id, startTime, endTime });

        }
    }
}



