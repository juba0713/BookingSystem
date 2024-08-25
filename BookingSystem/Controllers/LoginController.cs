using BookingSystem.Common;
using BookingSystem.Dto;
using BookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

// Author: Julius.B
// Date: August 24, 2024
// Description: Controller for Login
namespace BookingSystem.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<UserModel> signInManager;
        private readonly UserManager<UserModel> userManager;

        public LoginController(SignInManager<UserModel> signInManager, UserManager<UserModel> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return PartialView(CommonConstant.HTML_LOGIN_PATH);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(CommonConstant.HTML_LOGIN_PATH);
            }

            var result = await signInManager.PasswordSignInAsync(loginDto.UserName!, loginDto.Password!, false, false);
  
            if (!result.Succeeded)
            {
                return PartialView(CommonConstant.HTML_LOGIN_PATH);
            }

            var user = await userManager.FindByNameAsync(loginDto.UserName);

            if (user == null)
            {
                return PartialView(CommonConstant.HTML_LOGIN_PATH);
            }

            var roles = await userManager.GetRolesAsync(user);

            if (roles.Contains(CommonConstant.ROLE_SUPER))
            {
                return RedirectToAction("Dashboard", "System"); 
            }
            if (roles.Contains(CommonConstant.ROLE_ADMIN))
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            
            return RedirectToRoute("Dashboard");
        }
    }
}
