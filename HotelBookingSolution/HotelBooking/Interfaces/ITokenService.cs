using HotelBooking.Models;
using HotelBooking.Models.DTOs;

namespace HotelBooking.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
