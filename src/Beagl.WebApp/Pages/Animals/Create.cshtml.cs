// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for creating a new animal.
/// </summary>
internal sealed class CreateModel : PageModel
{
    /// <summary>
    /// Gets or sets the animal DTO for binding.
    /// </summary>
    [BindProperty]
    public AnimalDto Animal { get; set; } = new AnimalDto();

    /// <summary>
    /// Handles the POST request to create a new animal.
    /// </summary>
    /// <returns>A redirect to the animal index page on success, or the current page on failure.</returns>
    public IActionResult OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // TODO: Add logic to persist the animal to the database.
        // Example: await _animalService.CreateAsync(Animal);

        return RedirectToPage("/Animals/Index");
    }
}
