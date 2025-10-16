// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.UserManagement.DTOs;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;

namespace Beagl.Infrastructure.UserManagement.Services;

/// <summary>
/// Provides user management operations such as creation, deletion, retrieval, and updates.
/// Implements the <see cref="IUserService"/> interface for accessing and managing user data.
/// </summary>
public class UserService(
    IUserCreationHandler userCreationHandler,
    IUserDeletionHandler userDeletionHandler,
    IUserUpdateHandler userUpdateHandler) : IUserService
{
    /// <inheritdoc/>
    public async Task CreateAsync(UserDto user, string password)
    {
        await userCreationHandler.HandleAsync(user, password);
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(string id)
    {
        await userDeletionHandler.HandleAsync(id);
    }

    /// <inheritdoc/>
    public Task SendInvitationAsync(string id) => throw new NotImplementedException();

    /// <inheritdoc/>
    public async Task UpdateAsync(UserDto user)
    {
        await userUpdateHandler.HandleAsync(user);
    }
}
