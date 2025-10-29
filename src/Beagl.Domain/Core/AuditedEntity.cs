// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Diagnostics.Contracts;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Domain.Core;

/// <summary>
/// Represents an entity with audit information for creation and modification.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuditedEntity{TId}"/> class.
/// </remarks>
/// <param name="created">The audit information for creation.</param>
public class AuditedEntity<TId>(Audit<TId> created) : Entity<TId>
{
    /// <summary>
    /// Gets the audit information for creation.
    /// </summary>
    public Audit<TId> Created { get; private set; } = created;

    /// <summary>
    /// Gets the audit information for last modification.
    /// </summary>
    public Audit<TId>? Modified { get; private set; }

    /// <summary>
    /// Private parameterless constructor for EF Core.
    /// </summary>
    protected AuditedEntity() : this(default!) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditedEntity{TId}"/> class.
    /// </summary>
    /// <param name="created">The audit information for creation.</param>
    /// <param name="modified">The audit information for last modification.</param>
    public AuditedEntity(Audit<TId> created, Audit<TId>? modified = null)
        : this(created)
    {
        if (modified != null)
        {
            Modified = modified;
        }
    }

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
/// <param name="created">The audit information for creation.</param>
public class AuditedEntity(Audit<Guid> created) : AuditedEntity<Guid>(created)
{
}
