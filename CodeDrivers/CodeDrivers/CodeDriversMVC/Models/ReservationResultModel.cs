using CodeDrivers.Models.Car;

namespace CodeDriversMVC.Models
{
    public class ReservationResultModel
    {
        public string OwnerEmail { get; set; }
        public CarBrand Brand { get; set; }
        public string Model { get; set; }
        public DateTime ReservationFrom { get; set; }
        public DateTime ReservationTo { get; set; }
        public decimal TotalReservationPrice { get; set; }
        public TimeSpan ReservationDuration { get; set; }
        public string UserEmail { get; set; }

    }
}
