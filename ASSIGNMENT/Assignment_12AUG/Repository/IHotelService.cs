using Assignment_12AUG.Model;

namespace Assignment_12AUG.Repository
{
    public interface IHotelService
    {
        List<Hotel> GetHotels();

        List<Room> GetRoomsByHotel(int hotelId);

        Booking BookRooms(
            int customerId,
            List<int> roomIds,
            DateTime checkIn,
            DateTime checkOut);

        List<Booking> GetCustomerBookings(int customerId);
    }
}
