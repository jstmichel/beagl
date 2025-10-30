// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Pages.Shared;

/// <summary>
/// ViewModel for the _HeaderWithActions partial view.
/// </summary>
internal sealed class HeaderWithActionsModel
{
    /// <summary>
    /// The title to display in the header.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Whether to show the filter button.
    /// </summary>
    public bool ShowFilterButton { get; set; } = true;

    /// <summary>
    /// The text for the filter button (localization key).
    /// </summary>
    public required string FilterButtonText { get; set; }

    public required ButtonAction CreateAction { get; set; }

    public ICollection<ButtonAction> SubCreateActions { get; set; } = [];
}

/// <summary>
/// Represents a button action with text and link.
/// </summary>
internal sealed class ButtonAction
{
    /// <summary>
    /// The text for the button.
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    /// The URL the button links to.
    /// </summary>
    public required string Link { get; set; }

    /// <summary>
    /// Whether the button is shown.
    /// </summary>
    public bool IsShown { get; set; } = true;
}
