using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Helpers;
using CodeDriversMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CodeDriversMVC.Services
{
    public class RegistrationService : IRegistrationService
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

        //public User GetById(int id)
        //{
        //    return _context.Set<User>().FirstOrDefault(user => user.Id == id);
        //}

        public List<User> GetAll()
        {
            return _context.Set<User>().ToList();
        }
        public void CreateByAdmin(User newUser)
        {
            newUser.Id = Guid.NewGuid().ToString().Substring(0, 6);
            if(newUser.Password == null)
            {
                newUser.Password = GenerateRandomPassword();
            }
            _context.Set<User>().Add(newUser);
            _context.SaveChanges();
        }
        private string GenerateRandomPassword()
        {
            var sb = new StringBuilder();
            return sb.ToString();
        }

        public void Create(User user)
        {
            user.Id = Guid.NewGuid().ToString().Substring(0, 6);
            user.Password = HashPasswordHelper.HashPassword(user.Password);
            _context.Set<User>().Add(user);
            _context.SaveChanges();
        }

        public void Update(User editedUser)
        {
            User userToBeEdited = GetByEmail(editedUser.Email);
            if (userToBeEdited != null)
            {
                userToBeEdited.Name = editedUser.Name;
                userToBeEdited.LastName = editedUser.LastName;
                userToBeEdited.DateOfBirth = editedUser.DateOfBirth;
                userToBeEdited.Email = editedUser.Email;
                userToBeEdited.PhoneNumber = editedUser.PhoneNumber;
                userToBeEdited.DriversLicenceNumber = editedUser.DriversLicenceNumber;
                //userToBeEdited.Password = HashPasswordHelper.HashPassword(editedUser.Password);
                _context.Set<User>().Update(userToBeEdited);
                _context.SaveChanges();
            }
        }


        public void RemoveUser(string email)
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

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
