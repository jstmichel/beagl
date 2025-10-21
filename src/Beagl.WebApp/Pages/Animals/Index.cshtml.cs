// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Beagl.WebApp.Pages.Shared.Models;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;
using Beagl.WebApp.Pages.Animals.ViewModels;
using Beagl.Domain.AnimalManagement.ValueObjects;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for listing animals.
/// </summary>
internal sealed class IndexModel(
    IAnimalQueryService animalQueryService,
    IBreedQueryService breedQueryService,
    IColorQueryService colorQueryService) : PaginatedPageModel<AnimalListDto, IndexModel.AnimalsFilterModel>
{
    /// <summary>
    /// Serves the CreateCat form partial for the modal dialog via AJAX.
    /// </summary>
    public async Task<IActionResult> OnGetCreateCatPartialAsync()
    {
        CreateCatPartialModel model = await BuildCreateCatPartialModel();
        return Partial("_CreateCatPartial", model);
    }

    public async Task<IActionResult> OnPostCreateCatAsync(CreateCatPartialModel model)
    {
        if (!ModelState.IsValid)
        {
            model.BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
            model.ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Cat);
            return Partial("_CreateCatPartial", model);
        }

        // TODO: Save the new cat using model.Cat

        return new JsonResult(new { success = true });
    }

    /// <summary>
    /// Handles the GET request to load the list of animals.
    /// </summary>
    /// <returns>The page result.</returns>
    public async Task<IActionResult> OnGetAsync(int pageNumber = 1)
    {
        await LoadPageAsync(pageNumber);
        return Page();
    }

    /// <summary>
    /// Loads paginated animal data for the page.
    /// </summary>
    /// <param name="pageNumber">The page number to load.</param>
    protected override async Task LoadPageAsync(int pageNumber = 1)
    {
        AnimalPagedFilterDto animalPagedFilterDto = CreatePagedFilterDto(pageNumber);
        (DataModel, TotalItems) = await animalQueryService.GetPagedAsync(animalPagedFilterDto);
        SetPagination(pageNumber);
    }

    private AnimalPagedFilterDto CreatePagedFilterDto(int pageNumber) =>
        new()
        {
            PageNumber = pageNumber,
            PageSize = PageSize,
        };

    private async Task<CreateCatPartialModel> BuildCreateCatPartialModel()
    {
        return new CreateCatPartialModel
        {
            Cat = new(),
            BreedList = await breedQueryService.GetAllBySpeciesAsync(SpeciesType.Cat),
            ColorList = await colorQueryService.GetAllBySpeciesAsync(SpeciesType.Cat)
        };
    }

    /// <summary>
    /// Model for the CreateCat partial view.
    /// </summary>
    internal sealed class CreateCatPartialModel
    {
        public CreateCatViewModel Cat { get; set; } = new();
        public IList<BreedDto> BreedList { get; set; } = [];
        public IList<ColorDto> ColorList { get; set; } = [];
    }

    /// <summary>
    /// Model for filtering animals in the animal management view.
    /// </summary>
    internal sealed class AnimalsFilterModel
    {
    }
}
