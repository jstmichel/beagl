// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Infrastructure.AnimalManagement.Models;

/// <summary>
/// Persistence model for MedalRecord.
/// </summary>
public class MedalRecordEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the medal record.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the medal number assigned to the animal.
    /// </summary>
    public string MedalNumber { get; set; } = default!;

    /// <summary>
    /// Gets or sets the date the medal was assigned.
    /// </summary>
    public DateTimeOffset AssignedDate { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to the associated animal.
    /// </summary>
    public Guid AnimalId { get; set; }

    /// <summary>
    /// Gets or sets the reason for the medal assignment (e.g., lost, replaced, new).
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// Gets the audit information for creation.
    /// </summary>
    public Audit<Guid>? Created { get; set; }

    /// <summary>
    /// Gets the audit information for last modification.
    /// </summary>
    public Audit<Guid>? Modified { get; set; }

    /// <summary>
    /// Gets or sets the navigation property to the associated animal.
    /// </summary>
    public AnimalEntity? Animal { get; set; }
}
