namespace CodeDriversMVC.Helpers
{
    public class JsonReaderHelper
    {
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
