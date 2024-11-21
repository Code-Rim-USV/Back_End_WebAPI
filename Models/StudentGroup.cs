using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Back_End_WebAPI.Models;

public class StudentGroup
{
    [Key]
    public int UserID { get; set; }

    [Required]
    public int Group { get; set; }

    //public User User { get; set; }
}