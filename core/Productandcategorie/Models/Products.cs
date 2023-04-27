#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;//to avoid passing data to db
namespace BeltReview.Models;
public class Product
{
    [Key]
    public int ProductId {get; set;}
    [Required]
    //** userId +Nav proprty
    public int UserId {get; set;}
    //***** Navigatin Proprty
    public User? User {get; set;}
    [Required]
    [MinLength(4)]
    [MaxLength(45)]
    public string Name { get; set; }
    [Required]
    [Range(0.00,Double.MaxValue)]
    public Double Price { get; set; }
    [Required]
    [Range(1, 10000)]
    public int Quantity{ get; set; }
    [Required]
    [MinLength(6)]
    [MaxLength(100)]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Association> ProductsCategories {get; set;} = new List<Association>();
    public List<Order> ProductsOrder {get; set;} = new List<Order>();
}
