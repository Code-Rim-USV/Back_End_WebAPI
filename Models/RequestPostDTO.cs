using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Back_End_WebAPI.Models
{
    public class RequestPostDTO
    {
        [Required]
        [ForeignKey("User")]
        public int UserID { set; get; }

        [Required]
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        
    }
}
