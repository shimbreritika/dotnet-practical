using Assignment_12AUG.Data;
using Assignment_12AUG.Model;
using Assignment_12AUG.Repository;
using Microsoft.EntityFrameworkCore;

namespace Assignment_12AUG.Service
{
    public class HotelService : IHotelService
    {
        private readonly AppDbContext _context;

        public HotelService(AppDbContext context)
        {
            _context = context;
        }

        // 1. View available hotels
        public List<Hotel> GetHotels()
        {
            return _context.Hotels
                .Include(h => h.Rooms)
                .ToList();
        }

        // 2. View rooms inside hotel
        public List<Room> GetRoomsByHotel(int hotelId)
        {
            return _context.Rooms
                .Where(r => r.HotelId == hotelId)
                .ToList();
        }

        // 3. Book one or more rooms
        public Booking BookRooms(
            int customerId,
            List<int> roomIds,
            DateTime checkIn,
            DateTime checkOut)
        {
            // Check customer
            var customer = _context.Customers
                .FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            // Validate dates
            if (checkOut <= checkIn)
            {
                throw new Exception("CheckOut must be after CheckIn.");
            }

            // Find rooms
            var rooms = _context.Rooms
                .Where(r => roomIds.Contains(r.Id))
                .ToList();

            if (rooms.Count != roomIds.Count)
            {
                throw new Exception("One or more rooms not found.");
            }

            // Calculate number of nights
            int nights = (checkOut.Date - checkIn.Date).Days;

            // Calculate total
            decimal totalAmount =
                rooms.Sum(r => r.Price) * nights;

            // Create booking
            var booking = new Booking
            {
                CustomerId = customerId,
                CheckIn = checkIn,
                CheckOut = checkOut,
                Status = "Confirmed",
                TotalAmt = totalAmount
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            // Add BookingRoom records
            foreach (var room in rooms)
            {
                var bookingRoom = new BookingRoom
                {
                    BookingId = booking.Id,
                    RoomId = room.Id,
                    Price = room.Price
                };

                _context.BookingRooms.Add(bookingRoom);
            }

            _context.SaveChanges();

            return booking;
        }

        // 4. View customer's bookings
        public List<Booking> GetCustomerBookings(int customerId)
        {
            return _context.Bookings
                .Where(b => b.CustomerId == customerId)
                .Include(b => b.Customer)
                .Include(b => b.BookingRooms)
                .ThenInclude(br => br.Room)
                .ToList();
        }
    }
}