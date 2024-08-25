using BookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<UserModel> signInManager;

        public LogoutController(SignInManager<UserModel> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "Login");
        }
    }
}
