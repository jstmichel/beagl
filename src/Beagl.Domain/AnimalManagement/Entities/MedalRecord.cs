// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Represents a record of a medal assignment for an animal.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="MedalRecord"/> class.
/// </remarks>
public sealed class MedalRecord(
    string medalNumber,
    DateTime assignedDate,
    Guid animalId,
    Guid userId,
    string? reason = null) : AuditedEntity(userId, DateTime.UtcNow)
{
    /// <summary>
    /// Gets the medal number assigned to the animal.
    /// </summary>
    public string MedalNumber { get; private set; } = medalNumber ?? throw new ArgumentNullException(nameof(medalNumber));

    /// <summary>
    /// Gets the date the medal was assigned.
    /// </summary>
    public DateTime AssignedDate { get; private set; } = assignedDate;
    /// <summary>
    /// Gets the foreign key to the associated animal.
    /// </summary>
    public Guid AnimalId { get; private set; } = animalId;

    /// <summary>
    /// Gets the navigation property to the associated animal.
    /// </summary>
    public Animal? Animal { get; private set; }

    /// <summary>
    /// Gets the reason for the medal assignment (e.g., lost, replaced, new).
    /// </summary>
    public string? Reason { get; private set; } = reason;

    /// <summary>
    /// For EF Core only.
    /// </summary>
    private MedalRecord() : this(default!, default, default, default) { }
}
