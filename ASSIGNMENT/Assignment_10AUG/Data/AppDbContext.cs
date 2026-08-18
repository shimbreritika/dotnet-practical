using Assignment_10AUG.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment_10AUG.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Automobile> Automobiles { get; set; }

        public DbSet<Customers> Customerss { get; set; }

        public DbSet<AutomobileService> AutomobileServices { get; set; }
    }
}
