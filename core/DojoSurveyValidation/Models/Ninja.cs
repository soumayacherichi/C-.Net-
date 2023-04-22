#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyValidation.Models;
public class Ninja
{
    [Required(ErrorMessage ="UserName is required ❌❌❌")]
    public string  UserName { get; set; }
    [Required(ErrorMessage = "Location must be Added 😡😡😡")]
    public string Location { get; set; }
    [Required(ErrorMessage = "Language must be Added 😡😡😡")]
    public string Language { get; set; }

    [Required(ErrorMessage = "Comment must be Added 😡😡😡")]
    public string Comment { get; set; }
}