using BookingSystem.Common;
using System.ComponentModel.DataAnnotations;

// Author: Julius.B
// Date: August 24, 2024
// Description: DTO for user registration.
namespace BookingSystem.Dto
{
    public class CreateUserDto
    {

        [Required(ErrorMessage = MessageConstant.USERNAME_BLANK)]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = MessageConstant.EMAIL_BLANK)]
        [EmailAddress(ErrorMessage = MessageConstant.EMAIL_INCORRECT_FORMAT)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = MessageConstant.FIRST_NAME_BLANK)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = MessageConstant.LAST_NAME_BLANK)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = MessageConstant.ROLE_BLANK)]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = MessageConstant.PASSWORD_BLANK)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = MessageConstant.CONFIRM_PASSWORD_BLANK)]
        [Compare("Password", ErrorMessage = MessageConstant.PASSWORD_NOT_EQUAL)]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
