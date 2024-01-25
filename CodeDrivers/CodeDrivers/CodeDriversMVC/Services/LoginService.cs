using CodeDrivers.Models;
using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Helpers;
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
            if (searchedUser == null || !HashPasswordHelper.VerifyPassword(enteredPassword, searchedUser.Password))
            {
                return false;
            }
            return true;
        }
    }
}
