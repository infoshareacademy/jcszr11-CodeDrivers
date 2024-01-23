using CodeDrivers.Models;
using CodeDriversMVC.Services.Interfaces;
using Newtonsoft.Json;
using System.IO;
using CodeDriversMVC.Helpers;

namespace CodeDriversMVC.Services
{
    public class JsonRegistrationService : IRegistrationService
    {
        private static List<User> users = new List<User>();
        private readonly string path;

        public JsonRegistrationService(string path)
        {
            this.path = path;
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

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void Remove(string email)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfEmailExits(string email)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(User user)
        {
            user.Id = Guid.NewGuid().ToString().Substring(0, 6);
            user.Password = Helpers.Helpers.HashPassword(user.Password);

            string json = JsonConvert.SerializeObject(user);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(json);
            }
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
