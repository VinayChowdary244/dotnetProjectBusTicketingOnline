using System.ComponentModel.DataAnnotations;

namespace BusTicketingWebApplication.Models.DTOs
{
    public class BusDTO
    {
        [Required(ErrorMessage = "Start location cannot be empty")]
        public string Start { get; set; }

        [Required(ErrorMessage = "Destination cannot be empty")]
        public string End { get; set; }
    }
}
