// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Pages.Shared;

/// <summary>
/// Model for pagination information used in pagination partial views.
/// </summary>
internal sealed class PaginationModel
{
    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Gets or sets the total number of pages.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// Gets or sets the query parameter name for the page number.
    /// </summary>
    public string PageParameter { get; set; } = "pageNumber";
}
