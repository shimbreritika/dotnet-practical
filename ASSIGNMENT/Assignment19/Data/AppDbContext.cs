using Assignment19.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment19.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {
        }

        public DbSet<Student> Students {  get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Batch> Batchs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            // Batch -> Students
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Batch)
                .WithMany(b => b.Students)
                .HasForeignKey(s => s.BatchId)
                .OnDelete(DeleteBehavior.Cascade);

            // Teacher -> Courses
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            // Student <-> Course
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students);
        }


    }
}
