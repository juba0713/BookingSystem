using System.ComponentModel.DataAnnotations;

// Author: Julius.B
// Date: August 24, 2024
// Description: DTO for user registration.
namespace BookingSystem.Dto
{
    public class RegisterDto
    {
        
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter confirm password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
