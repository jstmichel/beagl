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
/// <typeparam name="TId"></typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="AuditedAggregateRoot{TId}"/> class.
/// </remarks>
/// <param name="userId">The identifier of the user who created the entity.</param>
/// <param name="createdAt">The creation date and time.</param>
public abstract class AuditedAggregateRoot<TId>(TId userId, DateTimeOffset createdAt) : AuditedEntity<TId>(userId, createdAt), IAggregateRoot
{
}

/// <summary>
/// Non-generic base class for audited aggregate roots with Guid identifiers.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AuditedAggregateRoot"/> class.
/// </remarks>
/// <param name="userId">The identifier of the user who created the entity.</param>
/// <param name="createdAt">The creation date and time.</param>
public abstract class AuditedAggregateRoot(Guid userId, DateTimeOffset createdAt) : AuditedAggregateRoot<Guid>(userId, createdAt)
{
}
