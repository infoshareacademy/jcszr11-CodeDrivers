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
        public decimal TotalReservationPrice { get; set; }
        public int CarId { get; } //carId
        public string UserNumber { get; } //userNumber

        public Reservation(int carID, string userNumber)
        {
            CarId= carID;
            UserNumber= userNumber;

        }
    }
}
