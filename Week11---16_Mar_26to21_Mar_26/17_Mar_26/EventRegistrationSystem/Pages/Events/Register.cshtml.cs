using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventRegistrationSystem.Models;

public class RegisterModel : PageModel
{
    public static List<EventRegistration> registrations = new List<EventRegistration>();

    [BindProperty]
    public EventRegistration Registration { get; set; }

    public void OnGet()
    {
    }

    //public IActionResult OnPost()
    //{
    //    if (!ModelState.IsValid)
    //        return Page();

    //    Registration.Id = registrations.Count + 1;
    //    registrations.Add(Registration);

    //    return RedirectToPage("Index");
    //}

    public IActionResult OnPost()
    {
        Console.WriteLine("Form Submitted!");

        return RedirectToPage("Index");
    }
}