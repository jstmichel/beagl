// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using Beagl.Application.UserManagement.DTOs;
using Beagl.Domain.UserManagement.Exceptions;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;
using Beagl.Infrastructure.UserManagement.Mappers;
using Microsoft.AspNetCore.Identity;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Handler for user creation logic.
/// </summary>
public class UserCreationHandler(
    UserManager<ApplicationUser> userManager) : IUserCreationHandler
{
    /// <inheritdoc/>
    public async Task HandleAsync(UserDto user, string password)
    {
        ValidateUserForCreation(user, password);
        await ValidateUsernameNotExistsAsync(user.UserName);
        await ValidateEmailNotExistsAsync(user.Email);
        await CreateUserAndSetRolesAsync(user, password);
    }

    private async Task ValidateUsernameNotExistsAsync(string? username)
    {
        ArgumentException.ThrowIfNullOrEmpty(username);
        ApplicationUser? existingUser = await userManager.FindByNameAsync(username);
        if (existingUser != null)
        {
            throw new ArgumentException("Username already exists.");
        }
    }

    private async Task ValidateEmailNotExistsAsync(string? email)
    {
        ArgumentException.ThrowIfNullOrEmpty(email);
        ApplicationUser? existingUser = await userManager.FindByEmailAsync(email);
        if (existingUser != null)
        {
            throw new ArgumentException("Email already exists.");
        }
    }

    private static void ValidateUserForCreation(UserDto user, string password)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(user.Roles);
        if (user.Roles.Count == 0)
        {
            throw new ArgumentException("At least one role must be specified.");
        }
    }

    private async Task CreateUserAndSetRolesAsync(UserDto user, string password)
    {
        ApplicationUser newUser = UserMapper.ToEntity(user);
        IdentityResult result = await userManager.CreateAsync(newUser, password);
        IdentityUpdateFailedException.ThrowIfNotSucceeded(result);
        await SetRolesAsync(user.Roles, newUser);
    }

    //TODO: extract to role handler
    private async Task SetRolesAsync(Collection<string> roles, ApplicationUser userEntity)
    {
        IdentityResult result = await userManager.AddToRolesAsync(userEntity, roles);
        IdentityUpdateFailedException.ThrowIfNotSucceeded(result);
    }
}
