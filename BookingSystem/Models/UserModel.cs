using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

// Author: Julius.B
// Date: August 24, 2024
// Description: Model of the user
namespace BookingSystem.Models
{
    public class UserModel : IdentityUser
    {

        /*
         * Built-in Column from Migration
         * UserName
         * Email
         * PhoneNumber
         * PasswordHash
         * 
         */

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [NotMapped]
        public String PasswordString {  get; set; } = String.Empty;
    }
}
