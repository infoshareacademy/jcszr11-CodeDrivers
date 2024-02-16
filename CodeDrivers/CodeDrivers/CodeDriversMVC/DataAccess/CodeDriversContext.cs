using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeDriversMVC.DataAccess
{
    public class CodeDriversContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-SJ0QVSV\\SQLEXPRESS; Database = CodeDrivers; Trusted_Connection = True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
