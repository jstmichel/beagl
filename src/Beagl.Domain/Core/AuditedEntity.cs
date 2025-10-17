// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Diagnostics.Contracts;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.Core;

/// <summary>
/// Represents an entity with audit information for creation and modification.
/// </summary>
public class AuditedEntity<TId>(TId userId, DateTimeOffset at) : Entity<TId>
{
    /// <summary>
    /// Gets the audit information for creation.
    /// </summary>
    public Audit<TId> Created { get; private set; } = new Audit<TId>(userId, at);

    /// <summary>
    /// Gets the audit information for last modification.
    /// </summary>
    public Audit<TId>? Modified { get; private set; }

    /// <summary>
    /// Sets the modification audit information.
    /// </summary>
    /// <param name="userId">The user ID who modified the entity.</param>
    /// <param name="at">The date and time of modification.</param>
    public void SetCreatedAudit(TId userId, DateTimeOffset at)
    {
        Contract.Requires(userId != null);
        Contract.Requires(at != default);

        if (Created != null)
        {
            throw new InvalidOperationException("Creation audit has already been set and cannot be modified.");
        }

        Created = new Audit<TId>(userId, at);
    }

    /// <summary>
    /// Sets the modification audit information.
    /// </summary>
    /// <param name="userId">The user ID who modified the entity.</param>
    /// <param name="at">The date and time of modification.</param>
    public void SetModifiedAudit(TId userId, DateTimeOffset at)
    {
        Contract.Requires(userId != null);
        Contract.Requires(at != default);

        Modified = new Audit<TId>(userId, at);
    }
}

/// <summary>
/// Represents an entity with audit information for creation and modification, using Guid as the identifier type.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuditedEntity"/> class.
/// </remarks>
/// <param name="userId">The user ID who modified the entity.</param>
/// <param name="at">The date and time of modification.</param>
public class AuditedEntity(Guid userId, DateTimeOffset at) : AuditedEntity<Guid>(userId, at)
{
}
