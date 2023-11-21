using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using HotelBooking.Exceptions;
using HotelBooking.Interfaces;
using HotelBooking.Models;


namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
      [Authorize]
      [HttpGet]
        public ActionResult GetAllHotels()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.GetHotels();
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
      [Authorize(Roles = "Admin")]
      [HttpPost]
        public ActionResult Create(Hotel hotel)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.Add(hotel);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }

}