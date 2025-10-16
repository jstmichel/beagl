// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Infrastructure.AnimalManagement.Models;

/// <summary>
/// Persistence model for HealthRecord, using value objects.
/// </summary>
public class HealthRecordEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the health record.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the foreign key to the associated animal.
    /// </summary>
    public Guid AnimalId { get; set; }

    /// <summary>
    /// Gets or sets whether the animal is sterilized.
    /// </summary>
    public bool IsSterilized { get; set; }

    /// <summary>
    /// Gets or sets the weight of the animal as a value object.
    /// </summary>
    public Weight? Weight { get; set; }

    /// <summary>
    /// Gets or sets the date of the last rabies vaccination.
    /// </summary>
    public DateTime? RabiesVaccinationDate { get; set; }

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
