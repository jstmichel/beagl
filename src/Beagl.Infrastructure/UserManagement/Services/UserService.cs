// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.Core.Helpers;
using Beagl.Application.UserManagement.DTOs;
using Beagl.Domain.Core.Exceptions;
using Beagl.Infrastructure.Core.Helpers;
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
    public async Task<OperationResult> CreateAsync(UserDto user, string password)
    {
        ArgumentNullException.ThrowIfNull(user);

        try
        {
            return await userCreationHandler.HandleAsync(user, password);
        }
        catch (DomainException ex)
        {
            return OperationResult.Fail(ex.ErrorCode, ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<OperationResult> DeleteAsync(string id)
    {
        ArgumentNullException.ThrowIfNull(id);
        try
        {
            return await userDeletionHandler.HandleAsync(id);
        }
        catch (DomainException ex)
        {
            return OperationResult.Fail(ex.ErrorCode, ex.Message);
        }
    }

    /// <inheritdoc/>
    public async Task<OperationResult> UpdateAsync(UserDto user)
    {
        ArgumentNullException.ThrowIfNull(user);
        try
        {
            return await userUpdateHandler.HandleAsync(user);
        }
        catch (DomainException ex)
        {
            return OperationResult.Fail(ex.ErrorCode, ex.Message);
        }
    }
}
