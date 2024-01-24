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
    }
}
