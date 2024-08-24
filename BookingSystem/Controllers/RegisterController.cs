using BookingSystem.Common;
using BookingSystem.Data;
using BookingSystem.Dto;
using BookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Author: Julius.B
// Date: August 24, 2024
// Description: Controller for Register
namespace BookingSystem.Controllers
{
    public class RegisterController : Controller
    { 

        private readonly UserManager<UserModel> userManager;

        public RegisterController(UserManager<UserModel> userManager)
        {
            this.userManager = userManager;
        }

    
        [HttpGet]
        public IActionResult Register()
        {
            return PartialView(CommonConstant.HTML_REGISTER_PATH);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(CommonConstant.HTML_REGISTER_PATH);
            }

            UserModel newUser = new UserModel()
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.UserName,
            };

            var result = await userManager.CreateAsync(newUser, registerDto.Password);

            if(!result.Succeeded)
            {
                return PartialView(CommonConstant.HTML_REGISTER_PATH);
            }


            return RedirectToAction("Login", "Login");
        }
    }
}
