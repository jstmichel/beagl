using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beagl.WebApp.Pages.Shared.Models;

/// <summary>
/// Base class for Razor Pages providing common helpers and error handling.
/// </summary>
internal abstract class BasePageModel : PageModel
{
    /// <summary>
    /// Adds a global error message to the model state.
    /// </summary>
    /// <param name="message">The error message.</param>
    protected void AddGlobalError(string message) =>
        ModelState.AddModelError(string.Empty, message);

    /// <summary>
    /// Adds a field-specific error message to the model state.
    /// </summary>
    /// <param name="field">The field name.</param>
    /// <param name="message">The error message.</param>
    protected void AddFieldError(string field, string message) =>
        ModelState.AddModelError(field, message);
}
