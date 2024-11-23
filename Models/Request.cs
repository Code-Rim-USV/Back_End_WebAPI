using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_End_WebAPI.Models
{
    // Done?
    public class Request
    {
        [Key]
        public Nullable<int> RequestID { get; set; }

        
        [Required]
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        [Required]
        [ForeignKey("User")]
        public int ProfessorID { get; set; }
        [Required]
        public int Group { get; set; }
        [Required]

        public DateOnly Date {  get; set; }
        [Required]

        public string Status { get; set; }

        public string? RejectionReason {  get; set; }
   
    }
}
