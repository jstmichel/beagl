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
public sealed class MedalRecord : AuditedEntity
{
    private MedalRecord(string medalNumber, DateTimeOffset assignedDate, Guid userId, string? reason) : base(userId, assignedDate)
    {
        MedalNumber = medalNumber ?? throw new ArgumentNullException(nameof(medalNumber));
        AssignedDate = assignedDate;
        Reason = reason;
    }

    /// <summary>
    /// Creates a new instance of <see cref="MedalRecord"/>.
    /// </summary>
    /// <param name="medalNumber">The medal number assigned to the animal.</param>
    /// <param name="reason">The reason for the medal assignment (e.g., lost, replaced, new).</param>
    /// <param name="assignedDate">The date the medal was assigned.</param>
    /// <param name="userId">The identifier of the user who created the record.</param>
    public static MedalRecord Create(string medalNumber, DateTimeOffset assignedDate, Guid userId, string? reason = null)
    {
        // Add validation logic as needed
        return new MedalRecord(medalNumber, assignedDate, userId, reason);
    }

    /// <summary>
    /// Gets the medal number assigned to the animal.
    /// </summary>
    public string MedalNumber { get; private set; }

    /// <summary>
    /// Gets the date the medal was assigned.
    /// </summary>
    public DateTimeOffset AssignedDate { get; private set; }

    /// <summary>
    /// Gets the reason for the medal assignment.
    /// </summary>
    public string? Reason { get; private set; }
}
