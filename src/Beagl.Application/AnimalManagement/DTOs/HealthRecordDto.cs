// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core.DTOs;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// Data transfer object for a health record entry.
/// </summary>
public class HealthRecordDto : AuditedDtoBase
{
    /// <summary>
    /// Gets or sets the health record identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets whether the animal is sterilized.
    /// </summary>
    public bool IsSterilized { get; set; }

    /// <summary>
    /// Gets or sets the animal's weight value (kg).
    /// </summary>
    public decimal? WeightValue { get; set; }

    /// <summary>
    /// Gets or sets the animal's weight unit (e.g., kg).
    /// </summary>
    public string? WeightUnit { get; set; }

    /// <summary>
    /// Gets or sets the date of the last rabies vaccination.
    /// </summary>
    public DateTime? RabiesVaccinationDate { get; set; }
}
