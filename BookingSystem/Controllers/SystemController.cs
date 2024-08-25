using BookingSystem.Common;
using BookingSystem.Dto;
using BookingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BookingSystem.Controllers
{
    [Authorize(Roles = CommonConstant.ROLE_SUPER)]
    public class SystemController : Controller
    {

        private readonly UserManager<UserModel> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SystemController(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [Route("/System/Dashboard")]
        public IActionResult Dashboard()
        {
            return PartialView(CommonConstant.HTML_SUPER_DASHBOARD_PATH);
        }

        [HttpGet]
        [Route("/System/Users")]
        public IActionResult Users()
        {
            return PartialView(CommonConstant.HTML_SUPER_USERS_PATH);
        }

        [HttpGet]
        [Route("/System/Users/Create")]
        public IActionResult Create()
        {
            return PartialView(CommonConstant.HTML_SUPER_USERS_CREATE_PATH);
        }

        [HttpPost]
        [Route("/System/Users/Create")]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {

            if (!ModelState.IsValid)
            {
                return PartialView(CommonConstant.HTML_SUPER_USERS_CREATE_PATH);
            }

            UserModel newUser = new UserModel()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
            };

            var result = await userManager.CreateAsync(newUser, dto.Password);

            if (!result.Succeeded)
            {
                return PartialView(CommonConstant.HTML_SUPER_USERS_CREATE_PATH);
            }

            if (!await roleManager.RoleExistsAsync(CommonConstant.ROLE_ADMIN))
            {
                var adminRoleCreated = await roleManager.CreateAsync(new IdentityRole(CommonConstant.ROLE_ADMIN));
                if (!adminRoleCreated.Succeeded)
                {
                    throw new Exception($"Failed to create role: USER or SUPER");
                }
            }

            var roleResult = await userManager.AddToRoleAsync(newUser, CommonConstant.ROLE_ADMIN);

            if (!roleResult.Succeeded)
            {
                return PartialView(CommonConstant.HTML_SUPER_USERS_CREATE_PATH);
            }

            return RedirectToAction("Users", "System");
        }
    }
}
