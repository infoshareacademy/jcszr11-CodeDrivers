using CodeDrivers.Repository;
using System.Security.Claims;

namespace CodeDrivers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu_tekstowe menu = new Menu_tekstowe("user"); //Na start wyswietla panel menu

            //var carRepo = new CarRepository();
            //var allCars = carRepo.GetAll();
            //var availableCars = carRepo.GetAllAvailable();
            //carRepo.DisplayAllItems(availableCars);

            //var csvHandler = new CsvHanlder();
            //var credentials = csvHandler.GetCredentialsFromFile(@"C:\Users\Janek\Desktop\FakeCrudentials.csv");
            //csvHandler.SelectRequestedValues("anna.kowalska@gmail.com", "aneczka111", credentials);
            //csvHandler.AddNewCredentials("jankowalski@gmail.com", "janek1234!", @"C:\Users\Janek\Desktop\FakeCrudentials.csv\");

            CredentialsValidator validator = new CredentialsValidator();
            CredentialsValidator.ValidatePassword();
        }
    }
}