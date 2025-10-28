// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core.Interfaces;
using Beagl.Domain.Core.ValueObjects;

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
    /// <param name="created">The audit information for creation.</param>
    protected AuditedAggregateRoot(Audit<TId> created)
        : base(created)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditedAggregateRoot{TId}"/> class.
    /// </summary>
    /// <param name="created">The audit information for creation.</param>
    /// <param name="modified">The audit information for last modification.</param>
    protected AuditedAggregateRoot(Audit<TId> created, Audit<TId>? modified = null)
        : base(created, modified)
    {
    }

    /// <summary>
    /// Private parameterless constructor for EF Core.
    /// </summary>
    protected AuditedAggregateRoot() { }
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
    /// <param name="created">The audit information for creation.</param>
    protected AuditedAggregateRoot(Audit<Guid> created)
        : base(created)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AuditedAggregateRoot"/> class
    /// with explicit modified values.
    /// </summary>
    /// <param name="created">The audit information for creation.</param>
    /// <param name="modified">The audit information for last modification.</param>
    protected AuditedAggregateRoot(Audit<Guid> created, Audit<Guid>? modified = null)
        : base(created, modified)
    {
    }

    /// <summary>
    /// Private parameterless constructor for EF Core.
    /// </summary>
    protected AuditedAggregateRoot() { }
}
