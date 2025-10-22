// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.ValueObjects;

/// <summary>
/// Represents audit information for entity creation.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="Audit{TId}"/> class.
/// </remarks>
public class Audit<TId>(TId userId, DateTimeOffset at)
{
    /// <summary>
    /// Gets the user identifier.
    /// </summary>
	public TId UserId { get; private set; } = userId;

    /// <summary>
    /// Gets the timestamp of the audit.
    /// </summary>
	public DateTimeOffset At { get; private set; } = at.ToUniversalTime();
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
    public static Audit<TId>? From<TId>(TId? userId, DateTimeOffset? at)
    {
        if (userId is null || at is null)
            return null;
        return new Audit<TId>(userId, at.Value);
    }
}
