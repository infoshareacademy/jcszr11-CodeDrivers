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
<<<<<<< HEAD
            optionsBuilder.UseSqlServer("Server = localhost; Database = CodeDrivers; Trusted_Connection = True; TrustServerCertificate=True;");
=======
            optionsBuilder.UseSqlServer("Data Source=95.111.245.132;Initial Catalog=CodeDrivers;User ID=sa;Password=StrongDevPass1!; TrustServerCertificate=True");
>>>>>>> 24a9e4c46ac3625a8eb6753856e7fbcb2011f397
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
