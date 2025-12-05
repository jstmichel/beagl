// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Infrastructure.AnimalManagement.DTOs;

/// <summary>
/// Data transfer object for creating a new dog.
/// </summary>
public class CreateDogDto : CreateAnimalDto
{
    /// <summary>
    /// Gets or sets the selected secondary breed ID.
    /// </summary>
    public Guid? BreedSecondaryId { get; set; }

    /// <summary>
    /// Gets or sets whether the dog is an assistance dog.
    /// </summary>
    public bool IsAnAssistanceDog { get; set; }

    /// <summary>
    /// Gets a value indicating whether the dog is considered dangerous.
    /// </summary>
    public bool IsDangerousDog { get; set; }

    /// <summary>
    /// Gets a value indicating whether the dog has responsibility insurance.
    /// </summary>
    public bool HasResponsibilityInsurance { get; set; }

    /// <summary>
    /// Gets an optional comment about the dangerous dog status.
    /// </summary>
    public string? DangerousDogComment { get; set; }

    /// <summary>
    /// Gets a value indicating whether the animal comes from another city.
    /// </summary>
    public bool ComesFromAnotherCity { get; set; }

    /// <summary>
    /// Gets the name of the city.
    /// </summary>
    public string? OriginCityName { get; set; }

    /// <summary>
    /// Gets a value indicating whether the animal had a judgment in that city.
    /// </summary>
    public bool HadJudgmentInThatCity { get; set; }
}
