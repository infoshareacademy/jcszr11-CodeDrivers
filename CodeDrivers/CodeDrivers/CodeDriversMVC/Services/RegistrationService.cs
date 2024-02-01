using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace CodeDriversMVC.Services
{
    public class RegistrationService
    {
        //private static List<User> users = new List<User>();

        //public void SaveInJson(User user, string path)
        //{
        //    user.Id = Guid.NewGuid().ToString().Substring(0, 6);
        //    user.Password = HashPassword(user.Password);

        //    string json = JsonConvert.SerializeObject(user);

        //    using (StreamWriter sw = File.AppendText(path))
        //    {
        //        sw.WriteLine(json);
        //    }
        //}

        //public List<string> GetRawDataFromFile(string path)
        //{
        //    var fileContent = new List<string>();
        //    try
        //    {
        //        var lines = File.ReadAllLines(path);
        //        fileContent.AddRange(lines);

        //        return fileContent;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Wystąpił błąd podczas odczytu pliku CSV: " + ex.Message);
        //        return null;
        //    }
        //}

        //public bool AuthorizeUser(string login, string password, List<string> credentials)
        //{
        //    foreach (string line in credentials)
        //    {
        //        var values = line.Split(',');

        //        if (values.Length == 2 && values[0].Trim() == login && values[1].Trim() == password)
        //        {
        //            Console.WriteLine("Autoryzacja przebiegła pomyślnie.");
        //            return true;
        //        }
        //    }
        //    Console.WriteLine("Nieprawidłowy login lub hasło.");
        //    return false;
        //}

        //public void AddNewCredentials(string login, string password, string path)
        //{
        //    try
        //    {
        //        using (StreamWriter sw = File.AppendText(path))
        //        {
        //            sw.WriteLine($"{login},{password}");
        //        }

        //        Console.WriteLine("Nowe dane uwierzytelniające zostały dodane do pliku.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Wystąpił błąd podczas dodawania nowych danych uwierzytelniających: " + ex.Message);
        //    }
        //}


        string HashPassword(string password)
        {
            var inputBytes = Encoding.UTF8.GetBytes(password);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }

        // Testujemy strzelanie do bazy danych

        private readonly CodeDriversContext _context;
        public RegistrationService(CodeDriversContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
           // user.Id = Guid.NewGuid().ToString().Substring(0, 6);
            user.Id = Guid.NewGuid().GetHashCode();
            user.Password = HashPassword(user.Password);
            _context.Set<User>().Add(user);
            _context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _context.Set<User>().FirstOrDefault(u => u.Email == email);
        }
        public bool CheckIfEmailExits(string email)
        {
            return _context.Set<User>().FirstOrDefault(u => u.Email == email) != null;
        }

        public void Remove(string email)
        {
            User userToBeRemoved = GetByEmail(email);
            if (userToBeRemoved != null)
            {
                _context.Set<User>().Remove(userToBeRemoved);
                _context.SaveChanges();
            }
        }

        public User GetById(int id)  
        {
            
            return _context.Set<User>().FirstOrDefault(user => user.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Set<User>().ToList();
            
        }
          
        public void Create(User user)
        {
            user.Id = Guid.NewGuid().ToString().Substring(0, 6);
            user.Password = HashPasswordHelper.HashPassword(user.Password);
            _context.Set<User>().Add(user);
            _context.SaveChanges();
        }

        public void Update(User editedUser)
        {
            User userToBeEdited = GetById(editedUser.Id);
            userToBeEdited.Name = editedUser.Name;
            userToBeEdited.LastName = editedUser.LastName;
            userToBeEdited.DateOfBirth = editedUser.DateOfBirth;
            userToBeEdited.Email = editedUser.Email;
            userToBeEdited.PhoneNumber = editedUser.PhoneNumber;
            userToBeEdited.DriversLicenceNumber = editedUser.DriversLicenceNumber;
            _context.Set<User>().Update(userToBeEdited);
            _context.SaveChanges();
            
        }

        public void Remove(int id)
        {
            User userToBeRemoved = GetById(id);
            _context.Set<User>().Remove(userToBeRemoved);
            _context.SaveChanges();
        }
    }
}
