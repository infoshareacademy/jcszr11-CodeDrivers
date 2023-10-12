using CodeDrivers.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers.Repository
{
    internal interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllAvailable();
        void DisplayAllItems(IEnumerable<T> items);
        void DisplayAllAvailableItems(IEnumerable<T> items);

    }
    internal class CarListRepository : IRepository<Car>
    {
        //fake repo - do implementacji, dopóki nie będziemy zasysali z bazy
        private IEnumerable<Car> cars = new List<Car>
        {
            new Car { Id = 1, Type = "Osobowy", BrandName = Brand.Toyota.ToString(), Model = "Corolla", Segment = "C", IsAvailable = true},
            new Car { Id = 2, Type = "Osobowy", BrandName = Brand.VW.ToString(), Model = "Polo", Segment = "B", IsAvailable = false}
        };

        public IEnumerable<Car> GetAll()
        {
            return cars;
        }
        public IEnumerable<Car> GetAllAvailable()
        {
            var availableCars = cars.Where(item => item.IsAvailable == true).ToList();
            return availableCars;
        }

        public void DisplayAllItems(IEnumerable<Car> items)
        {
            Console.WriteLine("Wszystkie samochody z naszej ofery: ");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id.ToString()}. {item.Type}: {item.BrandName}, {item.Model}, {item.Segment}, {item.GearTransmission}, {item.IsAvailable}");
            }
        }
        public void DisplayAllAvailableItems(IEnumerable<Car> items)
        {
            Console.WriteLine("Samochody dostępne od ręki: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.Id.ToString(), item.Type, item.BrandName, item.Model, item.Segment, item.GearTransmission, item.IsAvailable);
            }
        }
    }
    //Lista dodanych samochodów będzie możliwa do wyświetlenia dla admina i usera.
    //Marka, model, kategoria (male, rodzinne, dostawcze), rodzaj paliwa, cena wynajmu/dzien, KM , skrzynia biegow,elektryczne/spalinowe

}
