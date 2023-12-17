using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CodeDrivers.Models.Car
{
	public class Car
	{
		public int Id { get; set; }
		public CarBrand Brand { get; set; } 
		public List<string> Models => BrandToModelsDict.First(f => f.Key == Brand).Value;
		public string Model { get; set; } //Model
		public CarSegment Segment { get; set; } //A,B,C,D,Crossover,SUV (najlepiej enum)
		public GearType GearTransmission { get; set; }
		public bool IsAvailable { get; set; }
		public decimal PricePerDay { get; set; }
		private static Dictionary<CarBrand, List<string>> BrandToModelsDict = new Dictionary<CarBrand, List<string>>();
		static Car()
		{
			BrandToModelsDict.TryAdd(CarBrand.Audi, new List<string> { "A3", "A4", "Arona" });
			BrandToModelsDict.TryAdd(CarBrand.BMW, new List<string> { "1", "2", "3", "4", "5", "X1", "X2", "X3", "X5" });
			BrandToModelsDict.TryAdd(CarBrand.Fiat, new List<string> { "500", "500X", "Panda" });
			BrandToModelsDict.TryAdd(CarBrand.Ford, new List<string> { "Fiesta", "Focus", "Mondeo" });
			BrandToModelsDict.TryAdd(CarBrand.Mercedes, new List<string> { "A-klasa", "C-klasa", "E-klasa" });
			BrandToModelsDict.TryAdd(CarBrand.Opel, new List<string> { "Adam", "Corsa", "Astra", "Mokka", "Insignia" });
			BrandToModelsDict.TryAdd(CarBrand.Seat, new List<string> { "Ibiza", "Arona", "Leon" });
			BrandToModelsDict.TryAdd(CarBrand.Toyota, new List<string> { "Aygo", "Yaris", "Corolla", "RAV4" });
			BrandToModelsDict.TryAdd(CarBrand.VW, new List<string> { "up!", "Polo", "Golf", "Passat" });
		}
		public Car(CarBrand brand, string model)
		{
			Brand = brand;
			if(BrandToModelsDict.TryGetValue(brand, out List<string> models))
			{
				if(models.Contains(model))
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
		public string DisplayAvailibility()
		{
			if (IsAvailable)
			{
				return "dostępny";
			}
			else
			{
				return "niedostępny";
			}
		}
		public Dictionary<CarBrand, List<string>> GetDisctionary()
		{
			var dictionary = BrandToModelsDict;
			return dictionary;
		}
		
	}
}












