using Beagl.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages;

/// <summary>
/// Handles user logout and redirects to the home page.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="LogoutModel"/> class.
/// </remarks>
/// <param name="authenticationService">The authentication service.</param>
internal sealed class LogoutModel(IAuthenticationService authenticationService) : PageModel
{
    /// <summary>
    /// Signs out the current user and redirects to the home page.
    /// </summary>
    /// <returns>A redirect to the home page.</returns>
    public async Task<IActionResult> OnPost()
    {
        await authenticationService.SignOutAsync();
        return RedirectToPage("/Index");
    }
}
