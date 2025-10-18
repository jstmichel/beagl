// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Represents a supported animal species in the domain.
/// </summary>
public sealed class Species : Entity
{
    /// <summary>
    /// Gets the name of the species.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a value indicating whether the species is active.
    /// </summary>
    public bool IsActive { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Species"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the species.</param>
    /// <param name="name">The name of the species.</param>
    /// <param name="isActive">Indicates whether the species is active.</param>
    public Species(Guid id, string name, bool isActive)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
    }
}
