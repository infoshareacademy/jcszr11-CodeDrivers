using CodeDrivers.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeDrivers.Repository
{

    internal interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllAvailable();
        void DisplayAllItems(List<Car> cars);

    }
    internal class CarRepository : IRepository<Car>
    {

        public static List<Car> cars { get; set; } = new List<Car>();
        static int id = 0;

		public static int SetId()
        {
            return id++;
        }
        public void FillRepository()
        {
            cars.Add(new Car(CarBrand.Audi,"A1") { Id = SetId(), Segment = CarSegment.A, IsAvailable = true, PricePerDay = 60, GearTransmission = GearType.Manual });
            cars.Add(new Car(CarBrand.Toyota,"Aygo") { Id = SetId(), Segment = CarSegment.A, IsAvailable = true, PricePerDay = 135, GearTransmission = GearType.Manual });
        }
        public void AddCar(CarBrand brand, string model, CarSegment segment, GearType transmission, decimal price)
        {
            Car car = new Car(brand,model);
            car.Id = SetId();
            car.Brand = brand;
            car.Segment = segment; //klasa
            car.GearTransmission = transmission; //skrzynia
            car.PricePerDay = price; //cena
            car.Model = model;
            cars.Add(car);
        }
        public IEnumerable<Car> GetAll()
        {
            return cars;
        }
        public IEnumerable<Car> GetAllAvailable()
        {
            var availableCars = cars.Where(item => item.IsAvailable == true).ToList();
            return availableCars;
        }

        public void DisplayAllItems(List<Car> cars)
        {
            
            Console.WriteLine("Wszystkie samochody z naszej ofery: ");
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Id.ToString()}. {item.Brand.ToString()}, {item.Model}, {item.Segment}, {item.GearTransmission}, {item.IsAvailable}");
            }
        }
    }
    //Lista dodanych samochodów będzie możliwa do wyświetlenia dla admina i usera.
    //Marka, model, kategoria (male, rodzinne, dostawcze), rodzaj paliwa, cena wynajmu/dzien, KM , skrzynia biegow,elektryczne/spalinowe

}
