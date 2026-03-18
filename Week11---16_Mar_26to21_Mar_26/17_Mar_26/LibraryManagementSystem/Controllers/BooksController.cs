using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.ViewModels;

public class BooksController : Controller
{
    static List<Book> books = new List<Book>()
    {
        new Book { Id = 1, Title = "C# Basics", Author = "John", PublishedYear = 2020, Genre = "Programming" },
        new Book { Id = 2, Title = "ASP.NET Core", Author = "Smith", PublishedYear = 2022, Genre = "Web" }
    };

    // Index Action
    public IActionResult Index()
    {
        ViewBag.Message = "Welcome to Library!";
        ViewData["TotalBooks"] = books.Count;

        var viewModelList = books.Select(b => new BookViewModel
        {
            Book = b,
            IsAvailable = true,
            BorrowerName = ""
        }).ToList();

        return View(viewModelList);
    }

    // GET: Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Create
    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            book.Id = books.Count + 1;
            books.Add(book);
            return RedirectToAction("Index");
        }

        return View(book);
    }
}
