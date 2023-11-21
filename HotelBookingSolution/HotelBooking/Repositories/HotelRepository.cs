
using HotelBooking.Contexts;
using HotelBooking.Interfaces;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Models;

namespace HotelBooking.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext _context;
        public HotelRepository(HotelContext context)
        {
            _context = context;
        }

        public Hotel Add(Hotel item)
        {
            _context.Hotels.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Hotel Delete(int key)
        {
            var bus = GetById(key);
            if (bus != null)
            {
                _context.Hotels.Remove(bus);
                _context.SaveChanges();
                return bus;
            }
            return null;
        }

        public Hotel GetById(int key)
        {
            var cus = _context.Hotels.SingleOrDefault(x => x.HotelId == key);
            return cus;
        }

        public IList<Hotel> GetAll()
        {
            if (_context.Hotels.Count() == 0)
            {
                return null;
            }
            return _context.Hotels.ToList();

        }

        public Hotel Update(Hotel entity)
        {
            var cus = GetById(entity.HotelId);
            if (cus != null)
            {
                _context.Entry<Hotel>(cus).State = EntityState.Modified;
                _context.SaveChanges();
                return cus;
            }
            return null;
        }
    }
}

