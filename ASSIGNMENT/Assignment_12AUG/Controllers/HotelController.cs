using Assignment_12AUG.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_12AUG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService service;

        public HotelController(IHotelService service)
        {
            this.service = service;
        }

        // View available hotels
        [HttpGet]
        public IActionResult GetHotels()
        {
            var hotels = service.GetHotels();

            return Ok(hotels);
        }

        // View rooms inside hotel
        [HttpGet("{hotelId}/rooms")]
        public IActionResult GetRooms(int hotelId)
        {
            var rooms = service.GetRoomsByHotel(hotelId);

            return Ok(rooms);
        }

        // Book one or more rooms
        [HttpPost("book")]
        public IActionResult BookRooms(
            int customerId,
            List<int> roomIds,
            DateTime checkIn,
            DateTime checkOut)
        {
            var booking = service.BookRooms(
                customerId,
                roomIds,
                checkIn,
                checkOut);

            return Ok(booking);
        }

        // View customer's bookings
        [HttpGet("customer/{customerId}/bookings")]
        public IActionResult GetCustomerBookings(int customerId)
        {
            var bookings = service.GetCustomerBookings(customerId);

            return Ok(bookings);
        }

    }
}
