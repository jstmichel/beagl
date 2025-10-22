// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Beagl.WebApp.Pages.Shared.Models;
using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Application.AnimalManagement.Services;

namespace Beagl.WebApp.Pages.Animals;

/// <summary>
/// Page model for listing animals.
/// </summary>
internal sealed class IndexModel(
    IAnimalQueryService animalQueryService) : PaginatedPageModel<AnimalListDto, IndexModel.AnimalsFilterModel>
{
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

    /// <summary>
    /// Model for filtering animals in the animal management view.
    /// </summary>
    internal sealed class AnimalsFilterModel
    {
    }
}
