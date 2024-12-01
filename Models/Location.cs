using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class Location
    {
        [Key]
        [AllowNull]
        public Nullable<int> LocationID { get; set; }
        [Required]
        public string LocationName { get; set; } = null!;

    }
}