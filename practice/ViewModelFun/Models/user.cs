#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ViewModelFun.Models;
public class User 
{
    [Required(ErrorMessage ="First Name is required ❌❌❌")]
    public string  FirstName { get; set; }
    [Required(ErrorMessage ="Last Name is required ❌❌❌")]
    public string  LastName { get; set; }
    [Required(ErrorMessage ="Number is required ❌❌❌")]
    public int  Number { get; set; }
    
}