// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Threading.Tasks;
using Beagl.Domain.Models.Results;

namespace Beagl.Domain.Services;

/// <summary>
/// Defines authentication operations for the application.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Signs out the current user.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task SignOutAsync();

    /// <summary>
    /// Attempts to sign in a user with the provided credentials.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <param name="password">The user's password.</param>
    /// <param name="isPersistent">True to persist the login across browser sessions; otherwise, false.</param>
    /// <returns>A <see cref="AuthenticationResult"/> containing the result of the sign-in attempt.</returns>
    public Task<AuthenticationResult> SignInAsync(string email, string password, bool isPersistent);
}
