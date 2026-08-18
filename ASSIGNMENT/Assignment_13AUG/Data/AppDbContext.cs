using Assignment_13AUG.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment_13AUG.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users12 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Decimal precision
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            // Default Admin
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = "123456",
                    Role = "Admin"
                }
            );
        }
    }
}
