namespace HotelBooking.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Type { get; set; }
        public int Charge { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
