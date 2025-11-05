// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Pages.Citizens.ViewModels;

/// <summary>
/// ViewModel for displaying a list of citizens.
/// </summary>
public class ListCitizensViewModel
{
    /// <summary>
    /// Gets the unique identifier of the citizen.
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Gets the full name of the citizen.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
	/// Phone number.
	/// </summary>
	public string? Phone { get; set; }

    /// <summary>
    /// Cell phone number.
    /// </summary>
    public string? CellPhone { get; set; }

    /// <summary>
    /// Gets the email address of the citizen.
    /// </summary>
    public string? Email { get; init; } = string.Empty;

    /// <summary>
    /// Gets the number of animals associated with the citizen.
    /// </summary>
    public int AnimalsCount { get; init; }

    /// <summary>
    /// Gets the most recent address of the citizen.
    /// </summary>
    public string? Address { get; init; }
}
