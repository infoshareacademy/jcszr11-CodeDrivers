using System;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeDrivers
{
    
    public static class DataHandler
	{
        private static string format = "dd/MM/yyyy HH:mm";
        private static CultureInfo provider = CultureInfo.InvariantCulture;

        public static DateTime? GetDate(string inputMessage) {

            var isDateTimeValid = false;
            DateTime? result = null; 

            while (!isDateTimeValid)
            {
                try
                {
                    Console.WriteLine(inputMessage + " Akceptowalny format daty: " + format);
                    string dataFromConsole = Console.ReadLine();
                    DateTime parsedData; 
                    isDateTimeValid = DateTime.TryParseExact(dataFromConsole, format, provider, DateTimeStyles.AssumeLocal, out  parsedData);
                    result = parsedData;
                    if (!isDateTimeValid)
                    {
                        Console.WriteLine("Niepoprawny format daty !! Powtorz wpisywanie");
                    }
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
                    validData = int.TryParse(Console.ReadLine(), out result);
                }
                catch (Exception ex) {
                    Console.WriteLine("Podaj poprawne dane !!");
                }
            }

            return result;
        }
	}
}

