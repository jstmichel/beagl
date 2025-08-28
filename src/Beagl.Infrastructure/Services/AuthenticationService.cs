// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Models.Results;
using Beagl.Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace Beagl.Infrastructure.Services;

/// <summary>
/// Provides authentication operations using ASP.NET Core Identity.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuthenticationService"/> class.
/// </remarks>
/// <param name="signInManager">The ASP.NET Core Identity SignInManager.</param>
public sealed class AuthenticationService(
    SignInManager<IdentityUser> signInManager)
    : IAuthenticationService
{
    private const bool _lockoutOnFailure = true;
    /// <inheritdoc />
    public async Task<AuthenticationResult> SignInAsync(
        string email,
        string password,
        bool isPersistent)
    {
        SignInResult result = await signInManager.PasswordSignInAsync(
            email, password, isPersistent, _lockoutOnFailure);

        return new AuthenticationResult
        {
            Succeeded = result.Succeeded,
        };
    }
}
