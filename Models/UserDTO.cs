using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class UserDTO
    {
        
        public int UserID { get; set; }
       
        public string UserName { get; set; }
       
        public string Email { get; set; } = null!;
     
    }
}
