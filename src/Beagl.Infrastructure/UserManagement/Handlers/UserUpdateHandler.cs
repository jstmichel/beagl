// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.DTOs;
using Beagl.Infrastructure.Core.Helpers;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;
using Microsoft.AspNetCore.Identity;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Handles the update of user information.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserUpdateHandler"/> class.
/// </remarks>
public class UserUpdateHandler(
    IUserQueryService userQueryService,
    UserManager<ApplicationUser> userManager,
    IUserUpdateValidator userUpdateValidator) : IUserUpdateHandler
{
    /// <inheritdoc/>
    public async Task<OperationResult> HandleAsync(UserDto user)
    {
        ArgumentNullException.ThrowIfNull(user);

        ApplicationUser? userEntity = null;
        if (user != null && user.Id != null)
            userEntity = await userQueryService.FindUserByIdAsync(user.Id);

        IReadOnlyList<(string ErrorCode, string ErrorMessage)> errors = await userUpdateValidator.ValidateAsync(user!, userEntity);
        if (errors.Count > 0)
            return OperationResult.Fail(errors);

        List<(string, string)> allErrors = [];

        IdentityResult phoneResult = await userManager.SetPhoneNumberAsync(userEntity!, user!.PhoneNumber);
        if (!phoneResult.Succeeded)
            allErrors.AddRange(phoneResult.Errors.Select(e => (e.Code, e.Description)));

        IdentityResult emailResult = await userManager.SetEmailAsync(userEntity!, user.Email ?? string.Empty);
        if (!emailResult.Succeeded)
            allErrors.AddRange(emailResult.Errors.Select(e => (e.Code, e.Description)));

        IdentityResult rolesRemoveResult = await RemoveAllRolesAsync(userEntity!);
        if (!rolesRemoveResult.Succeeded)
            allErrors.AddRange(rolesRemoveResult.Errors.Select(e => (e.Code, e.Description)));

        IdentityResult rolesAddResult = await userManager.AddToRolesAsync(userEntity!, user.Roles);
        if (!rolesAddResult.Succeeded)
            allErrors.AddRange(rolesAddResult.Errors.Select(e => (e.Code, e.Description)));

        if (allErrors.Count > 0)
            return OperationResult.Fail(allErrors);

        return OperationResult.Ok();
    }

    private async Task<IdentityResult> RemoveAllRolesAsync(ApplicationUser userEntity)
    {
        IList<string> currentRoles = await userManager.GetRolesAsync(userEntity);
        return await userManager.RemoveFromRolesAsync(userEntity, currentRoles);
    }
}
