// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.UserManagement.DTOs;
using Beagl.Infrastructure.Core.Extensions;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Default implementation for user update validation.
/// </summary>
public class UserUpdateValidator : IUserUpdateValidator
{
    /// <inheritdoc/>
	public Task<IReadOnlyList<(string ErrorCode, string ErrorMessage)>> ValidateAsync(UserDto user, ApplicationUser? userEntity)
	{
        List<(string, string)> errors = [];

		if (user == null)
			errors.Add((InfrastructureErrorCode.UserRequired, "User must be provided."));

		if (user?.Id == null)
			errors.Add((InfrastructureErrorCode.UserIdRequired, "User ID must be provided."));

		if (userEntity == null)
			errors.Add((InfrastructureErrorCode.UserNotFound, "User not found."));

		return Task.FromResult<IReadOnlyList<(string, string)>>(errors);
	}
}
