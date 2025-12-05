// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.Core.Helpers;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Infrastructure.AnimalManagement.DTOs;
using Beagl.Infrastructure.AnimalManagement.Services;
using Beagl.Infrastructure.CitizenManagement.DTOs;
using Beagl.Infrastructure.CitizenManagement.Services;
using Beagl.WebApp.Constants;
using Beagl.WebApp.Extensions;
using Beagl.WebApp.Mappers;
using Beagl.WebApp.Pages.Animals.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for creating a new cat.
/// </summary>
[Authorize(Policy = Policies.Animals.CanCreate)]
internal sealed class CreateCatModel(
    IBreedQueryService breedQueryService,
    IColorQueryService colorQueryService,
    IAnimalService animalService,
    ICitizenQueryService citizenQueryService) : PageModel
{
    /// <summary>
    /// Gets or sets the input model for creating a cat.
    /// </summary>
    [BindProperty]
    public CreateCatViewModel Input { get; set; } = new CreateCatViewModel();
    public IEnumerable<BreedDto> BreedList { get; set; } = [];
    public IEnumerable<ColorDto> ColorList { get; set; } = [];
    public IEnumerable<CitizenLookupDto> CitizenList { get; set; } = [];

    /// <summary>
    /// Handles GET requests.
    /// </summary>
    public async Task<IActionResult> OnGetAsync()
    {
        await LoadDropdownListsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdownListsAsync();
            return Page();
        }

        CreateCatDto catDto = Input.ToDto();
        Result<Guid> result = await animalService.CreateCatAsync(catDto);
        if (!result.Success)
        {
            ModelState.AddResultErrors(result);
            await LoadDropdownListsAsync();
            return Page();
        }

        return RedirectToPage(Redirection.ToAnimalList);
    }

    private async Task LoadDropdownListsAsync()
    {
        BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
        ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
        CitizenList = await citizenQueryService.GetAllLookupAsync();
    }
}
