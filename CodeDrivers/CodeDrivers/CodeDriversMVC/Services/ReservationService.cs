using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Helpers;
using CodeDriversMVC.Models;
using Microsoft.EntityFrameworkCore;

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


        public List<ReservationResultModel> GetAllReservations()
        {
            var reservationResult= new List<ReservationResultModel>();
            return reservationResult;
        }

        public bool IsCarAvailable(int carId, DateTime newReservationFrom, DateTime newReservationTo)
        {
            return !_context.Reservations.Where(r => r.Car.Id == carId)
                .Where(r => !(r.ReservationTo <= newReservationFrom || r.ReservationFrom >= newReservationTo))
                .Any();
        }

    }
}
