// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the rabies vaccination status for an animal.
/// </summary>
public sealed class RabiesVaccination
{
    /// <summary>
    /// Gets a value indicating whether the animal is vaccinated for rabies.
    /// </summary>
    public bool IsVaccinated { get; }

    /// <summary>
    /// Gets the date of rabies vaccination. Required if <see cref="IsVaccinated"/> is true.
    /// </summary>
    public DateTimeOffset? VaccinationDate { get; }

    private RabiesVaccination(bool isVaccinated, DateTimeOffset? vaccinationDate)
    {
        if (isVaccinated && vaccinationDate is null)
        {
            throw new ArgumentException("Vaccination date is required when vaccinated is true.", nameof(vaccinationDate));
        }

        IsVaccinated = isVaccinated;
        VaccinationDate = vaccinationDate;
    }

    /// <summary>
    /// Creates a new <see cref="RabiesVaccination"/> value object.
    /// </summary>
    /// <param name="isVaccinated">Indicates if the animal is vaccinated for rabies.</param>
    /// <param name="vaccinationDate">The date of vaccination. Required if <paramref name="isVaccinated"/> is true.</param>
    /// <returns>A new <see cref="RabiesVaccination"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown if <paramref name="isVaccinated"/> is true and <paramref name="vaccinationDate"/> is null.</exception>
    public static RabiesVaccination From(
        bool isVaccinated,
        DateTimeOffset? vaccinationDate) => new(isVaccinated, vaccinationDate);
}
