using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers.Models.Car
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationFrom { get; set; }
        public DateTime ReservationTo { get; set; }
        public TimeSpan DurationTime { get; private set; }
        public decimal TotalReservationPrice { get; set; }
        public Car Car { get; set; }
        public User Owner { get; set; }
        public Reservation()
        {
            
        }
        public Reservation(Car car, User user,  DateTime reservationFrom, DateTime reservationTo, decimal totalReservationPrice)
        {
            Car = car;
            Owner = user;
            ReservationFrom = reservationFrom;
            ReservationTo = reservationTo;
            DurationTime = ReservationTo - ReservationFrom;
            TotalReservationPrice = totalReservationPrice; 
        }
    }
}
