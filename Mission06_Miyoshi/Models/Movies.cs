using System.ComponentModel.DataAnnotations;

namespace Mission06_Miyoshi.Models;

public class Movies
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
    public int MovieID { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    
    public bool? Edited { get; set; }
    
    public string? LentTo { get; set; }
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
    
}