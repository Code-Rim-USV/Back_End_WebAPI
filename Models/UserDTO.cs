using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class UserDTO
    {
        
        public Nullable<int> UserID { get; set; }
       
        public string FirstName { get; set; } = null!;
      
        public string LastName { get; set; } = null!;
       
        public string Email { get; set; } = null!;
     
    }
}
