using BookingSystem.Dto;
using BookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Author: Julius.B
// Date: August 24, 2024
// Description: Database Context for User
namespace BookingSystem.Data
{

    public interface IUserContext
    {
        Task<bool> AddUserAsync(UserModel user, string password);
    }

    public class UserContext : IdentityDbContext<UserModel>, IUserContext
    {

        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<UserModel> User { get; set; }

        // Custom method to add a user
        public async Task<bool> AddUserAsync(UserModel user, string password)
        {
            // Hash the password using a password hasher
            var passwordHasher = new PasswordHasher<UserModel>();
            user.PasswordHash = passwordHasher.HashPassword(user, password);

            // Add user to the database
            await User.AddAsync(user);

            // Save changes and return success/failure
            return await SaveChangesAsync() > 0;
        }
    }
}
