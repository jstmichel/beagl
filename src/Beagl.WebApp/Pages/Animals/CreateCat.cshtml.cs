// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.WebApp.Constants;
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
    ICatService catService,
    ICitizenQueryService citizenQueryService) : PageModel
{
    /// <summary>
    /// Gets or sets the input model for creating a cat.
    /// </summary>
    [BindProperty]
    public CreateCatViewModel Input { get; set; } = new CreateCatViewModel();
    public IEnumerable<BreedDto> BreedList { get; set; } = [];
    public IEnumerable<ColorDto> ColorList { get; set; } = [];
    public IEnumerable<CitizenListDto> CitizenList { get; set; } = [];

    /// <summary>
    /// Handles GET requests.
    /// </summary>
    public async Task OnGetAsync()
    {
        BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
        ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
        CitizenList = await citizenQueryService.GetAllAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
            ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
            CitizenList = await citizenQueryService.GetAllAsync();
            return Page();
        }

        CreateCatDto catDto = Input.ToDto();
        _ = await catService.CreateCatAsync(catDto);

        return RedirectToPage(LocalRedirection.Animals);
    }
}
