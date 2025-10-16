// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core.DTOs;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// Data transfer object for a medal assignment record.
/// </summary>
public class MedalRecordDto : AuditedDtoBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the medal record.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the medal number assigned to the animal.
    /// </summary>
    public string MedalNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date the medal was assigned.
    /// </summary>
    public DateTime AssignedDate { get; set; }

    /// <summary>
    /// Gets or sets the reason for the medal assignment (e.g., lost, replaced, new).
    /// </summary>
    public string? Reason { get; set; }
}
