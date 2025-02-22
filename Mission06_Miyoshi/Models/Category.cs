using System.ComponentModel.DataAnnotations;

namespace Mission06_Miyoshi.Models;

public class Category //holding the information for one category (singular)
{
    [Key]
    public int CategoryId { get; set; }
    
    public string CategoryName { get; set; }
}