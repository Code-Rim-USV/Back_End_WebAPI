using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class LocationPostDTO
    {
        [Required]
        public string LocationName { get; set; } = null!;
    }
}
