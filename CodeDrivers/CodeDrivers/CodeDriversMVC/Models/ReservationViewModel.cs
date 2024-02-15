using CodeDrivers.Models;
using CodeDrivers.Models.Car;

namespace CodeDriversMVC.Models
{
    public class ReservationViewModel 
    {
        public int CarId { get; set; }
        public CarBrand Brand { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public DateTime ReservationFrom { get; set; }
        public DateTime ReservationTo { get; set; }
        public int ReservationDuration { get; set; }
        public string UserEmail { get; set; }

    }
}
