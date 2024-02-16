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
        public ActionResult Create(int carId, DateTime startTime, DateTime endTime)
        {
            var car = _carService.GetById(carId);
            ReservationViewModel reservationView = new ReservationViewModel
            {
                CarId = carId,
                Brand = car.Brand,
                Model = car.Model,
                PricePerDay = car.PricePerDay
            };

            return View(reservationView);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationViewModel reservationView)
        {
            try
            {
                var reservationRequest = _mapper.Map<ReservationRequestModel>(reservationView) ;
                var reservationResult = _reservationService.ReserveCar(reservationRequest);

                return RedirectToAction("Success", reservationResult);
            }
            catch
            {
                return View(reservationView);
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
