#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltReview.Models;
public class Order
{
    [Key]
    public int OrderId {get; set;}
    public int ProductId {get; set;}
    public Product? Product{get;set;}
    public int SellerId {get; set;}
    public User Seller{get;set;}
    public int BuyerId {get; set;}
    public User Buyer{get;set;}
    public int Quantity {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}