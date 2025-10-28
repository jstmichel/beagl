using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.WebApp.Constants;
using Beagl.WebApp.Pages.Animals.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for creating a new cat.
/// </summary>
internal sealed class CreateCatModel(
    IBreedQueryService breedQueryService,
    IColorQueryService colorQueryService,
    ICatService catService) : PageModel
{
    /// <summary>
    /// Gets or sets the input model for creating a cat.
    /// </summary>
    [BindProperty]
    public CreateCatViewModel Input { get; set; } = new CreateCatViewModel();
    public IEnumerable<BreedDto> BreedList { get; set; } = [];
    public IEnumerable<ColorDto> ColorList { get; set; } = [];

    /// <summary>
    /// Handles GET requests.
    /// </summary>
    public async Task OnGetAsync()
    {
        BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
        ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
            ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
            return Page();
        }

        _ = await catService.CreateCatAsync(new CreateCatDto
        {
            Name = Input.Name,
            BreedPrimaryId = Input.BreedPrimaryId!.Value,
            ColorId = Input.ColorId!.Value,
            Description = Input.Description,
            Gender = Input.Gender,
            BirthDate = Input.BirthDate!.Value,
            PhotoBase64 = Input.PhotoBase64,
            MicrochipNumber = Input.MicrochipNumber,
            IsAnUnclawnedCat = Input.IsAnUnclawnedCat,
            Weight = Input.Weight,
            WeightUnit = Input.WeightUnit,
        });

        return RedirectToPage(LocalRedirection.Animals);
    }
}
