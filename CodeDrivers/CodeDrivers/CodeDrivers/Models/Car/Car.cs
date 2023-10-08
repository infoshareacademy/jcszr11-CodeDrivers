using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers.Models.Car
{
    internal class Car
    {
        static Car()
        {
            BrandToModelsDict.TryAdd(Brand.Audi, new List<string> { "A1", "Arona", "Leon" });
            BrandToModelsDict.TryAdd(Brand.BMW, new List<string> { "1", "2", "3", "4", "5", "X1", "X2", "X3", "X5" });
            BrandToModelsDict.TryAdd(Brand.Fiat, new List<string> { "500", "500X", "Panda" });
            BrandToModelsDict.TryAdd(Brand.Ford, new List<string> { "Fiesta", "Focus", "Mondeo" });
            BrandToModelsDict.TryAdd(Brand.Mercedes, new List<string> { "A-klasa", "C-klasa", "E-klasa" });
            BrandToModelsDict.TryAdd(Brand.Opel, new List<string> { "Adam", "Corsa", "Astra", "Mokka", "Insignia" });
            BrandToModelsDict.TryAdd(Brand.Seat, new List<string> { "Ibiza", "Arona", "Leon" });
            BrandToModelsDict.TryAdd(Brand.Toyota, new List<string> { "Aygo", "Yaris", "Corolla", "RAV4" });
            BrandToModelsDict.TryAdd(Brand.VW, new List<string> { "up!", "Polo", "Golf", "Passat" });
        }
        public Car(Brand brand)
        {
            this.BrandId = brand;
        }
        public int Id { get; private set; }
        public string Type { get; set; }
        private Brand BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string Segment { get; set; }
        public string GearTransmission { get; set; }
        public bool IsAvailable { get; set; }

        private static Dictionary<Brand, List<string>> BrandToModelsDict = new Dictionary<Brand, List<string>>();
    }

    // prywatny statyczny słownik
    // monotstate pattern
}
