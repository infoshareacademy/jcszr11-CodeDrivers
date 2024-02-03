using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeDriversMVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly CarService _carService;
        private readonly ReservationService _reservationService;
        public ReservationController(CarService carService, ReservationService reservationService)
        {
            _carService = carService;
            _reservationService = reservationService;
        }
        // GET: ReservationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservationController/Create
        public ActionResult Create(int carId, DateTime startTime, DateTime endTime)
        {
            ReservationViewModel mymodel = new ReservationViewModel();
            var car = _carService.GetById(carId);
            ViewData["DateStart"] = startTime;
            ViewData["DateEnd"] = endTime;
            var durationTime = (endTime - startTime).TotalDays;
            ViewData["DurationTime"] = durationTime;
            ViewData["TotalPrice"] = (car.PricePerDay * (int)durationTime);
            mymodel.Car = car;
            mymodel.Reservation = new Reservation();
            mymodel.User = new User();
            return View(mymodel);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationViewModel model)
        {
            try
            {
                _reservationService.ReserveCar(model.Car.Id, model.User.Email, model.Reservation.ReservationFrom, model.Reservation.ReservationTo, model.Car.PricePerDay);
                TempData["SuccessReservation"] = "Auto zostało zarezerwowane.";
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
