// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Infrastructure.Core.Interfaces;

/// <summary>
/// Provides access to the current authenticated user's information.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets the unique identifier of the current user.
    /// </summary>
    public Guid UserId { get; }
}
