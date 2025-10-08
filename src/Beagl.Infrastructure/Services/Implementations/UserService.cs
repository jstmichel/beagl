// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Models;
using Beagl.Domain.Services;
using Beagl.Domain.Services.Handlers;

namespace Beagl.Infrastructure.Services.Implementations;

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
