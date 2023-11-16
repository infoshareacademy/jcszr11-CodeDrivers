using CodeDrivers.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    internal class CsvHandler
    {
        // private string credentialsFilePath = @"csv\fakeCredentials.csv";
        // private string carsFilePath = @"csv\fakeCars.csv";
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
    }
}
