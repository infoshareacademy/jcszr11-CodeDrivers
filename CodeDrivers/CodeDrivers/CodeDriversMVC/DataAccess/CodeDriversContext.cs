using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeDriversMVC.DataAccess
{
    public class CodeDriversContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=95.111.245.132;Initial Catalog=CodeDrivers;User ID=sa;Password=StrongDevPass1!; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
