using CodeDrivers.Models;
using static CodeDrivers.Models.Car;

namespace CodeDrivers
{
    internal class Program
    {
        static void Main(string[] args)
        {
         //   Menu_tekstowe menu = new Menu_tekstowe("admin"); //Na start wyswietla panel menu

            Car toyota = new Toyota();
            PrintListToConsole(toyota.Models, "Toyota");

            Car audi = new Car(Brand.Audi);
            PrintListToConsole(audi.Models, "Audi");

            Car mazda = new Car(Brand.Mazda);
            PrintListToConsole(mazda.Models, "Mazda");
        }

        static void PrintListToConsole(List<string> toOutput, string label )
        {
            Console.WriteLine(label);
            toOutput.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
        }
    }
}