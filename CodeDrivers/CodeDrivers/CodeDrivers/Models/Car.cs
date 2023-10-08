using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers.Models
{
    //https://stackoverflow.com/questions/887317/monostate-vs-singleton
    // pattern describing using of private static variables in class
    internal class Car
    {
        public enum Brand
        {
            Toyota = 1,
            Mazda = 2,
            Audi = 3
        }
        private static Dictionary<Brand, List<string>> BrandToModelsDict= new Dictionary<Brand, List<string>>();

        static Car()
        {
           // BrandToModelsDict.Clear();
            BrandToModelsDict.TryAdd(Brand.Toyota, new List<string> { "Auris", "Camry", "Corolla" });
            BrandToModelsDict.TryAdd(Brand.Mazda, new List<string> { "CX3", "CX5" });
            BrandToModelsDict.TryAdd(Brand.Audi, new List<string> { "RS8", "S4", "A3" });

        }

        public Car(Brand brand)
        {
            this.BrandId = brand;
        }

        public Car()
        {
           
        }

        public int Id { get; set; }
        public string Type { get; set; }
        private Brand BrandId { get; set; }
        public string BrandName { get; set; }
        public List<string> Models => BrandToModelsDict.First(f => f.Key == BrandId).Value;
        public string Segment { get; set; }
        public string GearTransmission { get; set; }
        public bool IsAvailable { get; set; }


    }

    internal class Toyota : Car
    {
        public Toyota() : base(Brand.Toyota)
        {

        }
    }
   
}
