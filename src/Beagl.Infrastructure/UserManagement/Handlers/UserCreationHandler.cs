// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.DTOs;
using Beagl.Infrastructure.Core.Helpers;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Mappers;
using Microsoft.AspNetCore.Identity;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Handler for user creation logic.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserCreationHandler"/> class.
/// </remarks>
/// <param name="userManager">The user manager instance.</param>
/// <param name="userCreationValidator">The user creation validator instance.</param>
public class UserCreationHandler(
    UserManager<ApplicationUser> userManager,
    IUserCreationValidator userCreationValidator) : IUserCreationHandler
{
	/// <inheritdoc/>
	public async Task<OperationResult> HandleAsync(UserDto user, string password)
	{
        ArgumentNullException.ThrowIfNull(user);

        ApplicationUser? existingUserByName = await userManager.FindByNameAsync(user.UserName);
		ApplicationUser? existingUserByEmail = await userManager.FindByEmailAsync(user.Email);

        IReadOnlyList<(string ErrorCode, string ErrorMessage)> errors =
            await userCreationValidator.ValidateAsync(user, password, existingUserByName, existingUserByEmail);

        if (errors.Count > 0)
			return OperationResult.Fail(errors);

		ApplicationUser newUser = UserMapper.ToEntity(user);
		IdentityResult createResult = await userManager.CreateAsync(newUser, password);
		if (!createResult.Succeeded)
		{
            List<(string Code, string Description)> identityErrors =
                [.. createResult.Errors.Select(e => (e.Code, e.Description))];
			return OperationResult.Fail(identityErrors);
		}

		IdentityResult rolesResult = await userManager.AddToRolesAsync(newUser, user.Roles);
		if (!rolesResult.Succeeded)
		{
            List<(string Code, string Description)> identityErrors =
                [.. rolesResult.Errors.Select(e => (e.Code, e.Description))];
			return OperationResult.Fail(identityErrors);
		}

		return OperationResult.Ok();
	}
}
