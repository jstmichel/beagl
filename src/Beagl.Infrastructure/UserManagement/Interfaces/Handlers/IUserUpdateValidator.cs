// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Infrastructure.UserManagement.DTOs;
using Beagl.Infrastructure.UserManagement.Entities;

namespace Beagl.Infrastructure.UserManagement.Interfaces.Handlers;

/// <summary>
/// Validates user update business rules.
/// </summary>
public interface IUserUpdateValidator
{
    /// <summary>
    /// Validates the user update request.
    /// </summary>
    /// <param name="user">The user data transfer object.</param>
    /// <param name="userEntity">The existing user entity.</param>
    /// <returns>A task representing the asynchronous operation, containing a list of validation errors if any.</returns>
	public Task<IReadOnlyList<(string ErrorCode, string ErrorMessage)>> ValidateAsync(UserDto user, ApplicationUser? userEntity);
}
