using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class Exam
    {
        [Key]
        [Required]
        public int ExamID { get; set; }

        [Required]
        public int Group { get; set; }

        [Required]
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int ProfessorID { get; set; }

        [ForeignKey("User")]
        public int? AssistantID { get; set; }

        [Required]
        public DateOnly Date { get; set; }
        [AllowNull]

        public int? Start_Time { get; set; }
        [AllowNull]
        public string? Location { get; set; }

        [Required]
        public string Status { get; set; } = null!;

    }
}
