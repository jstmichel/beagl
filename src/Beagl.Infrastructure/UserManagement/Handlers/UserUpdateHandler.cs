// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using Beagl.Application.UserManagement.DTOs;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Interfaces;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;
using Microsoft.AspNetCore.Identity;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Handles the update of user information.
/// </summary>
public class UserUpdateHandler(
    IUserQueryService userQueryService,
    UserManager<ApplicationUser> userManager) : IUserUpdateHandler
{
    /// <inheritdoc/>
    public async Task HandleAsync(UserDto user)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(user.Id);
        ApplicationUser userEntity = await userQueryService.FindUserByIdAsync(user.Id);
        await UpdatePhoneNumberAsync(user.PhoneNumber, userEntity);
        await UpdateEmailAsync(user.Email, userEntity);
        await UpdateRolesAsync(user.Roles, userEntity);
    }

    private async Task UpdateRolesAsync(Collection<string> roles, ApplicationUser userEntity)
    {
        await RemoveAllRolesAsync(userEntity);
        await SetRolesAsync(roles, userEntity);
    }

    private async Task RemoveAllRolesAsync(ApplicationUser userEntity)
    {
        IList<string> currentRoles = await userManager.GetRolesAsync(userEntity);
        IdentityResult result = await userManager.RemoveFromRolesAsync(userEntity, currentRoles);
        //IdentityUpdateFailedException.ThrowIfNotSucceeded(result);
    }

    private async Task SetRolesAsync(Collection<string> roles, ApplicationUser userEntity)
    {
        IdentityResult result = await userManager.AddToRolesAsync(userEntity, roles);
        //IdentityUpdateFailedException.ThrowIfNotSucceeded(result);
    }

    private async Task UpdateEmailAsync(string? email, ApplicationUser userEntity)
    {
        IdentityResult emailResult = await userManager.SetEmailAsync(userEntity, email ?? string.Empty);
        //IdentityUpdateFailedException.ThrowIfNotSucceeded(emailResult);
    }

    private async Task UpdatePhoneNumberAsync(string? phoneNumber, ApplicationUser userEntity)
    {
        IdentityResult phoneResult = await userManager.SetPhoneNumberAsync(userEntity, phoneNumber);
        //IdentityUpdateFailedException.ThrowIfNotSucceeded(phoneResult);
    }
}
