using CodeDrivers.Models;
using CodeDrivers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    internal class UserHandler
    {
        static List<User> users { get; set; } = new List<User>();

        public void AddUser()
        {
            Console.Clear();
            Console.WriteLine("Aby dokonać rezerwacji wprowadź dane:");
            Console.WriteLine("=====================================");
            var name = GetAndValidateName();
            var lastName = GetAndValidateLastName();
            var dateOfBirth = GetAndValidateDateOfBirth();
            var email = GetAndValidateEmail();
            //var password = CredentialsValidator.ValidatePassword();
            var phoneNumber = GetAndValidatePhoneNumber();
            var drivingLicenceNumber = GetAndValidateDrivingLicence();

            Console.Clear();
            string id = Guid.NewGuid().ToString().Substring(0, 4);
            Console.WriteLine();
            Console.WriteLine($"Id użytkownika to {id} ");
            //User newUser = new User(name, lastName, DateTime.Parse(dateOfBirth), email,  phoneNumber, drivingLicenceNumber);
            //users.Add(newUser);
            Console.WriteLine("*****Użytkownik został dodany do listy*****");
            DisplayUser(users);
            Console.WriteLine();

            return;
        }

        public void DisplayUser(List<User> users)
        {
            Console.WriteLine("Twoje dane zostały wprowadzone:");
            Console.WriteLine();
            Console.WriteLine(" # ID  |  Imię  |  Nazwisko  |  Data urodzenia  |  Email  |  Nr telefonu  |  Nr prawa jazdy |");
            Console.WriteLine("=============================================================================================");
            foreach (var user in users)
            {
                Console.WriteLine($" # {user.Id}  |  {user.Name}  |  {user.LastName}  |  {user.DateOfBirth:dd-MM-yyyy}  |  {user.Email}  |  {user.PhoneNumber}  |  {user.DrivingLicenceNumber}  | ");
            }
        }
        public List<User> GetUser()
        {
            return users;
        }

        public string GetAndValidateName()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Podaj imię:");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
                Console.WriteLine("Imię nie może być puste. Wprowadź ponownie:");
            }
        }
        public string GetAndValidateLastName()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Podaj nazwisko:");
                string lastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(lastName))
                {
                    return lastName;
                }
                Console.WriteLine("Nazwisko nie może być puste. Wprowadź ponownie:");
            }
        }
        public string GetAndValidateDateOfBirth()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Podaj datę urodzenia dd.mm.yyyy:");
                string dateOfBirth = Console.ReadLine();
                if (string.IsNullOrEmpty(dateOfBirth))
                {
                    Console.WriteLine("Data urodzenia nie może być pusta. Wprowadź jeszcze raz:");
                    continue;
                }
                if (DateTime.TryParseExact(dateOfBirth, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    int age = DateTime.Today.Year - date.Year;
                    if (age <= 17)
                    {
                        Console.WriteLine("Wprowadź poprawnie datę urodzenia. Musisz być pełnoletni.");
                        continue;
                    }
                }
                return dateOfBirth;
            }
        }
        public string GetAndValidateEmail()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Podaj adres e-mail:");
                string email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email) || !(email.Contains("@")))
                {
                    return email;
                }
                Console.WriteLine("E-mail nie może być puste. Wprowadź ponownie:");
            }
        }

        public string GetAndValidatePhoneNumber()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Podaj nr telefonu:");
                string phoneNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(phoneNumber) || (Convert.ToInt32(phoneNumber.Length) <= 8 || Convert.ToInt32(phoneNumber.Length) > 9))
                {
                    Console.WriteLine("Nr nie może być pusty. Jeszcze raz:");
                    continue;
                }
                return phoneNumber;
            }
        }

        public string GetAndValidateDrivingLicence()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Podaj numer prawa jazdy:");
                string drivingLicenceNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(drivingLicenceNumber))
                {
                    return drivingLicenceNumber;
                }
                Console.WriteLine("Numer prawa jazdy nie może być pusty. Wprowadź ponownie:");
            }
        }
        public void DisplayAllUsers(List<User> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("Brak użytkowników");
            }
            else
            {
                Console.WriteLine("Wszyscy użytkownicy:");
                Console.WriteLine();
                Console.WriteLine(" # ID  |  Imię  |  Nazwisko  |  Data urodzenia  |  Email  |  Nr telefonu  |  Nr prawa jazdy |");
                Console.WriteLine("=============================================================================================");
                foreach (var user in users)
                {
                    Console.WriteLine($" # {user.Id}  |  {user.Name}  |  {user.LastName}  |  {user.DateOfBirth:dd-MM-yyyy}  |  {user.Email}  |  {user.PhoneNumber}  |  {user.DrivingLicenceNumber}  | ");
                }
            }
        }
    }

}

