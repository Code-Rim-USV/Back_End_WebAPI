using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Back_End_WebAPI.Models
{
    public class RequestPostDTO
    {
        [Required]
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        [Required]
        [ForeignKey("User")]
        public int ProfessorID { get; set; }
        [Required]
        public int Group { get; set; }
        [Required]

        public DateOnly Date { get; set; }
        
    }
}
