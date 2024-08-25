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
        private readonly RoleManager<IdentityRole> roleManager;

        public RegisterController(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager; 
        }

    
        [HttpGet]
        public IActionResult Register()
        {
            return PartialView(CommonConstant.HTML_REGISTER_PATH);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

            var role = CommonConstant.ROLE_SUPER;

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
                Console.WriteLine("User Insertion Failed");              
                return PartialView(CommonConstant.HTML_REGISTER_PATH);
            }

            /*
             * This is to check if the role "USER" has exist in the AspNetRoles
             */
            if (!await roleManager.RoleExistsAsync(CommonConstant.ROLE_USER))
            {
                var userRoleeCreated = await roleManager.CreateAsync(new IdentityRole(CommonConstant.ROLE_USER));
                var superRoleCreated = await roleManager.CreateAsync(new IdentityRole(CommonConstant.ROLE_SUPER));
                if (!userRoleeCreated.Succeeded || !superRoleCreated.Succeeded)
                {
                    throw new Exception($"Failed to create role: USER or SUPER");
                }
                role = CommonConstant.ROLE_SUPER;
            }

            var roleResult = await userManager.AddToRoleAsync(newUser, role);

            if (!roleResult.Succeeded)
            {
                Console.WriteLine("Role Async Failed");
                return PartialView(CommonConstant.HTML_REGISTER_PATH);
            }

            return RedirectToAction("Login", "Login");
        }
    }
}
