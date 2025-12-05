// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Infrastructure.CitizenManagement.DTOs;

/// <summary>
/// ViewModel for displaying a list of citizens.
/// </summary>
public class CitizenLookupDto
{
    /// <summary>
    /// Gets the unique identifier of the citizen.
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Gets the civility of the citizen.
    /// </summary>
    public required string Civility { get; init; }

    /// <summary>
    /// Gets the full name of the citizen.
    /// </summary>
    public required string Name { get; init; }
}
