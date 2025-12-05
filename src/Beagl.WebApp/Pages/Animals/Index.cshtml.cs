// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Beagl.WebApp.Pages.Shared.Models;
using Beagl.WebApp.Pages.Animals.ViewModels;
using Beagl.WebApp.Mappers;
using Beagl.WebApp.Constants;
using Microsoft.AspNetCore.Authorization;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Infrastructure.AnimalManagement.DTOs;
using Beagl.Infrastructure.AnimalManagement.Services;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for listing animals.
/// </summary>
[Authorize(Policy = Policies.Animals.CanView)]
internal sealed class IndexModel(
    IBreedQueryService breedQueryService,
    IColorQueryService colorQueryService,
    IAnimalQueryService animalQueryService) : PaginatedPageModel<ListAnimalsViewModel, IndexModel.AnimalsFilterModel>
{
    public IEnumerable<BreedDto> AllBreedList { get; set; } = [];
    public IEnumerable<ColorDto> AllColorList { get; set; } = [];

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
        await LoadDropdownListsAsync();
        AnimalPagedFilterDto animalPagedFilterDto = CreatePagedFilterDto(pageNumber);
        (IList<AnimalListDto>? dto, TotalItems) = await animalQueryService.GetPagedAsync(animalPagedFilterDto);
        DataModel = MapDtoToViewModelList(dto);
        SetPagination(pageNumber);
    }

    private static List<ListAnimalsViewModel> MapDtoToViewModelList(IList<AnimalListDto>? dto)
    {
        if (dto == null) return [];
        return [.. dto.Select(animal => animal.ToViewModel())];
    }

    private AnimalPagedFilterDto CreatePagedFilterDto(int pageNumber) =>
        new()
        {
            PageNumber = pageNumber,
            PageSize = PageSize,
            Name = FilterModel.Name,
            Species = FilterModel.Species,
            PrimaryBreed = FilterModel.PrimaryBreed,
            Color = FilterModel.Color,
            Gender = FilterModel.Gender,
            MicrochipNumber = FilterModel.MicrochipNumber,
            PermitNumber = FilterModel.PermitNumber
        };

    private async Task LoadDropdownListsAsync()
    {
        AllBreedList = await breedQueryService.GetAllAsync();
        AllColorList = await colorQueryService.GetAllAsync();
    }

    /// <summary>
    /// Model for filtering animals in the animal management view.
    /// </summary>
    internal sealed class AnimalsFilterModel
    {
        public string? Name { get; set; }

        public SpeciesType? Species { get; set; }

        public Guid? PrimaryBreed { get; set; }

        public Guid? Color { get; set; }

        public Gender? Gender { get; set; }

        public string? MicrochipNumber { get; set; }

        public string? PermitNumber { get; set; }
    }
}
