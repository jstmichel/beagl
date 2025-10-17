// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Application.Core.DTOs;

/// <summary>
/// Base class for DTOs with audit fields.
/// </summary>
public abstract class AuditedDtoBase
{
    /// <summary>
    /// Gets or sets the audit creation date.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the audit creator's user id.
    /// </summary>
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// Gets or sets the audit modification date.
    /// </summary>
    public DateTimeOffset ModifiedAt { get; set; }

    /// <summary>
    /// Gets or sets the audit modifier's user id.
    /// </summary>
    public Guid ModifiedByUserId { get; set; }
}
