using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using CodeDrivers.Repository;
using CodeDriversMVC.Services.Interfaces;

namespace CodeDriversMVC.Services
{
    public class CarService : IRepository<Car>
    {
        static int id = 7;
        public static List<Car> cars { get; set; } = new List<Car>
            {
                new() {Id=1, Brand = CarBrand.Toyota, Model = "Yaris", Motor = MotorType.Hybrydowy, GearTransmission = GearType.Automatyczna, Segment = CarSegment.B, PricePerDay = 150},
                new() {Id=2, Brand = CarBrand.Fiat, Model = "500", Motor = MotorType.Benzynowy, GearTransmission = GearType.Manualna, Segment = CarSegment.A, PricePerDay = 130},
                new() {Id=3, Brand = CarBrand.Seat, Model = "Arona", Motor = MotorType.Benzynowy, GearTransmission = GearType.Manualna, Segment = CarSegment.Crossover, PricePerDay = 190},
                new() {Id=4, Brand = CarBrand.BMW, Model = "1", Motor = MotorType.Benzynowy, GearTransmission = GearType.Automatyczna, Segment = CarSegment.C, PricePerDay = 220},
                new() {Id=5, Brand = CarBrand.Audi, Model = "A4", Motor = MotorType.Diesel, GearTransmission = GearType.Automatyczna, Segment = CarSegment.D, PricePerDay = 300},
                new() {Id=6, Brand = CarBrand.Mercedes, Model = "E-klasa", Motor = MotorType.Diesel, GearTransmission = GearType.Automatyczna, Segment = CarSegment.E, PricePerDay = 450},
            };
        public List<Car> GetAll()
        {
            return cars;
        }
        public static int SetId()
        {
            return id++;
        }
        public void Update(Car updatedCar)
        {
            Car carToBeUpdated = GetById(updatedCar.Id);
            carToBeUpdated.Brand = updatedCar.Brand;
            carToBeUpdated.Model = updatedCar.Model;
            carToBeUpdated.Segment = updatedCar.Segment;
            carToBeUpdated.GearTransmission = updatedCar.GearTransmission;
            carToBeUpdated.PricePerDay = updatedCar.PricePerDay;
            carToBeUpdated.IsAvailable = true;
        }
        public Car GetById(int id)
        {
            return cars.FirstOrDefault(m => m.Id == id);
        }
        public List<Car> GetByBrand(CarBrand brand)
        {
            return cars.Where(m => m.Brand == brand).ToList();
        }
        public void Create(Car nextCar)
        {
            nextCar.Id = SetId();
            cars.Add(nextCar);
        }
        public void Remove(int id)
        {
            Car carToBeRemoved = GetById(id);
            if (carToBeRemoved != null)
            {
                cars.Remove(carToBeRemoved);
            }
        }
        public bool ValidatePrice(decimal price)
        {
            if (price < 50)
            {
                return false;
            }
            return true;
        }
    };
}
