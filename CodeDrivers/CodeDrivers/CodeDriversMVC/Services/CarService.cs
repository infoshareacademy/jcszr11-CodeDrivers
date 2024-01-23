using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using CodeDrivers.Repository;
using CodeDriversMVC.Services.Interfaces;
using CodeDriversMVC.DataAccess;
using static System.Net.Mime.MediaTypeNames;

namespace CodeDriversMVC.Services
{
    public class CarService : IRepository<Car>
    {
        private readonly CodeDriversContext _context;
        public CarService(CodeDriversContext context)
        {
            _context = context;
        }
        public void Create(Car car)
        {
            _context.Set<Car>().Add(car);
            _context.SaveChanges();
        }
        public Car GetById(int id)
        {
            return _context.Set<Car>().FirstOrDefault(car => car.Id == id);
        }
        public List<Car> GetByBrand(CarBrand brand)
        {
            return _context.Set<Car>().Where(car => car.Brand == brand).ToList();
        }
        public List<Car> GetAll()
        {
            return _context.Set<Car>().ToList();
        }

        public void Update(Car updatedCar)
        {
            Car carToBeUpdated = GetById(updatedCar.Id);
            carToBeUpdated.Brand = updatedCar.Brand;
            carToBeUpdated.Model = updatedCar.Model;
            carToBeUpdated.Segment = updatedCar.Segment;
            carToBeUpdated.GearTransmission = updatedCar.GearTransmission;
            carToBeUpdated.PricePerDay = updatedCar.PricePerDay;
            carToBeUpdated.IsAvailable = updatedCar.IsAvailable;

            _context.Set<Car>().Update(carToBeUpdated);
            _context.SaveChanges();
        }
        public void Remove(int id)
        {
            Car carToBeRemoved = GetById(id);
            if (carToBeRemoved != null)
            {
                _context.Set<Car>().Remove(carToBeRemoved);
                _context.SaveChanges();
            }
        }

        public string UploadImage(IFormFile imageFile)
        {
            
            string uniqueFileName = Guid.NewGuid().ToString().Substring(0,4) + "_" + imageFile.FileName;

            string uploadsFolder = "/Images/";

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        //static int id = 7;
        //public static List<Car> cars { get; set; } = new List<Car>
        //    {
        //        new() {Id=1, Brand = CarBrand.Toyota, Model = "Yaris", Motor = MotorType.Hybrydowy, GearTransmission = GearType.Automatyczna, Segment = CarSegment.B, PricePerDay = 150},
        //        new() {Id=2, Brand = CarBrand.Fiat, Model = "500", Motor = MotorType.Benzynowy, GearTransmission = GearType.Manualna, Segment = CarSegment.A, PricePerDay = 130},
        //        new() {Id=3, Brand = CarBrand.Seat, Model = "Arona", Motor = MotorType.Benzynowy, GearTransmission = GearType.Manualna, Segment = CarSegment.Crossover, PricePerDay = 190},
        //        new() {Id=4, Brand = CarBrand.BMW, Model = "1", Motor = MotorType.Benzynowy, GearTransmission = GearType.Automatyczna, Segment = CarSegment.C, PricePerDay = 220},
        //        new() {Id=5, Brand = CarBrand.Audi, Model = "A4", Motor = MotorType.Diesel, GearTransmission = GearType.Automatyczna, Segment = CarSegment.D, PricePerDay = 300},
        //        new() {Id=6, Brand = CarBrand.Mercedes, Model = "E-klasa", Motor = MotorType.Diesel, GearTransmission = GearType.Automatyczna, Segment = CarSegment.E, PricePerDay = 450},
        //    };
        //public List<Car> GetAll()
        //{
        //    return cars;
        //}
        //public static int SetId()
        //{
        //    return id++;
        //}
        //public void Update(Car updatedCar)
        //{
        //    Car carToBeUpdated = GetById(updatedCar.Id);
        //    carToBeUpdated.Brand = updatedCar.Brand;
        //    carToBeUpdated.Model = updatedCar.Model;
        //    carToBeUpdated.Segment = updatedCar.Segment;
        //    carToBeUpdated.GearTransmission = updatedCar.GearTransmission;
        //    carToBeUpdated.PricePerDay = updatedCar.PricePerDay;
        //    carToBeUpdated.IsAvailable = true;
        //}
        //public Car GetById(int id)
        //{
        //    return cars.FirstOrDefault(m => m.Id == id);
        //}
        //public List<Car> GetByBrand(CarBrand brand)
        //{
        //    return cars.Where(m => m.Brand == brand).ToList();
        //}
        //public void Create(Car nextCar)
        //{
        //    nextCar.Id = SetId();
        //    cars.Add(nextCar);
        //}
        //public void Remove(int id)
        //{
        //    Car carToBeRemoved = GetById(id);
        //    if (carToBeRemoved != null)
        //    {
        //        cars.Remove(carToBeRemoved);
        //    }
        //}
        public bool ValidatePrice(decimal price)
        {
            if (price < 50)
            {
                return false;
            }
            return true;
        }
    }
}
