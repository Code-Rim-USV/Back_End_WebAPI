using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End_WebAPI.Models
{
    public class HasRole
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string Role { get; set; }

        // public User User { get; set; }
    }
}