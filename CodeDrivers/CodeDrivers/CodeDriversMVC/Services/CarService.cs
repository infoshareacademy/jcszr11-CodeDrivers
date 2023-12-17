using CodeDrivers.Models;
using CodeDrivers.Models.Car;

namespace CodeDriversMVC.Services
{
    public class CarService
    {
        private static List<Car> cars = new List<Car>();

        public List<Car> DisplayCars()
        {
            return cars;
        }
        public void AddNewCar(Car car)
        {
            cars.Add(car);
        }
    }
}
