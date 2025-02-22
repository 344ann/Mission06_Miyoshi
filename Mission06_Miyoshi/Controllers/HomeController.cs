using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Miyoshi.Models;

namespace Mission06_Miyoshi.Controllers;

public class HomeController : Controller
{
    private MovieContext _context; // Private field to hold the database context
    
    public HomeController(MovieContext temp) //Constructor
    {
        _context = temp;
    }

    // Default action method that returns the Index view
    public IActionResult Index()
    {
        return View();
    }

    // Action method to return the Know view
    public IActionResult Know()
    {
        return View();
    }
    
    // HTTP GET: Returns the Movies view (form for entering movie details)
    [HttpGet]
    public IActionResult Movies()
    {
        // Fetches the categories from the database and stores them in ViewBag for dropdown selection
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryId)
            .ToList();
        
        return View(new Movies()); // Returns an empty movie object for the form
    }

    // HTTP POST: Receives movie data from the form and saves it to the database
    [HttpPost]
    public IActionResult Movies(Movies response)
    {
        if (ModelState.IsValid) // Checks if form data is valid based on model rules
        {
            _context.Movies.Add(response); //Add record to the database
            _context.SaveChanges(); // Saves changes to the database
            return RedirectToAction("Movies"); // Returns the Movies view

        }
        else //Invalid data
        { 
            // Reloads the categories to repopulate the dropdown list
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return RedirectToAction("Movies", response); // Returns the Movies view
        }
    }

    // Retrieves and displays the list of movies
    public IActionResult MovieList()
    {
        //Linq
        var movies = _context.Movies
            .Include(x => x.Category) // Ensures category data is also loaded
            //.Where(x => x.CreeperStalker == false)
            .OrderBy(x => x.Title)
            .ToList();

        return View(movies);
    }

    // HTTP GET: Retrieves the movie to be edited based on its ID
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id); // Finds the specific movie by ID
        
        // Loads categories for dropdown selection
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryId)
            .ToList();
        
        return View("Movies", recordToEdit);
    }

    // HTTP POST: Updates the movie details in the database
    [HttpPost]
    public IActionResult Edit(Movies updatedInfo)
    {
        _context.Movies.Update(updatedInfo);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }

    // HTTP GET: Displays a confirmation page before deleting a movie
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.Single(x => x.MovieId == id);
        
        return View(recordToDelete); // Passes movie data to the delete confirmation page
    }
    
    // HTTP POST: Deletes the movie from the database
    [HttpPost]
    public IActionResult Delete(Movies deletedInfo)
    {
        _context.Movies.Remove(deletedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList"); // Redirects back to the movie list
    }
    

    // Handles error responses and displays an error view
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}