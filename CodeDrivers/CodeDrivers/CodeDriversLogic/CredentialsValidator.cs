using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    internal class CredentialsValidator
    {
        public static string ValidatePassword()
        {
            string password;
            string passwordConfirmation;

            do
            {
                Console.Write("Wprowadź hasło. Pamiętaj, że hasło musi składać się z co najmniej 8 znaków, musi zawierać przynajmniej jedną cyfrę oraz wielką literę: ");
                password = Console.ReadLine();

                while (!(password.Length >= 8 && password.Any(char.IsDigit) && password.Any(char.IsUpper)))
                {
                    Console.Write("Hasło nie spełnia wymaganych kryteriów. Wpisz je ponownie: ");
                    password = Console.ReadLine();
                };

                Console.Write("Powtórz hasło: ");
                passwordConfirmation = Console.ReadLine();

                if (passwordConfirmation == password)
                {
                    Console.WriteLine("Hasło zostało poprawnie utworzone.");
                }
                else
                {
                    Console.WriteLine("Hasła nie są zgodne.");
                }

                Console.WriteLine();

            } while (password != passwordConfirmation);

            return password;
        }
    }
}
