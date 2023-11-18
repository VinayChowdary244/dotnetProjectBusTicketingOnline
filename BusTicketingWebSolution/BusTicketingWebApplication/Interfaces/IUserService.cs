using BusModelLibrary;
using BusTicketingWebApplication.Models.DTOs;

namespace BusTicketingWebApplication.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
        List<Bus> BusSearch(BusDTO busDTO);
        List<Bus> GetAll();
    }
}
