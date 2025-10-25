// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.Core.DTOs;
using Beagl.Domain.AnimalManagement.ValueObjects;

namespace Beagl.WebApp.Pages.Animals.ViewModels;

/// <summary>
/// Data Transfer Object for Animal aggregate.
/// </summary>
public class ListAnimalsViewModel : AuditedDtoBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the animal.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the species of the animal.
    /// </summary>
    public SpeciesType Species { get; set; } = SpeciesType.Unknown;

    /// <summary>
    /// Gets or sets the breed of the animal.
    /// </summary>
    public string Breed { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the color of the animal.
    /// </summary>
    public string Color { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    public Gender Gender { get; set; } = Gender.Unknown;

    /// <summary>
    /// Gets or sets the birth date of the animal.
    /// </summary>
    public DateTimeOffset BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the microchip identifier.
    /// </summary>
    public string? MicrochipNumber { get; set; }
}
