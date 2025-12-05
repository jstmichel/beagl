// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;
using Beagl.Infrastructure.Core.Helpers;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Handler for user deletion logic.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserDeletionHandler"/> class.
/// </remarks>
public class UserDeletionHandler(
    UserManager<ApplicationUser> userManager,
    IUserQueryService userQueryService,
    IUserDeletionValidator userDeletionValidator) : IUserDeletionHandler
{
    /// <inheritdoc/>
    public async Task<OperationResult> HandleAsync(string userId)
    {
        ApplicationUser? user = await userManager.FindByIdAsync(userId);
        int userCount = await userQueryService.GetUserCountAsync();

        IReadOnlyList<(string ErrorCode, string ErrorMessage)> errors =
            await userDeletionValidator.ValidateAsync(userId, user, userCount);

        if (errors.Count > 0)
        {
            return OperationResult.Fail(errors);
        }

        IdentityResult result = await userManager.DeleteAsync(user!);
        if (!result.Succeeded)
        {
            List<(string Code, string Description)> identityErrors =
                [.. result.Errors.Select(e => (e.Code, e.Description))];
            return OperationResult.Fail(identityErrors);
        }

        return OperationResult.Ok();
    }
}
