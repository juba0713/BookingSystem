using System.ComponentModel.DataAnnotations;

// Author: Julius.B
// Date: August 24, 2024
// Description: DTO for user login.
namespace BookingSystem.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; } = string.Empty;
    }
}
