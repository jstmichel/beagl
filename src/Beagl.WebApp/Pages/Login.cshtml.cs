using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Beagl.WebApp.Pages;

/// <summary>
/// Represents the login page model for handling user authentication.
/// </summary>
internal sealed class LoginModel(IStringLocalizer<LoginModel> localizer) : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "EmailRequired")]
    [EmailAddress(ErrorMessage = "InvalidEmail")]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "PasswordRequired")]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    public bool RememberMe { get; set; }

    /// <summary>
    /// Handles the POST request for the login page.
    /// Validates the model and adds an error if authentication fails.
    /// </summary>
    /// <returns>The page result.</returns>
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        ModelState.AddModelError(string.Empty, localizer["EmailOrPasswordInvalid"]);
        return Page();
    }
}
