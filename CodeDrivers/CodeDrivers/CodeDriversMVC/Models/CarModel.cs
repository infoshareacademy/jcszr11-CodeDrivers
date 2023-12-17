using CodeDrivers.Models.Car;
using CodeDrivers.Repository;
using Microsoft.Extensions.FileProviders.Physical;

namespace CodeDriversMVC.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public Car Car { get; set; }
    }
}
