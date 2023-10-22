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


        public Car(Brand brand, string model)
        {
            this.BrandId = brand;
			this.Model = model;
        }
        
        public int Id { get; set; } 
        public string Type { get; set; } //gazozo
        private Brand BrandId { get; set; } 
        public string BrandName { get; set; }  //marka
        public List<string> Models => BrandToModelsDict.First(f => f.Key == BrandId).Value;
        public string Model { get; set; } //model
        public string Segment { get; set; } //klasa 
        public string GearTransmission { get; set; } //skrzynia
        public bool IsAvailable { get; set; } 
        public decimal PricePerDay { get; set; }
        public int Traveled {  get; set; }
        private static Dictionary<Brand, List<string>> BrandToModelsDict = new Dictionary<Brand, List<string>>();
        public int YearOfProduction { get; set; }
    }
   
    // prywatny statyczny słownik
    // monotstate pattern
}
