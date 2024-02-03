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
        public ActionResult Create(int carId)
        {
            ReservationViewModel mymodel = new ReservationViewModel();
            var car = _carService.GetById(carId);

            mymodel.Car = car;
            mymodel.Reservation = new Reservation();
            mymodel.User = new User();
            // minimum danych potrzebnych do wyświetlenia
            return View(mymodel);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationViewModel model)
        {
            // zmienić nazwę modelu, np. ReservationRequestModel
            try
            {
                // rezultat rezerwacji, np. ReservationResultModel
                // docelowo zrobić z tego klasy statyczne, tzw. mappery
                _reservationService.ReserveCar(model.Car.Id, model.User.Email, model.Reservation.ReservationFrom, model.Reservation.ReservationTo, model.Car.PricePerDay);
                //return RedirectToAction("Success", new { brand = model.Car.Brand, model = model.Car.Model, reservationFrom = model.Reservation.ReservationFrom, reservationTo = model.Reservation.ReservationTo, price = model.Car.PricePerDay });
                return RedirectToAction("Success", model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ReservationController/Edit/5
        //public ActionResult Success(CarBrand brand, string model, DateTime reservationFrom, DateTime reservationTo, decimal price)
        //{
        //    var viewModel = new ReservationViewModel
        //    {
        //        Car = new Car { Brand = brand, Model = model},
        //        Reservation = new Reservation {ReservationFrom = reservationFrom, ReservationTo = reservationTo, TotalReservationPrice = price }
        //    };
        //    return View(viewModel);
        //}
        public ActionResult Success(ReservationViewModel model)
        {
            
            return View(model);
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
