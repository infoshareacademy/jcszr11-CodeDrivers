using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers.Models
{
    internal class User
    {
        private string dateOfBirth;

        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string DrivingLicenceNumber { get; set; }
        List<User> Users { get; set; } = new List<User>();
        public User(string id, string name, string lastName, string dateOfBirth, string email, string password, string phoneNumber, string drivingLicenceNumber)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            DrivingLicenceNumber = drivingLicenceNumber;
        }
        public void AddUser()
        {
            while (true)
            {
                Console.WriteLine("Podaj imię:");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Imię nie może być puste. Wprowadź ponownie:");
                    continue;
                }
                while (true)
                {
                    Console.WriteLine("Podaj nazwisko:");
                    string lastName = Console.ReadLine();
                    if (string.IsNullOrEmpty(lastName))
                    {
                        Console.WriteLine("Nazwisko nie może być puste. Wprowadź ponownie:");
                        continue;
                    }
                    while (true)
                    {
                        Console.WriteLine("Podaj datę uroodznia dd.mm.yyyy:");
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
                                Console.WriteLine("User nie ma 18 lat, nie posiada prawa jazdy.");
                                return;
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("Podaj adres email:");
                            string email = Console.ReadLine();
                            if (string.IsNullOrEmpty(email))
                            {
                                Console.WriteLine("Mail nie może być pusty. Jeszcze raz:");
                                continue;
                            }
                            while (true)
                            {
                                Console.WriteLine("Wprowadź hasło:");
                                string password = Console.ReadLine();
                                if (string.IsNullOrEmpty(password))
                                {
                                    Console.WriteLine("Error. Hasło nie może być puste. Jeszcze raz:");
                                    continue;
                                }
                                while (true)
                                {
                                    Console.WriteLine("Podaj nr telefonu:");
                                    string phoneNumber = Console.ReadLine();
                                    if (string.IsNullOrEmpty(phoneNumber))
                                    {
                                        Console.WriteLine("Nr nie może być pusty. Jeszcze raz:");
                                        continue;
                                    }
                                    if (Convert.ToInt32(phoneNumber.Length) <= 8 || Convert.ToInt32(phoneNumber.Length) > 9)
                                    {
                                        Console.WriteLine("Nieprawidłowy numer. Wpisz 9 cyfrowy nr telefonu:");
                                        continue;
                                    }
                                    while (true)
                                    {
                                        Console.WriteLine("Podaj nr prawa jazdy:");
                                        string drivingLicenceNumber = Console.ReadLine();
                                        if (string.IsNullOrEmpty(drivingLicenceNumber))
                                        {
                                            Console.WriteLine("Numer nie może być pusty.");
                                            continue;
                                        }
                                        string id = Guid.NewGuid().ToString().Substring(0, 4);
                                        Console.WriteLine($"Id użytkownika to {id} ");
                                        List<User> Users = new List<User>();
                                        User newUser = new User(id, name, lastName, dateOfBirth, email, password, phoneNumber, drivingLicenceNumber);
                                        List<User> users = new List<User>();
                                        users.Add(newUser);
                                        Console.WriteLine("Użytkownik został dodany do listy.");
                                        DisplayUser(users);
                                        Console.WriteLine("Jeśli chcesz zakończyć wciśnij X lub enter aby wprowadzić kolejnego użytkownika:");
                                        string close = Console.ReadLine();
                                        if (close.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            return;
                                        }
                                        break;
                                    }
                                    break;
                                }
                                break;
                            }
                            break;
                        }
                        break;
                    }
                    break;
                }
                continue;
            }
        }

        static void DisplayUser(List<User> users)
        {
            Console.WriteLine("Lista użytkowników:");
            Console.WriteLine(" # ID  |  Imię  |  Nazwisko  |  Data urodzenia  |  Email  |  Nr telefonu  |  Nr prawa jazdy  ");
            Console.WriteLine("=============================================================================================");
            foreach (var user in users)
            {
                Console.WriteLine($" # {user.Id}  |  {user.Name}  |  {user.LastName}  |  {user.DateOfBirth:dd-MM-yyyy}  |  {user.Email}  |  {user.PhoneNumber}  |  {user.DrivingLicenceNumber}");
            }

        }
    }

}

