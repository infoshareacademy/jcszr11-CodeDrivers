using CodeDrivers.Models;
using CodeDrivers.Models.Car;

namespace CodeDriversMVC.Models
{
    public class ReservationViewModel 
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public User User { get; set; }
        public Reservation Reservation { get; set; }

    }
}
