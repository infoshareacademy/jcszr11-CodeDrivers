using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    internal class CsvHanlder
    {
        private string filePath = @"C:\Users\Janek\Desktop\FakeCrudentials.csv";
        public List<string> GetCredentialsFromFile(string path)
        {
            var credentials = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                credentials.AddRange(lines);

                return credentials;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas odczytu pliku CSV: " + ex.Message);
                return null;
            }

        }

        public bool SelectRequestedValues(string login, string password, List<string> credentials)
        {
            foreach (string line in credentials)
            {
                string[] values = line.Split(',');
                
                if (values.Length == 2 && values[0].Trim() == login && values[1].Trim() == password)
                {
                    Console.WriteLine("Autoryzacja przebiegła pomyślnie.");
                    return true;
                }
            }
            Console.WriteLine("Nieprawidłowy login lub hasło.");
            return false;
        }

        public void AddNewCredentials(string login, string password, string path)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"{login},{password}");
                }

                Console.WriteLine("Nowe dane uwierzytelniające zostały dodane do pliku.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas dodawania nowych danych uwierzytelniających: " + ex.Message);
            }
        }
    }
}
