// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core;

namespace Beagl.Domain.AnimalManagement.Entities;

/// <summary>
/// Represents a health record entry for an animal.
/// </summary>
/// <summary>
/// Represents a health record entry for an animal (DDD-oriented).
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="HealthRecord"/> class.
/// </remarks>
public sealed class HealthRecord : AuditedEntity
{
    private HealthRecord(Guid userId, DateTimeOffset createdAt, bool isSterilized, Weight? weight, DateTimeOffset? rabiesVaccinationDate)
        : base(userId, createdAt)
    {
        IsSterilized = isSterilized;
        Weight = weight;
        RabiesVaccinationDate = rabiesVaccinationDate;
    }

    /// <summary>
    /// Creates a new instance of <see cref="HealthRecord"/>.
    /// </summary>
    /// <param name="userId">The identifier of the user who created the record.</param>
    /// <param name="createdAt">The date and time when the record was created.</param>
    /// <param name="isSterilized">Indicates whether the animal is sterilized.</param>
    /// <param name="weight">The weight of the animal.</param>
    /// <param name="rabiesVaccinationDate">The date of the rabies vaccination.</param>
    public static HealthRecord Create(Guid userId, DateTimeOffset createdAt, bool isSterilized = false, Weight? weight = null, DateTimeOffset? rabiesVaccinationDate = null)
    {
        // Add validation logic as needed
        return new HealthRecord(userId, createdAt, isSterilized, weight, rabiesVaccinationDate);
    }

    /// <summary>
    /// Gets whether the animal is sterilized.
    /// </summary>
    public bool IsSterilized { get; private set; }

    /// <summary>
    /// Gets the weight of the animal.
    /// </summary>
    public Weight? Weight { get; private set; }

    /// <summary>
    /// Gets the date of the last rabies vaccination.
    /// </summary>
    public DateTimeOffset? RabiesVaccinationDate { get; private set; }
}
