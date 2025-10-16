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
/// <param name="animal">The associated animal.</param>
/// <param name="userId">The identifier of the user who created the record.</param>
/// <param name="createdAt"></param>
public sealed class HealthRecord(Animal animal, Guid userId, DateTime createdAt) : AuditedEntity(userId, createdAt)
{
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
    public DateTime? RabiesVaccinationDate { get; private set; }

    /// <summary>
    /// Gets the foreign key to the associated animal.
    /// </summary>
    public Guid AnimalId { get; private set; } = animal.Id;

    /// <summary>
    /// Gets the navigation property to the associated animal.
    /// </summary>
    public Animal? Animal { get; private set; } = animal ?? throw new ArgumentNullException(nameof(animal));

    /// <summary>
    /// For EF Core only.
    /// </summary>
    private HealthRecord() : this(default!, default!, default!) { }

    /// <summary>
    /// Updates the animal's weight.
    /// </summary>
    /// <param name="weight">The new weight.</param>
    public void UpdateWeight(Weight weight)
    {
        Weight = weight ?? throw new ArgumentNullException(nameof(weight));
    }

    /// <summary>
    /// Records a rabies vaccination.
    /// </summary>
    /// <param name="date">The date of vaccination.</param>
    public void RecordRabiesVaccination(DateTime date)
    {
        RabiesVaccinationDate = date;
    }

    /// <summary>
    /// Marks the animal as sterilized.
    /// </summary>
    public void Sterilize()
    {
        IsSterilized = true;
    }
}
