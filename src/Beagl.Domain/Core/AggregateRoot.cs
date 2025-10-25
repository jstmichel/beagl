// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core.Interfaces;

namespace Beagl.Domain.Core;

/// <summary>
/// Base class for aggregate roots, inheriting from Entity and implementing IAggregateRoot.
/// </summary>
/// <typeparam name="TId">The type of the aggregate root's identifier.</typeparam>
public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
{
    // Optionally, add domain events or other aggregate-specific logic here.
}

/// <summary>
/// Non-generic base class for aggregate roots with Guid identifiers.
/// </summary>
public abstract class AggregateRoot : AggregateRoot<Guid>
{
}

/// <summary>
/// Base class for audited aggregate roots, inheriting from AuditedEntity and implementing IAggregateRoot.
/// </summary>
/// <typeparam name="TId">The type of the aggregate root's identifier.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="AuditedAggregateRoot{TId}"/> class.
/// </remarks>
public abstract class AuditedAggregateRoot<TId> : AuditedEntity<TId>, IAggregateRoot
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditedAggregateRoot{TId}"/> class.
    /// </summary>
    /// <param name="createdByUserId">The identifier of the user who created the entity.</param>
    /// <param name="createdAt">The date and time when the entity was created.</param>
    protected AuditedAggregateRoot(TId createdByUserId, DateTimeOffset createdAt)
        : base(createdByUserId, createdAt)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditedAggregateRoot{TId}"/> class.
    /// </summary>
    /// <param name="createdByUserId">The identifier of the user who created the entity.</param>
    /// <param name="createdAt">The date and time when the entity was created.</param>
    /// <param name="modifiedByUserId">The identifier of the user who last modified the entity.</param>
    /// <param name="modifiedAt">The date and time when the entity was last modified.</param>
    protected AuditedAggregateRoot(TId createdByUserId, DateTimeOffset createdAt, TId? modifiedByUserId, DateTimeOffset? modifiedAt)
        : base(createdByUserId, createdAt, modifiedByUserId, modifiedAt)
    {
    }
}

/// <summary>
/// Non-generic base class for audited aggregate roots with Guid identifiers.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuditedAggregateRoot"/> class.
/// </remarks>
public abstract class AuditedAggregateRoot : AuditedAggregateRoot<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditedAggregateRoot"/> class
    /// where the modified values default to the created values.
    /// </summary>
    /// <param name="createdByUserId">The identifier of the user who created the entity.</param>
    /// <param name="createdAt">The date and time when the entity was created.</param>
    protected AuditedAggregateRoot(Guid createdByUserId, DateTimeOffset createdAt)
        : base(createdByUserId, createdAt)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditedAggregateRoot"/> class
    /// with explicit modified values.
    /// </summary>
    /// <param name="createdByUserId">The identifier of the user who created the entity.</param>
    /// <param name="createdAt">The date and time when the entity was created.</param>
    /// <param name="modifiedByUserId">The identifier of the user who last modified the entity.</param>
    /// <param name="modifiedAt">The date and time when the entity was last modified.</param>
    protected AuditedAggregateRoot(Guid createdByUserId, DateTimeOffset createdAt, Guid? modifiedByUserId, DateTimeOffset? modifiedAt)
        : base(createdByUserId, createdAt, modifiedByUserId.GetValueOrDefault(), modifiedAt)
    {
    }
}
