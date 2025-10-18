// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core;

/// <summary>
/// Base class for all entities in the domain, providing identity and equality logic.
/// </summary>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
public abstract class Entity<TId>
{
    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    public TId Id { get; init; } = default!;

    /// <summary>
    /// Determines whether the specified object is equal to the current entity.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
            return false;
        if (ReferenceEquals(this, other))
            return true;
        if (Id is null || other.Id is null)
            return false;
        return Id.Equals(other.Id);
    }

    /// <summary>
    /// Returns a hash code for the entity.
    /// </summary>
    public override int GetHashCode() => Id?.GetHashCode() ?? 0;
}

/// <summary>
/// Non-generic base class for entities with Guid identifiers.
/// </summary>
public abstract class Entity : Entity<Guid>
{
}
