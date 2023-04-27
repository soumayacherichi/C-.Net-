#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefDishes.Models;

public class Dish {
    [Key]
    public int DichID {get; set;}
    [Required]
    public int ChefID {get; set;}
    [Required(ErrorMessage = "Name is required")]
    public string Name {get; set;}
    [Required(ErrorMessage = "Number of caliories is required")]
    public int Caliories {get; set;}
    [Required(ErrorMessage = "Tastiness is required")]
    public int Tastiness {get; set;}
    
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;
    public Chef? Owner {get; set;}
}