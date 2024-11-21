using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_End_WebAPI.Models
{
    // Done?
    public class Attends
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Key]
        [Required]
        public int ExamID { get; set; }
    }
}
