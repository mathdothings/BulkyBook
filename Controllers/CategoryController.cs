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
    
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null or <= 0)
        {
            return NotFound();
        }

        var categoryFromDatabase = _database.Categories.Find(id);
        if (categoryFromDatabase == null)
        {
            return NotFound();
        }
        
        return View(categoryFromDatabase);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if(!ModelState.IsValid) return View(category);
        
        _database.Update(category);
        _database.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id is null or <= 0)
        {
            return NotFound();
        }

        var categoryFromDatabase = _database.Categories.Find(id);
        if (categoryFromDatabase == null)
        {
            return NotFound();
        }
        
        return View(categoryFromDatabase);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Category category)
    {
        _database.Remove(category);
        _database.SaveChanges();
        return RedirectToAction("Index");
    }
}