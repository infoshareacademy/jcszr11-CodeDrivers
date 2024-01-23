using System.Security.Cryptography;
using System.Text;

namespace CodeDriversMVC.Helpers
{
    public static class Helpers
    {
       public static string HashPassword(string password)
        {
            var inputBytes = Encoding.UTF8.GetBytes(password);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }

        public static List<string> GetRawDataFromFile(string path)
        {
            var fileContent = new List<string>();
            try
            {
                var lines = File.ReadAllLines(path);
                fileContent.AddRange(lines);

                return fileContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas odczytu pliku CSV: " + ex.Message);
                return null;
            }
        }
    }
}
