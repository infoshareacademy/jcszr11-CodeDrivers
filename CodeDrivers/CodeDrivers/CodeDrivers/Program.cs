using CodeDrivers.Repository;
using System.Security.Claims;

namespace CodeDrivers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu_tekstowe menu = new Menu_tekstowe("user"); //Na start wyswietla panel menu

            var carRepo = new CarRepository();
            var allCars = carRepo.GetAll();
            var availableCars = carRepo.GetAllAvailable();
            carRepo.DisplayItems(availableCars);

            //var csvHandler = new CsvHandler();
            //var credentials = csvHandler.GetCredentialsFromFile(@"csv\fakeCredentials.csv");
            //csvHandler.AuthorizeUser("anna.kowalska@gmail.com", "aneczka111", credentials);
            //csvHandler.AddNewCredentials("jankowalski@gmail.com", "janek1234!", @"csv\fakeCredentials.csv");

            //CredentialsValidator validator = new CredentialsValidator();
            //CredentialsValidator.ValidatePassword();
        }
    }
}