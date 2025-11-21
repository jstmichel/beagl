// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.Core.Extensions;
using Beagl.Infrastructure.UserManagement.Entities;
using Beagl.Infrastructure.UserManagement.Interfaces.Handlers;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Default implementation for user deletion validation.
/// </summary>
public class UserDeletionValidator : IUserDeletionValidator
{
    /// <inheritdoc/>
	public Task<IReadOnlyList<(string ErrorCode, string ErrorMessage)>> ValidateAsync(string userId, ApplicationUser? user, int userCount)
	{
        List<(string, string)> errors = [];

		if (string.IsNullOrWhiteSpace(userId))
        {
			errors.Add((InfrastructureErrorCode.UserIdRequired, "User ID must be provided."));
        }

		if (user is null)
        {
			errors.Add((InfrastructureErrorCode.UserNotFound, "User not found."));
        }

		if (userCount <= 1)
        {
			errors.Add((InfrastructureErrorCode.UserCannotDeleteLastUser, "Cannot delete the last user."));
        }

		return Task.FromResult<IReadOnlyList<(string, string)>>(errors);
	}
}
