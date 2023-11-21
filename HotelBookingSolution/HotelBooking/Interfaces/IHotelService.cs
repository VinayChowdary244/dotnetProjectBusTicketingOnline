
using HotelBooking.Models;

namespace HotelBooking.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetHotels();
        Hotel Add(Hotel hotel);
        Hotel Update(Hotel hotel);
    }
}
