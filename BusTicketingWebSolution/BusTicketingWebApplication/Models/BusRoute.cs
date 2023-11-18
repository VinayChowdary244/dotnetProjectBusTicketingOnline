using System.ComponentModel.DataAnnotations;

namespace BusTicketingWebApplication.Models
{
    public class BusRoute
    {
        [Key]
        public int  RouteId { get; set; }
        public string Start { get; set;}
        public string End { get; set;}
        
    }
}
