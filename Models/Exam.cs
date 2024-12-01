using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class Exam
    {
        [Key]
        [AllowNull]
        public Nullable<int> ExamID { get; set; }

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
        public int LocationID { get; set; }
       
      
    

    }
}
