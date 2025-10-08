// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Threading.Tasks;
using Beagl.Domain.Models;

namespace Beagl.Domain.Services.Handlers;

/// <summary>
/// Handles the update of user information.
/// </summary>
public interface IUserUpdateHandler
{
    /// <summary>
    /// Handles the user update process.
    /// </summary>
    /// <param name="user">The user data transfer object containing updated user details.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task HandleAsync(UserDto user);
}
