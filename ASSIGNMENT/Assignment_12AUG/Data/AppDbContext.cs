using Assignment_12AUG.Model;
using Assignment_12AUG.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_12AUG.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingRoom> BookingRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // BookingRoom composite primary key
            modelBuilder.Entity<BookingRoom>()
                .HasKey(br => new
                {
                    br.BookingId,
                    br.RoomId
                });

            // Hotel 1 : M Room
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);

            // Customer 1 : M Booking
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId);

            // Booking 1 : M BookingRoom
            modelBuilder.Entity<Booking>()
                .HasMany(b => b.BookingRooms)
                .WithOne(br => br.Booking)
                .HasForeignKey(br => br.BookingId);

            // Room 1 : M BookingRoom
            modelBuilder.Entity<Room>()
                .HasMany(r => r.BookingRooms)
                .WithOne(br => br.Room)
                .HasForeignKey(br => br.RoomId);

            // Decimal precision
            modelBuilder.Entity<Room>()
                .Property(r => r.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BookingRoom>()
                .Property(br => br.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalAmt)
                .HasPrecision(18, 2);

            // Seed Hotel
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Grand Hotel",
                    City = "Pune"
                }
            );

            // Seed Rooms
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1,
                    HotelId = 1,
                    RoomNumber = 101,
                    RoomType = "Single",
                    Price = 1500
                },
                new Room
                {
                    Id = 2,
                    HotelId = 1,
                    RoomNumber = 102,
                    RoomType = "Double",
                    Price = 2500
                },
                new Room
                {
                    Id = 3,
                    HotelId = 1,
                    RoomNumber = 103,
                    RoomType = "Deluxe",
                    Price = 3500
                }
            );

            // Seed Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Ritika",
                    Email = "ritika@gmail.com"
                }
            );
        }
    }
}