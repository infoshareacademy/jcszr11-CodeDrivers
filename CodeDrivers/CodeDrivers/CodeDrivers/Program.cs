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
            //carRepo.DisplayItems(availableCars);

            CsvHandler handler = new CsvHandler();
            var cars = handler.GetRawDataFromFile(@"csv\fakeCars.csv");
            handler.AddNewCar(1, Models.Car.CarBrand.VW, "Polo", Models.Car.CarSegment.B, Models.Car.GearType.Automatic, 75, true, @"csv\fakeCars.csv");

            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }

        }
    }
}