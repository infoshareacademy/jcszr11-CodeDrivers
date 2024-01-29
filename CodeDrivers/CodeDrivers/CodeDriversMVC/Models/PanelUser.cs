using CodeDrivers.Models;
using Microsoft.AspNetCore.Mvc;
namespace CodeDriversMVC.Models
{
    public class PanelUser
    {
        //public List<User> Users { get; private set; }
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string DriversLicenceNumber { get; set; }
        List<User> Users { get; set; } = new List<User>();
    }
}
