using CodeDrivers.Models;
using CodeDriversMVC.DataAccess;
using System.Security.Cryptography;
using System.Text;

namespace CodeDriversMVC.Services
{
    public class LoginService
    {
        private readonly CodeDriversContext _context;

        public LoginService(CodeDriversContext context)
        {
            _context = context;
        }

        public bool AuthorizeUser(string email, string enteredPassword)
        {
            var searchedUser = _context.Set<User>().FirstOrDefault(user => user.Email == email);
            if (searchedUser == null || !VerifyPassword(enteredPassword, searchedUser.Password))
            {
                return false;
            }
            return true;
        }

        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            var enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);
            var enteredPasswordHash = SHA256.HashData(enteredPasswordBytes);
            var enteredPasswordHashString = Convert.ToHexString(enteredPasswordHash);

            return string.Equals(enteredPasswordHashString, storedHashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
