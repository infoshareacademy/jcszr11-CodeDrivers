using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace CodeDriversMVC.Services
{
    public class RegistrationService  : IRegistrationService
    {

        private readonly CodeDriversContext _context;
        public RegistrationService(CodeDriversContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Set<User>().FirstOrDefault(u => u.Email == email);
        }
        public bool CheckIfEmailExits(string email)
        {
            return _context.Set<User>().FirstOrDefault(u => u.Email == email) != null;
        }

        public void Remove(string email)
        {
            User userToBeRemoved = GetByEmail(email);
            if (userToBeRemoved != null)
            {
                _context.Set<User>().Remove(userToBeRemoved);
                _context.SaveChanges();
            }
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(User user)
        {
            user.Id = Guid.NewGuid().ToString().Substring(0, 6);
            user.Password = HashPassword(user.Password);
            _context.Set<User>().Add(user);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
