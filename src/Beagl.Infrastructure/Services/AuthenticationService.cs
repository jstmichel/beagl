// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Models.Results;
using Beagl.Domain.Services;
using Beagl.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Beagl.Infrastructure.Services;

/// <summary>
/// Provides authentication operations using ASP.NET Core Identity.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuthenticationService"/> class.
/// </remarks>
/// <param name="signInManager">The ASP.NET Core Identity SignInManager.</param>
/// <param name="userManager">The ASP.NET Core Identity UserManager.</param>
public sealed class AuthenticationService(
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager) : IAuthenticationService
{
    private const bool _lockoutOnFailure = true;

    /// <inheritdoc />
    public async Task<AuthenticationResult> SignInAsync(
        string email,
        string password,
        bool isPersistent)
    {
        bool userExistsAndIsEnabled = await UserExistsAndIsEnabledAsync(email);

        if (!userExistsAndIsEnabled)
        {
            return new AuthenticationResult { Succeeded = false };
        }

        SignInResult result = await signInManager.PasswordSignInAsync(
            email, password, isPersistent, _lockoutOnFailure);

        bool succeeded = result != null && result.Succeeded;

        return new AuthenticationResult { Succeeded = succeeded };
    }

    /// <summary>
    /// Finds the user by email and checks if the user exists and is enabled.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <returns><c>true</c> if the user exists and is enabled; otherwise, <c>false</c>.</returns>
    private async Task<bool> UserExistsAndIsEnabledAsync(string email)
    {
        ApplicationUser? user = await userManager.FindByEmailAsync(email);
        return user != null && !user.IsDeleted;
    }

    /// <inheritdoc />
    public async Task SignOutAsync() => await signInManager.SignOutAsync();
}
