using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class ExamDTO
    {
        [Key]
        public int ExamID { get; set; }

        [Required]
        public int Group { get; set; }

        [Required]
     
        public string SubjectName { get; set; }

        [Required]
        public string ProfessorName { get; set; }
        [Required]

        public string AssistantName { get; set; }

        [Required]
        public string Date { get; set; }
        [Required]

        public string Start_Time { get; set; }
        [Required]
        public string Location { get; set; }




    }
}
