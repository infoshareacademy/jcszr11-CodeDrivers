using AutoMapper;
using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Helpers;
using CodeDriversMVC.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace CodeDriversMVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly CarService _carService;
        private readonly ReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(CarService carService, ReservationService reservationService, IMapper mapper)
        {
            _carService = carService;
            _reservationService = reservationService;
            _mapper = mapper;
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
            var car = _carService.GetById(carId);
            ReservationViewModel reservationViewModel = new ReservationViewModel
            {
                CarId = carId,
                Brand = car.Brand,
                Model = car.Model,
                PricePerDay = car.PricePerDay
            };

            return View(reservationViewModel);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationViewModel model)
        {
            // zmienić nazwę modelu, np. ReservationRequestModel
            try
            {
                // docelowo zrobić z tego klasy statyczne, tzw. mappery
                //var totalPrice = PriceCalculationHelper.CalculateTotalPrice(model.ReservationFrom, model.ReservationTo, model.PricePerDay);
                // reservationRequest ma zawierać to samo + policzone totalPrice
                var reservationRequestModel = _mapper.Map<ReservationRequestModel>(model);
                var reservationResult = _reservationService.ReserveCar(reservationRequestModel);

                return RedirectToAction("Success", reservationResult);
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Success(ReservationResultModel reservationResultModel)
        {
            return View(reservationResultModel);
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
