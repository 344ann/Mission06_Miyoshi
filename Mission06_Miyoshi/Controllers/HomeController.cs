using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    // HTTP POST: Receives movie data from the form and saves it to the database
    [HttpPost]
    public IActionResult Movies(Movies response)
    {
        _context.Movies.Add(response); //Add record to the datebase
        _context.SaveChanges(); // Saves changes to the database
        return View(response); // Returns the Movies view with the submitted data
    }

    // Handles error responses and displays an error view
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}