// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core.Exceptions;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the rabies vaccination status for an animal.
/// </summary>
public sealed class RabiesVaccination : IEquatable<RabiesVaccination>
{
    /// <summary>
    /// Gets a value indicating whether the animal is vaccinated for rabies.
    /// </summary>
    public bool IsVaccinated { get; }

    /// <summary>
    /// Gets the date of rabies vaccination. Required if <see cref="IsVaccinated"/> is true.
    /// </summary>
    public DateTimeOffset? VaccinationDate { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RabiesVaccination"/> class.
    /// </summary>
    /// <param name="isVaccinated">Indicates if the animal is vaccinated for rabies.</param>
    /// <param name="vaccinationDate">The date of vaccination. Required if <paramref name="isVaccinated"/> is true.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="isVaccinated"/> is true and <paramref name="vaccinationDate"/> is null.</exception>
    public RabiesVaccination(bool isVaccinated, DateTimeOffset? vaccinationDate)
    {
        ValidateVaccinatedDateIsProvided(isVaccinated, vaccinationDate);

        IsVaccinated = isVaccinated;
        VaccinationDate = vaccinationDate;
    }

    private static void ValidateVaccinatedDateIsProvided(bool isVaccinated, DateTimeOffset? vaccinationDate)
    {
        if (isVaccinated && vaccinationDate is null)
        {
            throw new RabiesVaccinationDomainException("Vaccination date is required when vaccinated is true.");
        }
    }

    /// <inheritdoc/>
    public bool Equals(RabiesVaccination? other) =>
        other is not null &&
        IsVaccinated == other.IsVaccinated &&
        VaccinationDate == other.VaccinationDate;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as RabiesVaccination);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(
        IsVaccinated,
        VaccinationDate);

    /// <summary>
    /// Equality operator for RabiesVaccination value objects.
    /// </summary>
    /// <param name="left">The left RabiesVaccination value.</param>
    /// <param name="right">The right RabiesVaccination value.</param>
    /// <returns>True if both RabiesVaccination values are equal; otherwise, false.</returns>
    public static bool operator ==(RabiesVaccination? left, RabiesVaccination? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Inequality operator for RabiesVaccination value objects.
    /// </summary>
    /// <param name="left">The left RabiesVaccination value.</param>
    /// <param name="right">The right RabiesVaccination value.</param>
    /// <returns>True if both RabiesVaccination values are not equal; otherwise, false.</returns>
    public static bool operator !=(RabiesVaccination? left, RabiesVaccination? right)
    {
        return !Equals(left, right);
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
