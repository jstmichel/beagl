// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Beagl.Application.CitizenManagement.DTOs;

/// <summary>
/// ViewModel for displaying a list of citizens.
/// </summary>
public class CitizenListDto
{
    /// <summary>
    /// Gets the unique identifier of the citizen.
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Gets the full name of the citizen.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Gets the phone numbers of the citizen.
    /// </summary>
    public Collection<string> PhoneNumbers { get; init; } = [];

    /// <summary>
    /// Gets the email address of the citizen.
    /// </summary>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// Gets the number of animals associated with the citizen.
    /// </summary>
    public int AnimalsCount { get; init; }
}
