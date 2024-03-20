using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Helpers;
using CodeDriversMVC.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeDriversMVC.Services
{
    public class ReservationService
    {
        private readonly CodeDriversContext _context;

        public ReservationService(CodeDriversContext context)
        {
            _context = context;
        }

        public ReservationResultModel ReserveCar(ReservationRequestModel model)
        {
            var carToReserve = _context.Set<Car>().FirstOrDefault(car => car.Id == model.CarId);
            carToReserve.IsAvailable = false;

            var owner = _context.Set<User>().FirstOrDefault(user => user.Email.ToLower() == model.UserEmail.ToLower());

            var reservation = new Reservation
            {
                Car = carToReserve,
                Owner = owner,
                ReservationFrom = model.ReservationFrom,
                ReservationTo = model.ReservationTo,
                TotalReservationPrice = model.TotalReservationPrice
            };

            _context.Set<Reservation>().Add(reservation);
            _context.SaveChanges();

            var reservationResult = new ReservationResultModel
            {
                Brand = carToReserve.Brand,
                Model = carToReserve.Model,
                ReservationDuration = reservation.ReservationTo - reservation.ReservationFrom,
                ReservationFrom = reservation.ReservationFrom,
                ReservationTo = reservation.ReservationTo,
                TotalReservationPrice = reservation.TotalReservationPrice,
                OwnerEmail = reservation.Owner.Email
            };

            return reservationResult;
        }


        public List<ReservationReportModel> GetAllReservations()
        {
            var reservations = _context.Set<Reservation>().Include(reservation => reservation.Car).Include(reservation => reservation.Owner).ToList();
            var reservationResult = reservations.Select(reservation => new ReservationReportModel
            {
                Brand = reservation.Car.Brand,
                Model = reservation.Car.Model,
                ReservationFrom = reservation.ReservationFrom,
                ReservationTo = reservation.ReservationTo,
                TotalReservationPrice = reservation.TotalReservationPrice,
                OwnerEmail = reservation.Owner.Email
            }).ToList();

            return reservationResult;
        }

        public bool IsCarAvailable(int carId, DateTime newReservationFrom, DateTime newReservationTo)
        {
            return !_context.Reservations.Where(r => r.Car.Id == carId)
                .Where(r => !(r.ReservationTo <= newReservationFrom || r.ReservationFrom >= newReservationTo))
                .Any();
        }
        public List<ReservationReportModel> GetFilteredReservations(string brandFilter, string modelFilter, string fromDateFilter, string toDateFilter, string priceFilter, string emailFilter)
        {
            var reservations = _context.Set<Reservation>()
                                        .Include(reservation => reservation.Car)
                                        .Include(reservation => reservation.Owner)
                                        .ToList();  

            
            var filteredReservations = reservations.Where(reservation =>
                (string.IsNullOrEmpty(brandFilter) || reservation.Car.Brand.ToString() == brandFilter) &&
                (string.IsNullOrEmpty(modelFilter) || reservation.Car.Model == modelFilter) &&
                (string.IsNullOrEmpty(fromDateFilter) || reservation.ReservationFrom.ToShortDateString() == fromDateFilter) &&
                (string.IsNullOrEmpty(toDateFilter) || reservation.ReservationTo.ToShortDateString() == toDateFilter) &&
                (string.IsNullOrEmpty(priceFilter) || reservation.TotalReservationPrice.ToString() == priceFilter) &&
                (string.IsNullOrEmpty(emailFilter) || reservation.Owner.Email == emailFilter)
            ).ToList();

            var reservationResult = filteredReservations.Select(reservation => new ReservationReportModel
            {
                Brand = reservation.Car.Brand,
                Model = reservation.Car.Model,
                ReservationFrom = reservation.ReservationFrom,
                ReservationTo = reservation.ReservationTo,
                TotalReservationPrice = reservation.TotalReservationPrice,
                OwnerEmail = reservation.Owner.Email
            }).ToList();

            return reservationResult;
        }

    }
}
