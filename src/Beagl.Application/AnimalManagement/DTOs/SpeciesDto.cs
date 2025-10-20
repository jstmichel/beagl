// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// Data transfer object for animal species dropdowns.
/// </summary>
public sealed class SpeciesDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the species.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the species.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
