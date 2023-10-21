using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers.Models.Car
{
    internal class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationFrom { get; set; }
        public DateTime ReservationTo { get; set; }
        public TimeSpan DurationTime { get; private set; }
        public decimal TotalReservationPrice { get; set; }
        public Car Car { get; }

        public Reservation(Car car)
        {
            Car = car;
        }
    }
}
