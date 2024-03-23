using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;

namespace CodeDriversTests
{
    public class ReservationTest
    {
        [Fact]
        public void IsCarAvailable_WhenNoReservations_ReturnsTrue()
        {
            // Arrange
            var data = new List<Reservation>
            {
                new Reservation { ReservationId = 1, Car = new Car{Id = 3 }, ReservationFrom = DateTime.Now.AddDays(1), ReservationTo = DateTime.Now.AddDays(3)},
                new Reservation { ReservationId = 2, Car = new Car{Id = 3 }, ReservationFrom = DateTime.Now.AddDays(-45), ReservationTo = DateTime.Now.AddDays(-3)},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Reservation>>();
            mockSet.As<IQueryable<Reservation>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Reservation>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Reservation>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Reservation>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<CodeDriversMVC.DataAccess.CodeDriversContext>();
            mockContext.Setup(c => c.Reservations).Returns(mockSet.Object);
            var reservationService = new ReservationService(mockContext.Object);

            var carId = 3;
            var newReservationFrom = DateTime.Now.AddDays(5);
            var newReservationTo = DateTime.Now.AddDays(8);

            // Act
            var isAvailable = reservationService.IsCarAvailable(carId, newReservationFrom, newReservationTo);

            // Assert
            Assert.True(isAvailable);
        }
        public void IsCarAvailable_WhenNoReservations_ReturnsFalse()
        {

        }


    }
}