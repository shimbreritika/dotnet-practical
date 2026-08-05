using Assignment18.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment18.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

    }
}
