using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class SubjectPostDTO
    {
     
        [Required]
        [ForeignKey("User")]
        public int ProfessorID { get; set; }

        [Required]
        public string SubjectName { get; set; } = null!;
    }
}
