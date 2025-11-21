// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.UserManagement.DTOs;
using Beagl.Infrastructure.Core.Helpers;

namespace Beagl.Infrastructure.UserManagement.Interfaces.Handlers;

/// <summary>
/// Handles the update of user information.
/// </summary>
public interface IUserUpdateHandler
{
    /// <summary>
    /// Handles the user update process.
    /// </summary>
    /// <param name="user">The user data transfer object containing updated user details.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<OperationResult> HandleAsync(UserDto user);
}
