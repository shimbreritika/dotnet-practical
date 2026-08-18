using Assignment_12AUG.Models;

namespace Assignment_12AUG.Model
{
    public class Booking
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public decimal TotalAmt { get; set; }

        public string Status { get; set; } = string.Empty;

        public Customer Customer { get; set; }

        public ICollection<BookingRoom> BookingRooms { get; set; }
            = new List<BookingRoom>();
    }
}