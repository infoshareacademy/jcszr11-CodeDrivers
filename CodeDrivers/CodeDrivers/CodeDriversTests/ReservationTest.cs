using CodeDrivers.Models.Car;
using CodeDriversMVC.Services;
using Moq;

namespace CodeDriversTests
{
    public class ReservationTest
    {
        [Fact]
        public void IsCarAvailable_WhenNoReservations_ReturnsTrue()
        {
            // Arrange
            var mockContext = new Mock<CodeDriversMVC.DataAccess.CodeDriversContext>();
            var reservationService = new ReservationService(mockContext.Object);
            var carId = 3;
            var newReservationFrom = DateTime.Now.AddDays(1);
            var newReservationTo = DateTime.Now.AddDays(3);

            // Act
            var isAvailable = reservationService.IsCarAvailable(carId, newReservationFrom, newReservationTo);

            // Assert
            Assert.True(isAvailable);
        }

        [Fact]
        public void IsCarAvailable_WhenNoReservations_ReturnsTrue2()
        {
            // Arrange
            var mockContext = new Mock<CodeDriversMVC.DataAccess.CodeDriversContext>();
            var reservationService = new ReservationService(mockContext.Object);
            var carId = 3;
            var newReservationFrom = DateTime.Now.AddDays(1);
            var newReservationTo = DateTime.Now.AddDays(3);

            // Act
            var isAvailable = reservationService.IsCarAvailable2(carId, newReservationFrom, newReservationTo);

            // Assert
            Assert.True(isAvailable);
        }
    }
}