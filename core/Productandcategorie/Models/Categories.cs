#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltReview.Models;
public class Categorie
{
    [Key]
    public int CategorieId {get; set;}
    [Required]
    [MinLength(4)]
    [MaxLength(45)]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Association> Association {get; set;} =new List<Association>();
}