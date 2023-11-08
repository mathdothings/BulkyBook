using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _database;

    public CategoryController(ApplicationDbContext database)
    {
        _database = database;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> categoriesList = _database.Categories.ToList();
        return View(categoriesList);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if(!ModelState.IsValid) return View(category);
        
        _database.Add(category);
        _database.SaveChanges();
        return RedirectToAction("Index");
    }
}