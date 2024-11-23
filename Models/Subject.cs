using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models
{
    public class Subject
    {
        [Key]
        [AllowNull]
        public Nullable<int> SubjectID { get; set; }
        [Required]
        [ForeignKey("User")]
        public int ProfessorID {  get; set; }  

        [Required]
        public string SubjectName { get; set; } = null!;
   
    }
}



