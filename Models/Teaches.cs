using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_End_WebAPI.Models
{
    // Done?
    public class Teaches
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Key]
        [Required]
        public int SubjectID { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
