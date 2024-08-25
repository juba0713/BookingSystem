using BookingSystem.Common;
using BookingSystem.Dto;
using BookingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Authorize(Roles = CommonConstant.ROLE_ADMIN)]
    public class AdminController : Controller
    {

        private readonly UserManager<UserModel> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [Route("/Admin/Dashboard")]
        public IActionResult Dashboard()
        {
            return PartialView(CommonConstant.HTML_ADMIN_DASHBOARD_PATH);
        }

        [HttpGet]
        [Route("/Admin/Users")]
        public IActionResult Users()
        {
            return PartialView(CommonConstant.HTML_ADMIN_USERS_PATH);
        }

        [HttpGet]
        [Route("/Admin/Users/Create")]
        public IActionResult Create()
        {
            return PartialView(CommonConstant.HTML_ADMIN_USERS_CREATE_PATH);
        }

        [HttpPost]
        [Route("/Admin/Users/Create")]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {

            if (!ModelState.IsValid)
            {
                return PartialView(CommonConstant.HTML_ADMIN_USERS_CREATE_PATH);
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
                return PartialView(CommonConstant.HTML_ADMIN_USERS_CREATE_PATH);
            }

            var roleResult = await userManager.AddToRoleAsync(newUser, CommonConstant.ROLE_ADMIN);

            if (!roleResult.Succeeded)
            {
                return PartialView(CommonConstant.HTML_ADMIN_USERS_CREATE_PATH);
            }

            return RedirectToAction("Users", "System");
        }
    }
}
