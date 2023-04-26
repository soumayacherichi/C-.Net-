#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LogRegLecture.Models;
public class User
{
    // ---------------------ID--------------------------
    [Key]
    public int UserId { get; set; }

    // ---------------------Username------------------------------------
    [Required(ErrorMessage ="Username is required !!!!!!!")]
    [MinLength(2, ErrorMessage ="Username must be at least 2 ❌❌❌")]
    public string Username { get; set; } 

    // ------------------------Email---------------------------------
    [Required(ErrorMessage ="Email address must be present 😡😡😡")]
    [EmailAddress] // Email Pattern (= REGEX)
    public string Email { get; set; }

    // --------------------------Password----------------------------
    [Required(ErrorMessage ="Password is very required")]
    [MinLength(6,ErrorMessage ="Password must be > than 6")]
    [DataType(DataType.Password)] // To hide the password Input in The Views
    public string Password { get; set; }

    // -----------------------Confirm Password---------------------------------
    [NotMapped] // Do not add this field to DB
    [Compare("Password", ErrorMessage ="Password & Confirm Password must match")]
    [DataType(DataType.Password)] // To hide the Confirm password Input  in The Views
    [Display(Name ="Confirm Password")]
    public string Confirm { get; set; }

    // ---------------------Subscribe----------------------------------
    [Display(Name ="Subscribe to our newsletter ? ")]
    public bool Subscribe { get; set; }

    // -----------------------Created At--------------------------------
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // ----------------------------Updated At-------------------------------
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

