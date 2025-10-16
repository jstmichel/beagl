// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.ValueObjects;

/// <summary>
/// Represents audit information for entity creation.
/// </summary>
/// <typeparam name="TId">The type of the user identifier.</typeparam>
public class Audit<TId>(TId userId, DateTime at)
{
    /// <summary>
    /// Gets or sets the user ID who created the entity.
    /// </summary>
    public TId UserId { get; set; } = userId;


    /// <summary>
    /// Gets or sets the creation date and time.
    /// </summary>
    public DateTime At { get; set; } = at;
}
