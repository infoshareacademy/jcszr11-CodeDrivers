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

        public CarSearchController()
        {
            _carService = new CarService();
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
        public ActionResult Reservation(int Id)
        {
            var carById = _carService.GetById(Id);
            return View(carById);
        }
    }

}
