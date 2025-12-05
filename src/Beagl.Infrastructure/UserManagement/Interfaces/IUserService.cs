// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.UserManagement.DTOs;
using Beagl.Infrastructure.Core.Helpers;

namespace Beagl.Infrastructure.UserManagement.Interfaces;

/// <summary>
/// Defines CRUD operations for application users.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Creates a new user with the specified password and role.
    /// </summary>
    /// <param name="user">The user to create.</param>
    /// <param name="password">The user's password.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<OperationResult> CreateAsync(UserDto user, string password);

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="user">The user to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<OperationResult> UpdateAsync(UserDto user);

    /// <summary>
    /// Deletes a user account.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<OperationResult> DeleteAsync(string id);
}
