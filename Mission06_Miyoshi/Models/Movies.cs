using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Miyoshi.Models;

public class Movies //holding the information for one movie (singular)
{
    //public int MovieID;

    //public int GetMovieID() //Getter
    //{
    //    return MovieID;
    //}

    //public void SetMovieID(int num) //Setter
    //{
    //    MovieID = num;
    //}
    
    //public int MovieID { get; } // Read only
    
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; } // ? to handle null values
    public Category? Category { get; set; } // Navigation property for EF Core to establish a relationship with the Category table
    
    [Required]
    public string Title { get; set; }
    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    [Required]
    public bool Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [Required]
    public bool CopiedToPlex { get; set; }
    public string? Notes { get; set; }
    
}