// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.Entities;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Validates user deletion business rules.
/// </summary>
public interface IUserDeletionValidator
{
    /// <summary>
    /// Validates the user deletion request.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to delete.</param>
    /// <param name="user">The user entity to delete.</param>
    /// <param name="userCount">The total number of users in the system.</param>
    /// <returns>A task representing the asynchronous operation, containing a list of validation errors if any.</returns>
	public Task<IReadOnlyList<(string ErrorCode, string ErrorMessage)>> ValidateAsync(string userId, ApplicationUser? user, int userCount);
}
