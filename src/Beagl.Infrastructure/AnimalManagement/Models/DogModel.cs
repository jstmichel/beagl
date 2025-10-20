// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.AnimalManagement.ValueObjects;

namespace Beagl.Infrastructure.AnimalManagement.Models;

/// <summary>
/// Persistence model for dog-specific data (TPT).
/// </summary>
public class DogModel : AnimalModel
{
    /// <summary>
    /// Gets or sets the foreign key for the secondary breed of the animal (optional).
    /// </summary>
    public Guid? SecondaryBreedId { get; set; }

    /// <summary>
    /// Gets or sets the related secondary breed entity.
    /// </summary>
    public BreedModel? SecondaryBreed { get; set; }

    /// <summary>
    /// Gets or sets the dangerous dog status and related information.
    /// </summary>
    public DangerousDog? DangerousDog { get; set; }

    /// <summary>
    /// Gets or sets whether the dog is an assistance dog.
    /// </summary>
    public bool IsAnAssistanceDog { get; set; }

    /// <summary>
    /// Gets or sets the origin city information for the animal.
    /// </summary>
    public OriginCityInfo? OriginCityInfo { get; set; }
}
