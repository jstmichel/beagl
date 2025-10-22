using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.WebApp.Constants;
using Beagl.WebApp.Pages.Animals.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for creating a new dog.
/// </summary>
internal sealed class CreateDogModel(
    IBreedQueryService breedQueryService,
    IColorQueryService colorQueryService,
    IDogService dogService) : PageModel
{
    /// <summary>
    /// Gets or sets the input model for creating a dog.
    /// </summary>
    [BindProperty]
    public CreateDogViewModel Input { get; set; } = new CreateDogViewModel();
    public IEnumerable<BreedDto> BreedList { get; set; } = [];
    public IEnumerable<ColorDto> ColorList { get; set; } = [];

    /// <summary>
    /// Handles GET requests.
    /// </summary>
    public async Task OnGetAsync()
    {
        BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Dog);
        ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Dog);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Dog);
            ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Dog);
            return Page();
        }

        _ = await dogService.CreateDogAsync(new CreateDogDto
        {
            Name = Input.Name,
            BreedPrimaryId = Input.BreedPrimaryId!.Value,
            ColorId = Input.ColorId!.Value,
            Description = Input.Description,
            Gender = Input.Gender,
            BirthDate = Input.BirthDate!.Value,
            PhotoBase64 = Input.PhotoBase64,
            MicrochipNumber = Input.MicrochipNumber,
            Weight = Input.Weight,
            WeightUnit = Input.WeightUnit,
        });

        return RedirectToPage(LocalRedirection.Animals);
    }
}
