// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Collections.Generic;

namespace Beagl.Domain.Core.ValueObjects;

/// <summary>
/// Represents audit information for entity creation.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Audit{TId}"/> class.
/// </remarks>
public sealed class Audit<TId> : IEquatable<Audit<TId>>
{
    /// <summary>
    /// Gets the user identifier.
    /// </summary>
	public TId UserId { get; }

    /// <summary>
    /// Gets the timestamp of the audit.
    /// </summary>
	public DateTimeOffset At { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Audit{TId}"/> class.
    /// </summary>
    public Audit(TId userId, DateTimeOffset at)
    {
        ArgumentNullException.ThrowIfNull(userId, nameof(userId));
        //TODO: Invalid date exception
        UserId = userId;
        At = at.ToUniversalTime();
    }

    /// <inheritdoc/>
    public bool Equals(Audit<TId>? other)
    {
        if (other is null)
            return false;

        return EqualityComparer<TId>.Default.Equals(UserId, other.UserId) && At == other.At;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as Audit<TId>);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(UserId, At);

    /// <summary>
    /// Equality operator for Audit value objects.
    /// </summary>
    /// <param name="left">The left Audit value.</param>
    /// <param name="right">The right Audit value.</param>
    /// <returns>True if both Audit values are equal; otherwise, false.</returns>
    public static bool operator ==(Audit<TId>? left, Audit<TId>? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Inequality operator for Audit value objects.
    /// </summary>
    /// <param name="left">The left Audit value.</param>
    /// <param name="right">The right Audit value.</param>
    /// <returns>True if both Audit values are not equal; otherwise, false.</returns>
    public static bool operator !=(Audit<TId>? left, Audit<TId>? right)
    {
        return !Equals(left, right);
    }
}

/// <summary>
/// Represents audit information for entity modification.
/// </summary>
public static class Audit
{
    /// <summary>
    /// Creates an Audit value object from the given user identifier and timestamp.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="at">The timestamp of the audit.</param>
    /// <returns>An Audit value object or null if any input is invalid.</returns>
    public static Audit<TId> From<TId>(TId? userId, DateTimeOffset? at)
    {
        if (userId is null || at is null)
            return new Audit<TId>(default!, DateTimeOffset.MinValue);
        return new Audit<TId>(userId, at.Value);
    }
}
