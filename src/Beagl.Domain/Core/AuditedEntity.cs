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
/// <param name="createdByUserId">The identifier of the user who created the entity.</param>
/// <param name="createdAt">The date and time when the entity was created.</param>
public class AuditedEntity<TId>(TId createdByUserId, DateTimeOffset createdAt) : Entity<TId>
{

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditedEntity{TId}"/> class.
    /// </summary>
    /// <param name="createdByUserId">The identifier of the user who created the entity.</param>
    /// <param name="createdAt">The date and time when the entity was created.</param>
    /// <param name="modifiedByUserId">The identifier of the user who last modified the entity.</param>
    /// <param name="modifiedAt">The date and time when the entity was last modified.</param>
    public AuditedEntity(TId createdByUserId, DateTimeOffset createdAt, TId? modifiedByUserId, DateTimeOffset? modifiedAt)
        : this(createdByUserId, createdAt)
    {
        if (modifiedByUserId != null && modifiedAt != null)
        {
            Modified = new Audit<TId>(modifiedByUserId, modifiedAt.Value);
        }
    }

    /// <summary>
    /// Gets the audit information for creation.
    /// </summary>
    public Audit<TId> Created { get; private set; } = new Audit<TId>(createdByUserId, createdAt);

    /// <summary>
    /// Gets the audit information for last modification.
    /// </summary>
    public Audit<TId>? Modified { get; private set; } = new Audit<TId>(default!, DateTimeOffset.MinValue);

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
public class AuditedEntity(Guid createdByUserId, DateTimeOffset createdAt) : AuditedEntity<Guid>(createdByUserId, createdAt)
{
}
