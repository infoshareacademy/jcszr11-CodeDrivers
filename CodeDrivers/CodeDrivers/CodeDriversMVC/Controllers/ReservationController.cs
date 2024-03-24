using AutoMapper;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using CodeDriversMVC.Services;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Drawing;

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
            var message = EmailService.GenerateEmailContent(reservationResultModel);
            await EmailService.SendEmailAsync(reservationResultModel.OwnerEmail, "Potwierdzenie rezerwacji", message);
            return View(reservationResultModel);
        }
        public ActionResult ChooseLoginOrRegistration()
        {
            return View();
        }
        public IActionResult ViewAllReservations()
        {
            var reservations = _reservationService.GetAllReservations();
            return View(reservations);
        }
        public string GetReservationColor(ReservationReportModel reservation)
        {
            var currentDate = DateTime.Now;
            var reservationFrom = reservation.ReservationFrom;
            var reservationTo = reservation.ReservationTo;

            if (currentDate > reservationTo)
            {
                return "gray"; 
            }
            else if (currentDate >= reservationFrom && currentDate <= reservationTo)
            {
                return "green";
            }
            else
            {
                return "blue";
            }
        }
        public IActionResult GeneratePDFReport(string brandFilter, string modelFilter, string fromDateFilter, string toDateFilter, string priceFilter, string emailFilter)
        {
            try
            {
                bool anyFilterSet = !string.IsNullOrEmpty(brandFilter) || !string.IsNullOrEmpty(modelFilter) || !string.IsNullOrEmpty(fromDateFilter) ||
                                    !string.IsNullOrEmpty(toDateFilter) || !string.IsNullOrEmpty(priceFilter) || !string.IsNullOrEmpty(emailFilter);
                List<ReservationReportModel> reservations = anyFilterSet ?
                    _reservationService.GetFilteredReservations(brandFilter, modelFilter, fromDateFilter, toDateFilter, priceFilter, emailFilter) :
                    _reservationService.GetAllReservations();
                if (reservations.Count == 0)
                {
                    return NotFound("Brak rezerwacji spełniających kryteria filtrowania.");
                }
                MemoryStream stream = GeneratePDF(reservations);
                return File(stream, "application/pdf", "raport.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd generowania raportu PDF: {ex.Message}");
                return BadRequest("Błąd generowania raportu PDF.");
            }
        }
        private MemoryStream GeneratePDF(List<ReservationReportModel> reservations)
        {
            MemoryStream stream = new MemoryStream();
            Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document();
            Aspose.Pdf.Page page = pdfDocument.Pages.Add();
            Aspose.Pdf.Text.TextFragment title = new Aspose.Pdf.Text.TextFragment("Raport rezerwacji");
            title.TextState.Font = FontRepository.FindFont("Arial");
            title.TextState.FontSize = 16;
            title.TextState.FontStyle = Aspose.Pdf.Text.FontStyles.Bold;
            title.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Left;
            page.Paragraphs.Add(title);
            Aspose.Pdf.Table table = new Aspose.Pdf.Table();
            page.Paragraphs.Add(table);
            table.ColumnWidths = "60 60 60 60 70 400";
            table.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 1f);
            table.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 0.5f);
            Aspose.Pdf.Row headerRow = table.Rows.Add();
            headerRow.FixedRowHeight = 40;
            headerRow.Cells.Add("Marka auta");
            headerRow.Cells.Add("Model auta");
            headerRow.Cells.Add("Od kiedy");
            headerRow.Cells.Add("Do kiedy");
            headerRow.Cells.Add("Cena wynajmu");
            headerRow.Cells.Add("Email użytkownika");
            foreach (var reservation in reservations)
            {
                Aspose.Pdf.Row row = table.Rows.Add();
                row.FixedRowHeight = 40;
                row.Cells.Add(reservation.Brand.ToString()).Alignment = Aspose.Pdf.HorizontalAlignment.Center;
                row.Cells.Add(reservation.Model).Alignment = Aspose.Pdf.HorizontalAlignment.Center;
                row.Cells.Add(reservation.ReservationFrom.ToShortDateString()).Alignment = Aspose.Pdf.HorizontalAlignment.Center;
                row.Cells.Add(reservation.ReservationTo.ToShortDateString()).Alignment = Aspose.Pdf.HorizontalAlignment.Center;
                row.Cells.Add(reservation.TotalReservationPrice.ToString()).Alignment = Aspose.Pdf.HorizontalAlignment.Center;
                row.Cells.Add(reservation.OwnerEmail).Alignment = Aspose.Pdf.HorizontalAlignment.Left;

            }
         pdfDocument.Save(stream);
            stream.Position = 0;
            return stream;
        }

    }
}
