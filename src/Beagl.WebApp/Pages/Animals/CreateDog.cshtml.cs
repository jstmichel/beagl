// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Domain.Core.Exceptions;
using Beagl.WebApp.Constants;
using Beagl.WebApp.Mappers;
using Beagl.WebApp.Pages.Animals.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for creating a new dog.
/// </summary>
[Authorize(Policy = Policies.Animals.CanCreate)]
internal sealed class CreateDogModel(
    IBreedQueryService breedQueryService,
    IColorQueryService colorQueryService,
    IDogService dogService,
    ICitizenQueryService citizenQueryService) : PageModel
{
    /// <summary>
    /// Gets or sets the input model for creating a dog.
    /// </summary>
    [BindProperty]
    public CreateDogViewModel Input { get; set; } = new CreateDogViewModel();
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

        CreateDogDto dto = Input.ToDto();
        try
        {
            _ = await dogService.CreateDogAsync(dto);
        }
        catch(DomainException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            await LoadDropdownListsAsync();
            return Page();
        }

        return RedirectToPage(Redirection.ToAnimalList);
    }

    private async Task LoadDropdownListsAsync()
    {
        BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Dog);
        ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Dog);
        CitizenList = await citizenQueryService.GetAllLookupAsync();
    }
}
