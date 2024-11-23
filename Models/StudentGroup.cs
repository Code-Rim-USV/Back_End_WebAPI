using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Back_End_WebAPI.Models;

public class StudentGroup
{
    [Key]
    [ForeignKey("User")]
    [AllowNull]
    public Nullable<int> UserID { get; set; }

    [Required]
    public int Group { get; set; }

}