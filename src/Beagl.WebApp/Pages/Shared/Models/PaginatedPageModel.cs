// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc;

namespace Beagl.WebApp.Pages.Shared.Models;

/// <summary>
/// Abstract base class for paginated Razor Pages.
/// Provides common pagination properties and methods.
/// </summary>
internal abstract class PaginatedPageModel<Data, Filter> : BasePageModel
    where Filter : new()
{
    /// <summary>
    /// The current page number.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// The total number of pages.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// The number of items per page.
    /// </summary>
    public int PageSize { get; set; } = 25;

    /// <summary>
    /// The total number of items.
    /// </summary>
    public int TotalItems { get; set; }

    /// <inheritdoc/>
    [BindProperty(SupportsGet = true)]
    public Filter FilterModel { get; set; } = new Filter();

    public IList<Data> DataModel { get; protected set; } = [];

    /// <summary>
    /// Loads paginated data for the page.
    /// </summary>
    /// <param name="pageNumber">The page number to load.</param>
    protected abstract Task LoadPageAsync(int pageNumber = 1);

    protected void SetPagination(int pageNumber)
    {
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);
    }
}
