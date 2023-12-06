using CodeDriversMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CodeDrivers.Models.Car;
using CodeDrivers;

namespace CodeDriversMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Car car = new Car(CarBrand.Audi, "A4");
            //CsvHandler csvHandler = new CsvHandler();
            //var a = csvHandler.GetRawDataFromFile(@"C:\\Users\Janek\Desktop\fakeCredentials.csv");

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}