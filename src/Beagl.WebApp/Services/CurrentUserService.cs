// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Security.Claims;
using Beagl.Infrastructure.Core.Interfaces;

namespace Beagl.WebApp.Services;

/// <summary>
/// Implementation of ICurrentUserService for ASP.NET Core.
/// </summary>
internal sealed class CurrentUserService : ICurrentUserService
{
    /// <inheritdoc />
    public Guid UserId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrentUserService"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">Provides access to the current HTTP context.</param>
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        string? userIdString = httpContextAccessor.HttpContext?.User.FindFirstValue(
            ClaimTypes.NameIdentifier);
        UserId = Guid.TryParse(userIdString, out Guid id) ? id : Guid.Empty;
    }
}
