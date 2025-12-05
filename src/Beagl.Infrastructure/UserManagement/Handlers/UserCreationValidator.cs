// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.DTOs;
using Beagl.Infrastructure.Core.Extensions;
using Beagl.Infrastructure.UserManagement.Entities;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Default implementation for user creation validation.
/// </summary>
public class UserCreationValidator : IUserCreationValidator
{
    /// <inheritdoc/>
	public Task<IReadOnlyList<(string ErrorCode, string ErrorMessage)>> ValidateAsync(UserDto user, string password, ApplicationUser? existingUserByName, ApplicationUser? existingUserByEmail)
	{
        List<(string, string)> errors = [];

		if (user == null)
			errors.Add((InfrastructureErrorCode.UserRequired, "User must be provided."));

		if (string.IsNullOrWhiteSpace(password))
			errors.Add((InfrastructureErrorCode.UserPasswordIsInvalid, "Password must be provided."));

		if (user?.Roles == null || user.Roles.Count == 0)
			errors.Add((InfrastructureErrorCode.UserAtLeastOneRoleMustBeSpecified, "At least one role must be specified."));

		if (string.IsNullOrWhiteSpace(user?.UserName))
			errors.Add((InfrastructureErrorCode.UserNameRequired, "Username must be provided."));

		if (existingUserByName != null)
			errors.Add((InfrastructureErrorCode.UserNameAlreadyExists, "Username already exists."));

		if (string.IsNullOrWhiteSpace(user?.Email))
			errors.Add((InfrastructureErrorCode.UserEmailRequired, "Email must be provided."));

		if (existingUserByEmail != null)
			errors.Add((InfrastructureErrorCode.UserEmailAlreadyExists, "Email already exists."));

		return Task.FromResult<IReadOnlyList<(string, string)>>(errors);
	}
}
