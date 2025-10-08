// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Exceptions.Entities;
using Beagl.Domain.Exceptions.Users;
using Beagl.Domain.Services.Handlers;
using Beagl.Infrastructure.Entities;
using Beagl.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Beagl.Infrastructure.Services.Implementations.Handlers;

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
            ?? throw new EntityNotFoundException("User not found.");
        int userCount = await userQueryService.GetUserCountAsync();
        if (userCount <= 1)
            throw new LastUserDeleteException("Cannot delete the last user.");

        IdentityResult result = await userManager.DeleteAsync(user);
        IdentityUpdateFailedException.ThrowIfNotSucceeded(result);
    }
}
