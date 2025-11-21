// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.Exceptions;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;
using Microsoft.AspNetCore.Identity;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Handler for user deletion logic.
/// </summary>
public class UserDeletionHandler(
    UserManager<ApplicationUser> userManager,
    IUserQueryService userQueryService) : IUserDeletionHandler
{
    /// <inheritdoc/>
    public async Task HandleAsync(string userId)
    {
        ArgumentException.ThrowIfNullOrEmpty(userId);

        ApplicationUser? user = await userManager.FindByIdAsync(userId)
            ?? throw new DomainException(DomainErrorCode.UserNotFound, "User not found.");
        int userCount = await userQueryService.GetUserCountAsync();
        if (userCount <= 1)
            throw new DomainException(DomainErrorCode.UserCannotDeleteLastUser, "Cannot delete the last user.");

        IdentityResult result = await userManager.DeleteAsync(user);
        //IdentityUpdateFailedException.ThrowIfNotSucceeded(result);
    }
}
