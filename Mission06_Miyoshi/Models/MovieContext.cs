using Microsoft.EntityFrameworkCore;

namespace Mission06_Miyoshi.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) {}
    
    public DbSet<Movies> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //check if the data is in there and seed data if not
    {
        modelBuilder.Entity<Category>().HasData(

            new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
            new Category { CategoryId = 2, CategoryName = "Drama" },
            new Category { CategoryId = 3, CategoryName = "Television" },
            new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
            new Category { CategoryId = 5, CategoryName = "Comedy" },
            new Category { CategoryId = 6, CategoryName = "Family" },
            new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
            new Category { CategoryId = 8, CategoryName = "VHS" }
        );
    }
}

// take a DbSet (i.e. List) of those individual Movie and Category entries
// call it "Movies" and "Categories"
// because the DbContext file is going to relate that to the tables in the database
// Each Movie or Category object corresponds to a row in the database
// And the collection of those items in the DbSet corresponds to tables in the database