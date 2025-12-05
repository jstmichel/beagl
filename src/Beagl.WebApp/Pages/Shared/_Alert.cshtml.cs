// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Pages.Shared;

/// <summary>
/// Model for displaying a Bootstrap alert.
/// </summary>
internal sealed class AlertModel
{
    /// <summary>
    /// Gets or sets a value indicating whether the alert should be shown.
    /// </summary>
    public bool Show { get; set; }

    /// <summary>
    /// Gets or sets the alert text (already localized).
    /// </summary>
    public string Text { get; set; } = string.Empty;
}
