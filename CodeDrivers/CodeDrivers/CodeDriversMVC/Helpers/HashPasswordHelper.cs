using System.Security.Cryptography;
using System.Text;

namespace CodeDriversMVC.Helpers
{
    public static class HashPasswordHelper
    {
       public static string HashPassword(string password)
        {
            var inputBytes = Encoding.UTF8.GetBytes(password);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            var enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);
            var enteredPasswordHash = SHA256.HashData(enteredPasswordBytes);
            var enteredPasswordHashString = Convert.ToHexString(enteredPasswordHash);

            return string.Equals(enteredPasswordHashString, storedHashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
