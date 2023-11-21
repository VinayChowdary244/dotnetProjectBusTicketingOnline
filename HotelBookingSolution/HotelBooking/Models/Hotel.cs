using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string City { get; set; }
        public int NoOfRooms { get; set; }
        public int AvailableRooms { get; set; }
        public ICollection<Room>? Rooms { get; set; }
      


    }
}
