using System;
using CodeDrivers.Models;
using CodeDrivers.Models.Car;

namespace CodeDrivers.Repository
{
	internal class ReservationRepository : IReservationRepository<Reservation>
	{
        public static List<Reservation> reservations { get; set; } = new List<Reservation>();
        static int id = 0;

        public ReservationRepository()
		{
		}

        public static int SetId()
        {
            return id++;
        }

        public void Add()
        {
            // dodanie rezerwacji

        }

        public Reservation Get()
        {
            throw new NotImplementedException();
        }
    }
}

