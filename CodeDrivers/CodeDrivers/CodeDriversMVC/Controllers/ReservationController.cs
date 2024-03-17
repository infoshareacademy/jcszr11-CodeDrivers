using AutoMapper;
using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Helpers;
using CodeDriversMVC.Models;
using CodeDriversMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using System.Security.Claims;

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
            ViewData["DateStart"] = startTime;
            ViewData["DateEnd"] = endTime;
            var durationTime = (int)Math.Ceiling((endTime - startTime).TotalDays);
            ViewData["DurationTime"] = durationTime;
            ViewData["TotalPrice"] = (int)(car.PricePerDay * (int)durationTime);
            ReservationViewModel reservationView = new ReservationViewModel
            {
                CarId = carId,
                Brand = car.Brand,
                Model = car.Model,
                PricePerDay = car.PricePerDay,
                UserEmail = User.FindFirstValue(ClaimTypes.Email)
            };
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("ChooseLoginOrRegistration");
            }


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

        public async Task<ActionResult> Success(ReservationResultModel reservationResultModel)
        {
            await EmailService.SendEmailAsync("codedrivers@wp.pl", "Potwierdzenie rezerwacji", "qwert");
            return View(reservationResultModel);
        }
        public ActionResult ChooseLoginOrRegistration()
        {
            return View();
        }
        public IActionResult ViewAllReservations()
        {
            List<ReservationResultModel> reservations = _reservationService.GetAllReservations();
            return View(reservations);
        }

    }
}
