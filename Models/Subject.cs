using System.ComponentModel.DataAnnotations;

namespace Back_End_WebAPI.Models
{
    public class Subject
    {
        [Key]
        [Required]
        public int SubjectID { get; set; }

        [Required]
        public string SubjectName { get; set; } = null!;
    }
}



