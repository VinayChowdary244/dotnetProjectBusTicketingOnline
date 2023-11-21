using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models.DTOs
{
    public class HotelDTO
    {
        [Required(ErrorMessage = "City or Area cannot be empty")]
        public string City { get; set; }

        
    }
}
