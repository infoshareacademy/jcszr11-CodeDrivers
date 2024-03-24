using CodeDriversMVC.Models;

namespace CodeDriversMVC.Models
{
    public class CarReservationListView
    {
        public CarModel Car { get; set; }
        public List<ReservationViewModel> Reservations { get; set; }
    }
}
