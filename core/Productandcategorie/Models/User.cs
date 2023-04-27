#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltReview.Models;

public class User
{
    [Key]
    public int UserId{ get; set;}
    [Required]
    [MinLength(length: 2, ErrorMessage ="First Name must be at least 2 character 🤷🏻‍♂️🤷🏻‍♀️")]
    public string FirstName {get; set;} 
    [Required]
    [MinLength(length: 2, ErrorMessage ="Last Name must be at least 2 character 🤷🏻‍♂️🤷🏻‍♀️")]
    public string LastName {get; set;} 
    [Required]
    [EmailAddress]
    public string Email {get; set;} 
    [Required]
    [DataType(dataType: DataType.Password)]
    [MinLength(length: 8, ErrorMessage ="Password must be at least 8 character ❗")]
    public string Password {get; set;} 
    [NotMapped]
    [Required]
    [Compare(otherProperty:"Password")]
    [DataType(dataType: DataType.Password)]

    [MinLength(length: 8, ErrorMessage ="Confirm Password must be identical to the password and at least 8 character ❗")]
    public string ConfirmPassword {get; set;} 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    //************* One to Many
    public List<Product> Myproducts {get; set;} =new List<Product>();
    ///***********************************SELF JOIN 🧸************
    [InverseProperty("Seller")]
    public List<Order> Buyers {get; set;}= new List<Order>();
    [InverseProperty("Buyer")]
    public List<Order> Sellesr {get; set;}= new List<Order>();
}
