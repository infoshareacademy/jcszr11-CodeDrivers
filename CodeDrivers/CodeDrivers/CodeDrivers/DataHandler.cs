using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeDrivers
{
    
    public static class DataHandler
	{
        static string format = "dd/MM/yyyy HH:mm";
        static CultureInfo provider = CultureInfo.InvariantCulture;

        public static DateTime? GetDate(string inputMessage) {

            bool validData = false;
            DateTime? result = null; 

            while (!validData)
            {
                try
                {
                    Console.WriteLine(inputMessage + " Akceptowalny format daty: " + format);
                    string dataFromConsole = Console.ReadLine();
                    result = DateTime.ParseExact(dataFromConsole, format, provider);
                    validData = true; 
                }
                catch (FormatException)
                {
                    Console.WriteLine("Data powinna byc w formacie " + format); 
                }
            }

            return result; 

        }

        public static int GetId()
        {
            int result = 0;
            bool validData = false;

            Console.WriteLine("Podaj id jako liczbe calkowita");

            while (!validData) { 
                try
                {
                    result = int.Parse(Console.ReadLine());
                    validData = true; 
                }
                catch (Exception ex) {
                    Console.WriteLine("Podaj poprawne dane !!");
                }
            }

            return result;
        }
	}
}

