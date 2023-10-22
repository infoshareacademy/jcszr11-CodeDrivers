using CodeDrivers.Repository;

namespace CodeDrivers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu_tekstowe menu = new Menu_tekstowe("user"); //Na start wyswietla panel menu

            var carRepo = new CarListRepository();
            //var allCars = carRepo.GetAll();
            //var availableCars = carRepo.GetAllAvailable();
            //carRepo.DisplayAllItems(availableCars);
        }
    }
}