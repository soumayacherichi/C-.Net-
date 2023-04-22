#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace firstmvc.Models;
public class Pet 
{
    [Required (ErrorMessage="Name is required📌📌📌")]
    public string Name { get; set; }
     [Required (ErrorMessage="Age must be required📌📌📌")]
     [Range(1,30,ErrorMessage="Age must be required📌📌📌")]
    public int Age { get; set; }
     [Required]
    public bool IsFriendly  { get; set; }
     [Required (ErrorMessage="Color is required📌📌📌")]
    public string Color { get; set; }
}
