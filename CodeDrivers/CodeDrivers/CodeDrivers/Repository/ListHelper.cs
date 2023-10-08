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
        IEnumerable<T> GetAll(IEnumerable<T> items);
        IEnumerable<T> GetAllAvailable(IEnumerable<T> items);
        void DisplayAllItems(IEnumerable<T> items);
        void DisplayAllAvailableItems(IEnumerable<T> items);

    }
    internal class ListHelper : IRepository<Car>
    {
        public IEnumerable<Car> GetAll(IEnumerable<Car> items)
        {
            return items; // Wiem, że na razie przepisuję jedną listę w drugą.
        }

        public List<Car> GetAllAvailable(IEnumerable<Car> items)
        {
            var availableCars = items.Where(item => item.IsAvailable == true).ToList();
            return availableCars;
        }
        public void DisplayAllItems(IEnumerable<Car> items)
        {
            Console.WriteLine("Wszystkie samochody z naszej ofery: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.Id.ToString(), item.Type, item.BrandName, item.Model, item.Segment, item.GearTransmission, item.IsAvailable);
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
