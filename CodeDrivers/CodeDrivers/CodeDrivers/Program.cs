using CodeDrivers.Repository;
using System.Security.Claims;

namespace CodeDrivers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var csvHandler = new CsvHandler();
            //var cars = csvHandler.ReadCars("csv\\fakeCars.csv");

            //cars.ForEach(car => Console.WriteLine($"{car.Brand}, {car.Model}, {car.Segment}"));
            Menu_tekstowe menu = new Menu_tekstowe("user"); //Na start wyswietla panel menu
        }
    }
}