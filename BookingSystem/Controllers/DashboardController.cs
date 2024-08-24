using BookingSystem.Common;
using BookingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        private readonly SignInManager<UserModel> signInManager;

        public DashboardController(SignInManager<UserModel> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return PartialView(CommonConstant.HTML_DASHBOARD_PATH);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "Login");
        }

    }
}
