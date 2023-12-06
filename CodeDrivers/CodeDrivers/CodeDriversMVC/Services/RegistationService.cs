using CodeDrivers.Models;

namespace CodeDriversMVC.Services
{
    public class RegistationService
    {
        private static List<User> users = new List<User>();

        public void AddNewUser(User user)
        {
            users.Add(user);
        }
    }
}
