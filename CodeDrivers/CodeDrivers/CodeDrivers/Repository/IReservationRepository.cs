using System;
namespace CodeDrivers.Repository
{
	internal interface IReservationRepository<T>
	{
		T Get(); 
	}
}

