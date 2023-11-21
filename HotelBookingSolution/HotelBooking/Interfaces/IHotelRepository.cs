using HotelBooking.Models;

namespace HotelBooking.Interfaces
{
    public interface IHotelRepository
    {
        public Hotel Add(Hotel item);
        public Hotel Delete(int key);
        public Hotel GetById(int key);
        public IList<Hotel> GetAll();
        public Hotel Update(Hotel item);
    }
}
