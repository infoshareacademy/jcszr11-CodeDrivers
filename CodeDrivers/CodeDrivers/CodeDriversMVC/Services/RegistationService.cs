using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace CodeDriversMVC.Services
{
    public class RegistationService
    {
        private static List<User> users = new List<User>();

        public void SaveUserInJson(User user, string path)
        {
            user.Id = Guid.NewGuid().ToString().Substring(0, 6);
            user.Password = HashPassword(user.Password);

            string json = JsonConvert.SerializeObject(user);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(json);
            }
        }

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
        string HashPassword(string password)
        {
            var inputBytes = Encoding.UTF8.GetBytes(password);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }
    }
}
