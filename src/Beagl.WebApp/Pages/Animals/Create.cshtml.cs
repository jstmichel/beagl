// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Beagl.WebApp.Pages.Animals.ViewModels;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Application.AnimalManagement.DTOs;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for creating a new animal.
/// </summary>
internal sealed class CreateModel(
    IBreedQueryService breedQueryService,
    IColorQueryService colorQueryService) : PageModel
{
    /// <summary>
    /// Gets or sets the animal DTO for binding.
    /// </summary>
    [BindProperty]
    public CreateAnimalViewModel Animal { get; set; } = new();

    /// <summary>
    /// Gets the list of species for the dropdown.
    /// </summary>
    public IList<SpeciesDto> SpeciesList { get; private set; } = [];

    /// <summary>
    /// Gets the list of breeds for the dropdown.
    /// </summary>
    public IList<BreedDto> BreedList { get; private set; } = [];

    /// <summary>
    /// Gets the list of colors for the dropdown.
    /// </summary>
    public IList<ColorDto> ColorList { get; private set; } = [];

    /// <summary>
    /// Handles the GET request to load dropdown data.
    /// </summary>
    public async Task<IActionResult> OnGetAsync()
    {
        BreedList = await breedQueryService.GetAllAsync();
        ColorList = await colorQueryService.GetAllAsync();
        return Page();
    }

    // /// <summary>
    // /// Handles the POST request to create a new animal.
    // /// </summary>
    // /// <returns>A redirect to the animal index page on success, or the current page on failure.</returns>
    // public async Task<IActionResult> OnPostAsync()
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return Page();
    //     }

    //     try
    //     {
    //         await CreateAsync();
    //     }
    //     catch (ArgumentNullException)
    //     {
    //         ModelState.AddModelError(string.Empty, "Invalid animal data provided.");
    //         return Page();
    //     }

    //     return RedirectToPage("/Animals/Index");
    // }

    // private async Task CreateAsync()
    // {
    //     AnimalDto animalDto = Animal.MapToDataTransferObject();
    //     await animalService.CreateAsync(animalDto);
    // }

    // private Guid GetCurrentUserId() =>
    //     Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());
}
