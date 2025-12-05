// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.Core.DTOs;
using Beagl.Domain.Core.Interfaces;

namespace Beagl.Application.CitizenManagement.DTOs;

/// <summary>
/// DTO for citizen paging and filtering parameters.
/// </summary>
public class CitizenPagedFilterDto : PagedRequestDto, IPagedFilter
{
    /// <summary>
    /// Gets or sets the name filter.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the email filter.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number filter.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the street address filter.
    /// </summary>
    public string? StreetAddress { get; set; }

    /// <summary>
    /// Gets or sets the city filter.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Gets or sets the postal code filter.
    /// </summary>
    public string? PostalCode { get; set; }
}
