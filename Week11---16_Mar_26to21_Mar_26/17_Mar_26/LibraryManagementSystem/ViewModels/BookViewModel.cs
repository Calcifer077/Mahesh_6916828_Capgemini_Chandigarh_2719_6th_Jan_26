using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.ViewModels;

public class BookViewModel
{
    public Book Book { get; set; }

    public bool IsAvailable { get; set; }

    // Extended Practice Property
    public string BorrowerName { get; set; }
}