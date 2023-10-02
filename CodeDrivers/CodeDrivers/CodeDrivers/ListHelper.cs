using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    internal interface IRepository<T>
    {
        List<T> GetAll();
        T GetAllAvailable(bool isAvaialable);
        void DisplayItems(IEnumerable<T> items);
       
    }
    internal class ListHelper : IRepository<Car>
    {
        public void DisplayItems(IEnumerable<Car> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.Id, item.BrandName, item.Model, item.IsAutomatic, item.IsAvaiable);
            }
        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public Car GetAllAvailable(bool isAvaialable)
        {
            throw new NotImplementedException();
        }
    }
    //Lista dodanych samochodów będzie możliwa do wyświetlenia dla admina i usera.
    //Marka, model, kategoria (male, rodzinne, dostawcze), rodzaj paliwa, cena wynajmu/dzien, KM , skrzynia biegow,elektryczne/spalinowe

}
