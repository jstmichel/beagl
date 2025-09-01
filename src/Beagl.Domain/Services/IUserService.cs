// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.Generic;
using System.Threading.Tasks;
using Beagl.Domain.Models;

namespace Beagl.Domain.Services;

/// <summary>
/// Defines CRUD operations for application users.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Gets all users in the system.
    /// </summary>
    /// <returns>A collection of users.</returns>
    public Task<IEnumerable<UserDto>> GetAllAsync();

    /// <summary>
    /// Gets a user by their unique identifier.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <returns>The user, or null if not found.</returns>
    public Task<UserDto?> GetByIdAsync(string id);

    /// <summary>
    /// Creates a new user with the specified password and role.
    /// </summary>
    /// <param name="user">The user to create.</param>
    /// <param name="password">The user's password.</param>
    /// <param name="role">The role to assign.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task CreateAsync(UserDto user, string password, string role);

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="user">The user to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task UpdateAsync(UserDto user);

    /// <summary>
    /// Deactivates a user account.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task DeactivateAsync(string id);

    /// <summary>
    /// Deletes a user account.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task DeleteAsync(string id);

    /// <summary>
    /// Sends an invitation to the user to activate their account.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task SendInvitationAsync(string id);
}
