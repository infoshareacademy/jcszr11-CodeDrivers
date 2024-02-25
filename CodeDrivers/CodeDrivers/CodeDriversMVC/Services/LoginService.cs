using CodeDrivers.Models;
using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CodeDriversMVC.Services
{
    public class LoginService
    {
        private readonly CodeDriversContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(CodeDriversContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> AuthorizeUser(string email, string enteredPassword)
        {
            var searchedUser = _context.Set<User>().FirstOrDefault(user => user.Email == email);
            if (searchedUser == null || !HashPasswordHelper.VerifyPassword(enteredPassword, searchedUser.Password))
            {
                return false;
            }
            await _contextAccessor.HttpContext.SignInAsync(CreatePricipal(searchedUser));
            return true;
        }

        public ClaimsPrincipal CreatePricipal(User user)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, $"{user.Name} {user.LastName}"));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            claimsPrincipal.AddIdentity(identity);
            return claimsPrincipal;
        }
    }
}
