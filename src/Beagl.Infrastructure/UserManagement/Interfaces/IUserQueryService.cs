// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.UserManagement.DTOs;
using Beagl.Domain.Core.Exceptions;
using Beagl.Domain.Core.Interfaces;
using Beagl.Infrastructure.UserManagement.Entities;

namespace Beagl.Infrastructure.UserManagement.Interfaces;

/// <summary>
/// Service for querying user information.
/// </summary>
public interface IUserQueryService: IPagedService<UserDto, UserPagedFilterDto>
{
    /// <summary>
    /// Gets the total number of users in the system.
    /// </summary>
    /// <returns>A task that returns the total user count.</returns>
    public Task<int> GetUserCountAsync();

    /// <summary>
    /// Gets the total number of users in the system.
    /// </summary>
    /// <param name="query">The query to filter users.</param>
    /// <returns>A task that returns the total user count.</returns>
    public Task<int> GetUserCountAsync(IQueryable<ApplicationUser> query);

    /// <summary>
    /// Finds a user by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>The user entity if found; otherwise, null.</returns>
    /// <exception cref="EntityNotFoundException">Thrown when the user is not found.</exception>
    public Task<ApplicationUser> FindUserByIdAsync(string id);

    /// <summary>
    /// Gets a user by their unique identifier.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <returns>The user.</returns>
    public Task<UserDto> GetByIdAsync(string id);
}
