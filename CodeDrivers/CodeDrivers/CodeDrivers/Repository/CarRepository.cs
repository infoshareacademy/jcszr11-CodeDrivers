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
        List<T> GetAll();
		List<T> GetAllAvailable();
        void DisplayItems(List<Car> cars);

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

            if (car.Models.Contains(model) && car.Brand == brand && (Enum.IsDefined(typeof(CarSegment), segment)) && (Enum.IsDefined(typeof(GearType), transmission)))
            {
				car.Id = SetId();
				car.Brand = brand;
				car.Segment = segment; //klasa
				car.GearTransmission = transmission; //skrzynia
				car.PricePerDay = price; //cena
				car.Model = model;
				car.IsAvailable = true; cars.Add(car);
            }
            else
            {
                Console.WriteLine("Wprowadzono nie poprawne dane.");
            }
        }
        public void RemoveCar(int id)
        {
            for (int i = 0; i < GetAll().Count; i++)
            {
                if(id == GetAll()[i].Id)
                {
                    GetAll().Remove(GetAll()[i]);
                }
            }
        }
        public List<Car> GetAll()
        {
            return cars;
        }
        public List<Car> GetAllAvailable()
        {
            var availableCars = cars.Where(item => item.IsAvailable == true).ToList();
            return availableCars;
        }

        public void DisplayItems(List<Car> cars)
        {
            
            Console.WriteLine("* Wszystkie dostępne samochody z naszej ofery: ");
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Id.ToString()}. {item.Brand.ToString()}, {item.Model}, {item.Segment}, {item.GearTransmission}, {item.PricePerDay}, | {item.DisplayAvailibility()}");
            }
        }
    }
    //Lista dodanych samochodów będzie możliwa do wyświetlenia dla admina i usera.
    //Marka, model, kategoria (male, rodzinne, dostawcze), rodzaj paliwa, cena wynajmu/dzien, KM , skrzynia biegow,elektryczne/spalinowe

}
