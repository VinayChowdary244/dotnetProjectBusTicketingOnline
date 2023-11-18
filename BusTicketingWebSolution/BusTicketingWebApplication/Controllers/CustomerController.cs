using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTicketingWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public ActionResult Register(UserDTO viewModel)
        {
            string message = "";
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (DbUpdateException exp)
            {
                message = "Duplicate username";
            }
            catch (Exception)
            {

            }


            return BadRequest(message);
        }

        [HttpPost]
        [Route("Login")]//attribute based routing
        public ActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized("Invalid username or password");
        }

        [HttpPost]
        [Route("BusSearch")]
        public ActionResult BusSearch(BusDTO busDTO) 
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.BusSearch(busDTO);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);

        }

        [HttpGet]
        [Route("GetAllBusses")]
        public ActionResult GetAllBusses()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _userService.GetAll();
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
