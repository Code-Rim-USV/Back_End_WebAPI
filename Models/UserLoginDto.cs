using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Back_End_WebAPI.Models
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        [Required]
        public string Password { get; set; } 
    }
}