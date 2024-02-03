using CodeDriversMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CodeDrivers.Models.Car;
using CodeDrivers;
using CodeDriversMVC.Services;
using CodeDrivers.Repository;
using CodeDriversMVC.DataAccess;

namespace CodeDriversMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarService _carService;

        public HomeController(ILogger<HomeController> logger, CarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        public IActionResult Index()
        {
            ViewBag.CarBrand = Enum.GetValues(typeof(CarBrand)).Cast<CarBrand>();
            var allCars = _carService.GetAll();
            return View(allCars);
        }
        [HttpPost]
        public IActionResult Index(string searchTextBrand, string segmentDropdownText, string gearTypeDropdownText, string motorTypeDropdownText, DateTime dateStart, DateTime dateEnd)
        {
            ViewData["DateStart"] = dateStart;
            ViewData["DateEnd"] = dateEnd;
            if (Enum.TryParse(searchTextBrand, out CarBrand brand)
                && Enum.TryParse(segmentDropdownText, out CarSegment segment)
                && Enum.TryParse(gearTypeDropdownText, out GearType gearType)
                && Enum.TryParse(motorTypeDropdownText, out MotorType motorType))
            {
                var carFromBrand = _carService.GetByBrand(brand);
                //var carFromSegment = _carService.GetByAllFilters(brand,segment,gearType,motorType);
                return View(carFromBrand);
            }
            if (searchTextBrand == "Wszystko")
            {


                var allCars = _carService.GetAll();
                return View(allCars);
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpPost]


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Footer()
        {
            return View();
        }
    }
}