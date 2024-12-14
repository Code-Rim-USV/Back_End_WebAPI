using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Back_End_WebAPI.Models
{
    public class ExamPutDTO
    {
        [Key]
        public int ExamID { get; set; }
        public int AssistantID { get; set; }
        public string Start_Time { get; set; }
        public int LocationID { get; set; }
       
    }
}
