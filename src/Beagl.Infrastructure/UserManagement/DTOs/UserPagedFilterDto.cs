// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.DTOs;
using Beagl.Domain.Core.Interfaces;

namespace Beagl.Infrastructure.UserManagement.DTOs;

/// <summary>
/// DTO for user paging and filtering parameters.
/// </summary>
public sealed class UserPagedFilterDto : PagedRequestDto, IPagedFilter
{
    /// <summary>
    /// Gets or sets the username filter.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Gets or sets the email filter.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the phone filter.
    /// </summary>
    public string? Phone { get; set; }
}
