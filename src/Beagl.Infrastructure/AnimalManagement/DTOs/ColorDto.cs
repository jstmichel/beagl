// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Infrastructure.AnimalManagement.DTOs;

/// <summary>
/// Data transfer object for animal color dropdowns.
/// </summary>
public sealed class ColorDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the color.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the color.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
