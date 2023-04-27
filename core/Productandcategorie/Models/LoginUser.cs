#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltReview.Models;

public class UseRouting
{
    [Required]
    [EmailAddress]
    public string LoginEmail {get; set;} 
    [Required]
    [DataType(dataType: DataType.Password)]
    [MinLength(length: 8, ErrorMessage ="Password must be at least 8 character ❗")]
    public string LoginPassword {get; set;} 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}