using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Back_End_WebAPI.Models
{
    public class ExamPostDTO
    {
        [Required]
        public int Group { get; set; }

        [Required]
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int ProfessorID { get; set; }
        [Required]

        [ForeignKey("User")]
        public int AssistantID { get; set; }

        [Required]
        public DateOnly Date { get; set; }
        [Required]

        public string Start_Time { get; set; }
        [Required]
        [ForeignKey("Location")]
        public int LocationID { get; set; }
        [Required]
        public int Duration {  get; set; }
    }
}
