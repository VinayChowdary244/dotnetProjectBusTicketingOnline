using Microsoft.EntityFrameworkCore;
using HotelBooking.Models;

namespace HotelBooking.Contexts
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }

       
    }
}
