using System;
namespace CodeDrivers.Repository
{
	internal interface IReservationRepository<T>
	{
		T Get();
		List<int> GetCarsReservedInGivenPeriod(DateTime? startDate, DateTime? endDate); 
	}
}

