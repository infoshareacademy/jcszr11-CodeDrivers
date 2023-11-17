using CodeDrivers.Models.Car;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    internal class CsvHandler
    {
        private readonly string path;

        public CsvHandler(string path)
        {
            this.path = path;
        }

        // private string credentialsFilePath "csv\fakeCars.csv"= @"csv\fakeCredentials.csv";
        // private string carsFilePath = @;
        public List<string> GetRawDataFromFile(string path)
        {
            var fileContent = new List<string>();
            try
            {
                var lines = File.ReadAllLines(path);
                fileContent.AddRange(lines);

                return fileContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas odczytu pliku CSV: " + ex.Message);
                return null;
            }
        }

        public bool AuthorizeUser(string login, string password, List<string> credentials)
        {
            foreach (string line in credentials)
            {
                var values = line.Split(',');
                
                if (values.Length == 2 && values[0].Trim() == login && values[1].Trim() == password)
                {
                    Console.WriteLine("Autoryzacja przebiegła pomyślnie.");
                    return true;
                }
            }
            Console.WriteLine("Nieprawidłowy login lub hasło.");
            return false;
        }

        public void AddNewCredentials(string login, string password, string path)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{login},{password}");
                }

                Console.WriteLine("Nowe dane uwierzytelniające zostały dodane do pliku.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas dodawania nowych danych uwierzytelniających: " + ex.Message);
            }
        }

        public void AddNewCar(int id, CarBrand brand, string model, CarSegment segment, GearType transmission, decimal price, bool availability, string path)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine($"{id},{brand},{model},{segment},{transmission},{price},{availability}");
                }

                Console.WriteLine($"Samochód {brand} {model} został dodany do pliku.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas dodawania pojazdu: " + ex.Message);
            }
        }


        public List<Car> ReadCars()
        {
			
            var cars = new List<Car>();

            var lines = File.ReadAllLines(path);
			
			foreach (var line in lines)
			{
				var values = line.Split(',');

                var car = new Car
                {
                    Id = int.Parse(values[0]),
                    Brand = Enum.Parse<CarBrand>(values[1]),
                    Model = values[2],
                    Segment = Enum.Parse<CarSegment>(values[3]),
                    GearTransmission = Enum.Parse<GearType>(values[4]),
                    PricePerDay = decimal.Parse(values[5]),
                    IsAvailable = bool.Parse(values[6]),
                };

                cars.Add(car);
			}
			return cars;
		}

		//public void ReadCars(string path)
		//{
		//	var config = new CsvConfiguration(CultureInfo.InvariantCulture)
		//	{
		//		Delimiter = ",",
		//		HasHeaderRecord = false
		//	};

		//	try
		//	{
  //              using var fileStream = new FileStream(path, FileMode.Open);
  //              using var reader = new StreamReader(fileStream);
		//		  var text = reader.ReadToEnd();
		//		using var csv = new CsvReader(reader, config);
  //              var cars = csv.GetRecords<Car>().ToList();

		//	}
		//	catch (Exception ex)
		//	{
		//	}
		//}
	}
}
