using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class HasRole
    {
        [Key]
        [ForeignKey("User")]
        [AllowNull]
        public Nullable<int> UserID { get; set; }

        [Key]
        public string Role { get; set; }
       
    }
}