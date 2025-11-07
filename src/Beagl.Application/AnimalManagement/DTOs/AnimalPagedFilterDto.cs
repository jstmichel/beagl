// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Application.Core.DTOs;
using Beagl.Domain.AnimalManagement.Enums;
using Beagl.Domain.Core.Interfaces;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// DTO for animal paging and filtering parameters.
/// </summary>
public class AnimalPagedFilterDto : PagedRequestDto, IPagedFilter
{
    /// <summary>
    /// Gets or sets the name of the animal.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the species of the animal.
    /// </summary>
    public SpeciesType? Species { get; set; }

    /// <summary>
    /// Gets or sets the breed of the animal.
    /// </summary>
    public Guid? PrimaryBreed { get; set; }

    /// <summary>
    /// Gets or sets the color of the animal.
    /// </summary>
    public Guid? Color { get; set; }

    /// <summary>
    /// Gets or sets the gender of the animal.
    /// </summary>
    public Gender? Gender { get; set; }

    /// <summary>
    /// Gets or sets the microchip identifier.
    /// </summary>
    public string? MicrochipNumber { get; set; }

    /// <summary>
    /// Gets or sets the permit number of the animal.
    /// </summary>
    public string? PermitNumber { get; set; }
}
