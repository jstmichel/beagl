// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Beagl.WebApp.Pages.Animals.ViewModels;
using Beagl.Application.AnimalManagement.Services;
using Beagl.WebApp.Extensions;
using Beagl.Application.AnimalManagement.DTOs;
using System.Security.Claims;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for creating a new animal.
/// </summary>
internal sealed class CreateModel(
    IAnimalService animalService) : PageModel
{
    /// <summary>
    /// Gets or sets the animal DTO for binding.
    /// </summary>
    [BindProperty]
    public CreateAnimalViewModel Animal { get; set; } = new();

    /// <summary>
    /// Handles the POST request to create a new animal.
    /// </summary>
    /// <returns>A redirect to the animal index page on success, or the current page on failure.</returns>
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await CreateAsync();
        }
        catch (ArgumentNullException)
        {
            ModelState.AddModelError(string.Empty, "Invalid animal data provided.");
            return Page();
        }

        return RedirectToPage("/Animals/Index");
    }

    private async Task CreateAsync()
    {
        AnimalDto animalDto = Animal.MapToDataTransferObject();
        await animalService.CreateAsync(animalDto);
    }

    private Guid GetCurrentUserId() =>
        Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
}
