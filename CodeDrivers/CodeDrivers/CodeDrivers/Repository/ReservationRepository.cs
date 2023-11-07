using System;
using System.Security.Cryptography;
using CodeDrivers.Models;
using CodeDrivers.Models.Car;

namespace CodeDrivers.Repository
{
	internal class ReservationRepository : IReservationRepository<Reservation>
	{
        public List<Reservation> reservations { get; set; } = new List<Reservation>();

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

        public List<int> GetCarsReservedInGivenPeriod(DateTime? startDate, DateTime? endDate)
        {
            List<int> bookedCarIds = new List<int>();

            foreach (Reservation reservation in reservations)
            {
                if(startDate >= reservation.ReservationFrom || startDate <= reservation.ReservationTo ||
                    endDate >= reservation.ReservationFrom || endDate <= reservation.ReservationTo)
                {
                    bookedCarIds.Add(reservation.Car.Id); 
                }

            }

            return bookedCarIds; 
        }
    }
}

