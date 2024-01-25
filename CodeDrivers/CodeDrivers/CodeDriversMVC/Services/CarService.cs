using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using CodeDrivers.Repository;

namespace CodeDriversMVC.Services
{
    public class CarService
    {
        static int id = 7;
        public static List<Car> cars { get; set; } =
            new List<Car>
            {
                new() {Id=1, Brand = CarBrand.Audi, Model = "A4", Motor = MotorType.Diesel, GearTransmission = GearType.Automatyczna, Segment = CarSegment.D, PricePerDay = 300},
                new() {Id=2, Brand = CarBrand.Toyota, Model = "Yaris", Motor = MotorType.Hybrydowy, GearTransmission = GearType.Automatyczna, Segment = CarSegment.B, PricePerDay = 150},
                new() {Id=3, Brand = CarBrand.Fiat, Model = "500", Motor = MotorType.Benzynowy, GearTransmission = GearType.Manualna, Segment = CarSegment.A, PricePerDay = 130},
                new() {Id=4, Brand = CarBrand.Seat, Model = "Arona", Motor = MotorType.Benzynowy, GearTransmission = GearType.Manualna, Segment = CarSegment.Crossover, PricePerDay = 190},
                new() {Id=5, Brand = CarBrand.BMW, Model = "seria 1", Motor = MotorType.Benzynowy, GearTransmission = GearType.Automatyczna, Segment = CarSegment.C, PricePerDay = 220},
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
        public void Update(Car car)
        {
            Car allCars =GetById(car.Id);
            allCars.Brand=car.Brand;
            allCars.Model=car.Model;
            allCars.Segment=car.Segment;
            allCars.GearTransmission=car.GearTransmission;
            allCars.PricePerDay=car.PricePerDay;
            allCars.IsAvailable=true;

        }
        public Car GetById(int id)
        {
            return cars.FirstOrDefault(m => m.Id == id);
        }
        public List<Car> GetByBrand(CarBrand brand)
        {
            return cars.Where(m => m.Brand == brand).ToList();
        }
        public List<Car> GetByAllFilters(CarBrand brand, CarSegment segment, GearType gearType, MotorType motorType)
        {
            return cars.Where(x => x.Brand == brand && x.Segment == segment && x.GearTransmission == gearType && x.Motor == motorType).ToList();
        }
        public void Create(Car nextCar)
        {
            nextCar.Id = SetId();
            cars.Add(nextCar);
        }
        public void Delete(Car nextCar)
        {
            cars.Remove(nextCar);
        }
        public void RemoveCar(int id)
        {
            for (int i = 0; i < GetAll().Count; i++)
            {
                if (id == GetAll()[i].Id)
                {
                    GetAll().Remove(GetAll()[i]);
                }
            }
        }
    };
}
