using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Back_End_WebAPI.Models
{
    public class ExamPostWithRequestDTO
    {
        [Required]
        [ForeignKey("Request")]
        public int RequestID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int AssistantID { get; set; }
        public string Start_Time { get; set; }
        [ForeignKey("Location")]
        public int LocationID { get; set; }
        public int Duration { get; set; }
    }
}
