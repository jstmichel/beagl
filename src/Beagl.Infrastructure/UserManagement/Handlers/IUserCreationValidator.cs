// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.DTOs;
using Beagl.Infrastructure.UserManagement.Entities;

namespace Beagl.Infrastructure.UserManagement.Handlers;

/// <summary>
/// Validates user creation business rules.
/// </summary>
public interface IUserCreationValidator
{
    /// <summary>
    /// Validates the user creation request.
    /// </summary>
    /// <param name="user">The user data transfer object.</param>
    /// <param name="password">The password for the new user.</param>
    /// <param name="existingUserByName">An existing user with the same username, if any.</param>
    /// <param name="existingUserByEmail">An existing user with the same email, if any.</param>
    /// <returns>A task representing the asynchronous operation, containing a list of validation errors if any.</returns>
	public Task<IReadOnlyList<(string ErrorCode, string ErrorMessage)>> ValidateAsync(UserDto user, string password, ApplicationUser? existingUserByName, ApplicationUser? existingUserByEmail);
}
