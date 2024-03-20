using CodeDrivers.Models.Car;

namespace CodeDriversMVC.Models
{
    public class ReservationReportModel
    {
       
        public CarBrand Brand { get; set; }
        public string Model { get; set; }
        public DateTime ReservationFrom { get; set; }
        public DateTime ReservationTo { get; set; }
        public decimal TotalReservationPrice { get; set; }
        public string OwnerEmail { get; set; }

    }
}
