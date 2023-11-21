
using HotelBooking.Models;
using HotelBooking.Models.DTOs;

namespace HotelBooking.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
        List<Hotel> HotelSearch(HotelDTO hotelDTO);
        List<User> GetAllUsers();
    }
}
