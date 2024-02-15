using CodeDrivers.Models.Car;

namespace CodeDriversMVC.Models
{
    public class ReservationRequestModel
    {
        public int CarId { get; set; }
        public DateTime ReservationFrom { get; set; }
        public DateTime ReservationTo { get; set; }
        public decimal TotalReservationPrice { get; set; }
        public string UserEmail { get; set; }
    }
}
