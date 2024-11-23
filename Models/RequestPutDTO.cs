using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Back_End_WebAPI.Models
{
    public class RequestPutDTO
    {
        [Key]
        public int RequestID { get; set; }
        public string RejectionReason { get; set; } = null!;

    }
}