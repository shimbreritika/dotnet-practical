using Assignment_5AUG.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment_5AUG.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
