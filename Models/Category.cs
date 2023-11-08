using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Name is too long, please type a smaller name!")]
    // [RegularExpression(@"/^[a-zA-Z\s]*$/", ErrorMessage = "Numbers are not allowed!")]
    public string? Name { get; set; }
    [Range(0, 100, ErrorMessage = "Please enter valid integer Number!")]
    [DisplayName("Display Order")]
    public int DisplayOrder { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
}