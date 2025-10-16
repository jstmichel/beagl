// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for editing an animal.
/// </summary>
internal sealed class EditModel : PageModel
{
    /// <summary>
    /// Gets or sets the animal DTO for binding.
    /// </summary>
    [BindProperty]
    public AnimalDto Animal { get; set; } = new AnimalDto();

    /// <summary>
    /// Handles the GET request to load the animal for editing.
    /// </summary>
    /// <param name="id">The unique identifier of the animal.</param>
    /// <returns>The page result.</returns>
    public IActionResult OnGetAsync(Guid id)
    {
        // TODO: Load the animal from the database by id.
        // Example: Animal = await _animalService.GetByIdAsync(id);
        // If not found, return NotFound();
        return Page();
    }
}
