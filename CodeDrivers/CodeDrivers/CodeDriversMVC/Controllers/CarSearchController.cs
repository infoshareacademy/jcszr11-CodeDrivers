using CodeDrivers.Models.Car;
using CodeDriversMVC.Services;
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
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.CarBrand = Enum.GetValues(typeof(CarBrand)).Cast<CarBrand>();
            var allCars = _carService.GetAll();
            return View(allCars);
        }
        [HttpPost]
        public IActionResult Search(string searchText)
        {
            ViewBag.CarBrand = Enum.GetValues(typeof(CarBrand)).Cast<CarBrand>();
            if (searchText == "Wszystkie")
            {
                var allCars = _carService.GetAll();
                return View(allCars);
            }

            if (Enum.TryParse<CarBrand>(searchText, out var selectedBrand) && Car.BrandToModelsDict.ContainsKey(selectedBrand))
            {
                var allBrandCar = _carService.GetByBrand(selectedBrand);
                var modelsForBrand = Car.BrandToModelsDict[selectedBrand];

                ViewBag.SelectedBrand = selectedBrand;
                ViewBag.ModelsForBrand = modelsForBrand;

                return View(allBrandCar);
            }
            return RedirectToAction("Index");
        }
    }

}
