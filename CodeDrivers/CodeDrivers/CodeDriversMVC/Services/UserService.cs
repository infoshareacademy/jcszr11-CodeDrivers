//using CodeDrivers.Models;
//using CodeDrivers.Models.Car;
//using CodeDriversMVC.DataAccess;
//using CodeDriversMVC.Services;
//using CodeDriversMVC.Services.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace CodeDriversMVC.Services
//{
//    public class UserService
//    {
//        private readonly CodeDriversContext _context;
//        private static int count;
//        List<User> Users { get; set; } = new List<User>();
//        public UserService(CodeDriversContext context)
//        {
//            _context = context;
//        }
//        public void Create(User users)
//        {
//            users.Id = GetNextId();
//            //users.Id=Guid.NewGuid().ToString();
//            _context.Set<User>().Add(users);
//            _context.SaveChanges();
            
//        }
//        public User GetById(int id)
//        {
//            return _context.Set<User>().FirstOrDefault(users => users.Id == id);
//        }
//        public int GetNextId()
//        {
//            count++;
//            return count;
//        }
//        public List<User> GetAllUsers()
//        {
//            return _context.Set<User>().ToList();
//        }
//        public void Update(User editedUser)
//        {
//            User userToBeEdited = GetById(editedUser.Id);
//            userToBeEdited.Name = editedUser.Name;
//            userToBeEdited.LastName = editedUser.LastName;
//            userToBeEdited.DateOfBirth = editedUser.DateOfBirth;
//            userToBeEdited.Email = editedUser.Email;
//            userToBeEdited.PhoneNumber = editedUser.PhoneNumber;
//            userToBeEdited.DriversLicenceNumber = editedUser.DriversLicenceNumber;
//            _context.Set<User>().Update(userToBeEdited);
//            _context.SaveChanges();
//        }

//        public void Remove(int id)
//        {
//            User userToBeRemoved = GetById(id);
//            _context.Set<User>().Remove(userToBeRemoved);
//            _context.SaveChanges();
//        }
//    }
//}
