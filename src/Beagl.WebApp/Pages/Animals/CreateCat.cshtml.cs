using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.WebApp.Constants;
using Beagl.WebApp.Mappers;
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

        CreateCatDto catDto = Input.ToDto();
        _ = await catService.CreateCatAsync(catDto);

        return RedirectToPage(LocalRedirection.Animals);
    }
}
