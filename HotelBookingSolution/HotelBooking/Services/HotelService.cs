using Microsoft.EntityFrameworkCore;
using HotelBooking.Exceptions;
using HotelBooking.Interfaces;

using HotelBooking.Models;


namespace HotelBooking.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository repository)
        {
            _hotelRepository = repository;
        }
        public Hotel Add(Hotel hotel)
        {
            var result = _hotelRepository.Add(hotel);
            return result;
        }

        public List<Hotel> GetHotels()
        {
            var hotels = _hotelRepository.GetAll();
            if (hotels != null)
            {
                return hotels.ToList();
            }
            throw new NoHotelsAvailableException();
        }

        public Hotel Update(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}