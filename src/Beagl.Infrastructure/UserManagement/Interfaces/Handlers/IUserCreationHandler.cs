// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.DTOs;

namespace Beagl.Infrastructure.UserManagement.Interfaces.Handlers;

/// <summary>
/// Handler for user creation logic.
/// </summary>
public interface IUserCreationHandler
{
    /// <summary>
    /// Handles the creation of a new user with the specified password.
    /// </summary>
    /// <param name="user">The user data transfer object containing user information.</param>
    /// <param name="password">The password for the new user.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task HandleAsync(UserDto user, string password);
}
