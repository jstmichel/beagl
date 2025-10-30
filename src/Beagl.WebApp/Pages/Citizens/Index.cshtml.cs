// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;
using Beagl.WebApp.Pages.Shared.Models;
using Beagl.WebApp.Pages.Citizens.ViewModels;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Application.CitizenManagement.DTOs;
using Beagl.WebApp.Mappers;
using Microsoft.AspNetCore.Authorization;
using Beagl.WebApp.Constants;

namespace Beagl.WebApp.Pages.Citizens;

/// <summary>
/// Page model for listing citizens.
/// </summary>
[Authorize(Policy = Policies.Citizens.CanView)]
internal sealed class IndexModel(
    ICitizenQueryService citizenQueryService) : PaginatedPageModel<ListCitizensViewModel, IndexModel.CitizenFilterModel>
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
        CitizenPagedFilterDto citizensPagedFilterDto = CreatePagedFilterDto(pageNumber);
        (IList<CitizenListDto>? dto, TotalItems) = await citizenQueryService.GetPagedAsync(citizensPagedFilterDto);
        DataModel = MapDtoToViewModelList(dto);
        SetPagination(pageNumber);
    }

    private static List<ListCitizensViewModel> MapDtoToViewModelList(IList<CitizenListDto>? dto)
    {
        if (dto == null) return [];
        return [.. dto.Select(citizen => citizen.ToViewModel())];
    }

    private CitizenPagedFilterDto CreatePagedFilterDto(int pageNumber) =>
        new()
        {
            PageNumber = pageNumber,
            PageSize = PageSize,
        };

    /// <summary>
    /// Model for filtering citizens in the citizen management view.
    /// </summary>
    internal sealed class CitizenFilterModel
    {
    }
}
