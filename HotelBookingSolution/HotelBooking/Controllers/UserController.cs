

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using HotelBooking.Exceptions;
using HotelBooking.Interfaces;
using HotelBooking.Models;
using HotelBooking.Models.DTOs;
using HotelBooking.Models.DTOs;
using HotelBooking.Models.DTOs;

namespace HotelBooking.Controllers
{
    

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserViewModel viewModel)
        {
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DbUpdateException exp)
            {
                ViewBag.Message = "User name already exits";
            }
            catch (Exception)
            {
                ViewBag.Message = "Invalid data. Coudld not register";
                throw;
            }
            //ViewData["Message"] = "Invalid data. Coudld not register";

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                TempData.Add("username", userDTO.UserName);
                return RedirectToAction("Index", "Home");
            }
            ViewData["Message"] = "Invalid username or password";
            return View();
        }

    }
}
