namespace Beagl.Domain.Models;

/// <summary>
/// DTO for paged request parameters.
/// </summary>
public class PagedRequestDto
{
    /// <summary>
    /// Gets or sets the page number.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Gets or sets the page size.
    /// </summary>
    public int PageSize { get; set; } = 20;
}
