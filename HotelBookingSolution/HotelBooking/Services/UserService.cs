
using HotelBooking.Exceptions;
using HotelBooking.Interfaces;
using HotelBooking.Models;
using HotelBooking.Models.DTOs;
using System.Security.Cryptography;
using System.Text;
using HotelBooking.Repositories;

namespace HotelBooking.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrepository;
        private readonly IHotelRepository _hotelrepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userrepository, ITokenService tokenService, IHotelRepository busrepository)
        {
            _userrepository = userrepository;
            _tokenService = tokenService;
            _hotelrepository = busrepository;
        }
        public UserDTO Login(UserDTO userDTO)
        {
            var user = _userrepository.GetById(userDTO.UserName);
            if (user != null)
            {
                HMACSHA512 hmac = new HMACSHA512(user.Key);
                var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userpass.Length; i++)
                {
                    if (user.Password[i] != userpass[i])
                        return null;
                }
                userDTO.Token = _tokenService.GetToken(userDTO);
                userDTO.Password = "";
                return userDTO;
            }
            return null;
        }

        public UserDTO Register(UserDTO userDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();
            User user = new User()
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                Phone= userDTO.Phone,
                City = userDTO.City,
               
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                Key = hmac.Key,
                Role = userDTO.Role
            };
            var result = _userrepository.Add(user);
            if (result != null)
            {
                userDTO.Password = "";
                return userDTO;
            }
            return null;

        }

        public List<Hotel> GetAll()
        {
            var busses = _hotelrepository.GetAll();
            if (busses != null)
            {
                return busses.ToList();
            }
            throw new NoHotelsAvailableException();
        }
        public List<Hotel> HotelSearch(HotelDTO HotelDto)
        {
            var search = _hotelrepository.GetAll();
            if (search != null)
            {
                List<Hotel> HotelList = new List<Hotel>();

                for (int i = 0; i < search.Count; i++)
                {
                    if (search[i].City == HotelDto.City)
                    {

                        HotelList.Add(search[i]);
                        
                    }

                }
                if (HotelList.Count > 0) return HotelList;
                else throw new NoHotelsAvailableException();



            }
            return null;

        }

        public List<User> GetAllUsers()
        {
            var users = _userrepository.GetAll();
            if (users != null)
            {
                return users.ToList();
            }
            throw new NoUsersAvailableException();
        }


    }
}