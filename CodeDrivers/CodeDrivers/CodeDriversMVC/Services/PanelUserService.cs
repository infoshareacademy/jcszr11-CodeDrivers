using CodeDrivers.Models;
using CodeDriversMVC.Models;

namespace CodeDriversMVC.Services
{
    public class PanelUserService
    {

        public static int id = 1;
        public static List<User> Users = new List<User>()
        {
            new User
            {
                Id = 1,
                Name="Jan",
                LastName="Nowak",
                DateOfBirth= DateTime.Now,
                Email="j.nowak@wp.pl",
                Password="Password",
                PhoneNumber="+48147258369",
                DriversLicenceNumber="asd12345",
            }
        };
        public List<User> GetUsers()
        {
            return Users;
        }
        public int GetNextId()
        {
            id++;
            return id;
        }
        public void Create(User newUser)
        {
            newUser.Id = GetNextId();
            Users.Add(newUser);
        }
        public User GetById(int id)
        {
            return Users.FirstOrDefault(p => p.Id == id);
        }
        public void Update(User allUsers)
        {
            var user = GetById(allUsers.Id);
            allUsers.Name = user.Name;
            allUsers.LastName = user.LastName;
            allUsers.DateOfBirth = user.DateOfBirth;
            allUsers.Email = user.Email;
            allUsers.Password= user.Password;
            allUsers.PhoneNumber= user.PhoneNumber;
            allUsers.DriversLicenceNumber = user.DriversLicenceNumber;
        
        }
        public void Delete(int id)
        {
            Users.Remove(GetById(id));
        }
    }
} 
