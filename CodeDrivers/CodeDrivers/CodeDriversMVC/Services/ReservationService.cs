using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Helpers;

namespace CodeDriversMVC.Services
{
    public class ReservationService
    {
        private readonly CodeDriversContext _context;

        public ReservationService(CodeDriversContext context)
        {
            _context = context;
        }

        public void ReserveCar(int carId, string userEmail, DateTime reservationFrom, DateTime reservationTo, decimal pricePerDay)
        {
            var carToReserve = _context.Set<Car>().FirstOrDefault(car => car.Id == carId);
            carToReserve.IsAvailable = false;

            var owner = _context.Set<User>().FirstOrDefault(user => user.Id == userEmail);
            var totalPrice = PriceCalculationHelper.CalculateTotalPrice(reservationFrom, reservationTo, pricePerDay);

            var reservation = new Reservation
            {
                Car = carToReserve,
                Owner = owner,
                ReservationFrom = reservationFrom,
                ReservationTo = reservationTo,
                TotalReservationPrice = totalPrice
            };

            _context.Set<Reservation>().Add(reservation);
            _context.SaveChanges();
        }
    }
}
