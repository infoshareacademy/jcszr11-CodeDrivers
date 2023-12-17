using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeDriversMVC.Controllers
{
    public class CarController : Controller
    {
        public readonly CarService carService;
        public CarController()
        {
            carService = new CarService();
        }

        // GET: CarController
        public ActionResult Index()
        {
            var allCars = carService.GetAll();
            return View(allCars);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            var allCars = carService.GetById(id);
            return View(allCars);
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            _carService.AddNewCar(car);
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car allCars)
        {
            carService.Create(allCars);
            TempData["Success"] = "Auto zostało dodane";
            return RedirectToAction(nameof(Index));
        }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            var allCars= carService.GetById(id);
            return View(allCars);
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car allCars)
        {
            carService.Update(allCars);
            return RedirectToAction(nameof(Index));
        }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            var allCars=carService.GetById(id);
            return View(allCars);
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car allCars)
        {
            carService.RemoveCar(id);
            TempData["Delete"] = "Auto zostało usunięte.";
            return RedirectToAction(nameof(Index));
        }
            catch
            {
                return View();
            }
        }
    }
}
