using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CodeDrivers.Models.Car
{
	public class Car
	{
		public int Id { get; set; }
		public CarBrand Brand { get; set; }
        public List<string> CarBrandNames => Enum.GetNames(typeof(CarBrand)).ToList();
        public List<string> Models => BrandToModelsDict.First(f => f.Key == Brand).Value;
		public string Model { get; set; }
		public CarSegment Segment { get; set; } 
		public MotorType Motor { get; set; } 
		public GearType GearTransmission { get; set; }
		public bool IsAvailable { get; set; }
		public decimal PricePerDay { get; set; }
        public string ImageFileName { get; set; }
		[NotMapped]
		public IFormFile ImageFile { get; set; }
		public static Dictionary<CarBrand, List<string>> BrandToModelsDict = new Dictionary<CarBrand, List<string>>();
		static Car()
		{
			BrandToModelsDict.TryAdd(CarBrand.Audi, new List<string> { "A3", "A4", "A5", "A6" });
			BrandToModelsDict.TryAdd(CarBrand.BMW, new List<string> { "1", "2", "3", "5", "X1", "X2", "X3", "X5" });
			BrandToModelsDict.TryAdd(CarBrand.Fiat, new List<string> { "500", "500X", "Panda" });
			BrandToModelsDict.TryAdd(CarBrand.Ford, new List<string> { "Fiesta", "Focus", "Mondeo" });
			BrandToModelsDict.TryAdd(CarBrand.Mercedes, new List<string> { "A-klasa", "C-klasa", "E-klasa" });
			BrandToModelsDict.TryAdd(CarBrand.Opel, new List<string> { "Adam", "Corsa", "Astra", "Mokka", "Insignia" });
			BrandToModelsDict.TryAdd(CarBrand.Seat, new List<string> { "Ibiza", "Arona", "Leon", "Ateca"});
			BrandToModelsDict.TryAdd(CarBrand.Toyota, new List<string> { "Aygo", "Yaris", "Corolla", "RAV4" });
			BrandToModelsDict.TryAdd(CarBrand.VW, new List<string> { "up!", "Polo", "Golf", "Passat", "Arteon" });
		}

        public Car(CarBrand brand, string model)
        {
            Brand = brand;
            if (BrandToModelsDict.TryGetValue(brand, out List<string> models))
            {
                if (models.Contains(model))
                {
                    Model = model;
                }
                else
                {
                }
            }
        }
        public Car()
        {
        }
		public static Dictionary<CarBrand, List<string>> GetDisctionary()
		{
			var dictionary = BrandToModelsDict;
			return dictionary;
		}
		
	}
}
