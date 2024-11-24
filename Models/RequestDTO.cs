using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Back_End_WebAPI.Models
{
    public class RequestDTO
    {
        [Key]
        public int RequestID { get; set; }


        [Required]
        public string SubjectName { get; set; }
        [Required]
      
        public string ProfessorName { get; set; }
        [Required]
        public int Group { get; set; }
        [Required]

        public string Date { get; set; }
        [Required]

        public string Status { get; set; }

        public string? RejectionReason { get; set; }
    }
}
