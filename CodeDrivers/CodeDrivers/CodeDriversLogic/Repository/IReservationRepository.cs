using CodeDrivers.Models.Car;
using System;
namespace CodeDrivers.Repository
{
	internal interface IReservationRepository
	{
		Reservation Get();
		List<int> GetCarsReservedInGivenPeriod(DateTime? startDate, DateTime? endDate); 
	}
}

