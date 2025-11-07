// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the origin city information for an animal, including whether it comes from another city and if it had a judgment there.
/// </summary>
public class OriginCityInfo : IEquatable<OriginCityInfo>
{
    /// <summary>
    /// Gets a value indicating whether the animal comes from another city.
    /// </summary>
    public bool ComesFromAnotherCity { get; }

    /// <summary>
    /// Gets the name of the city.
    /// </summary>
    public string CityName { get; }

    /// <summary>
    /// Gets a value indicating whether the animal had a judgment in that city.
    /// </summary>
    public bool HadJudgmentInThatCity { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OriginCityInfo"/> class.
    /// </summary>
    /// <param name="comesFromAnotherCity">Indicates if the animal comes from another city.</param>
    /// <param name="cityName">The name of the city.</param>
    /// <param name="hadJudgmentInThatCity">Indicates if the animal had a judgment in that city.</param>
    public OriginCityInfo(bool comesFromAnotherCity, string cityName, bool hadJudgmentInThatCity)
    {
        ComesFromAnotherCity = comesFromAnotherCity;
        CityName = cityName;
        HadJudgmentInThatCity = hadJudgmentInThatCity;
    }

    /// <inheritdoc/>
    public bool Equals(OriginCityInfo? other) =>
        other is not null &&
        ComesFromAnotherCity == other.ComesFromAnotherCity &&
        CityName == other.CityName &&
        HadJudgmentInThatCity == other.HadJudgmentInThatCity;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => Equals(obj as OriginCityInfo);

    /// <inheritdoc/>
    public override int GetHashCode() => HashCode.Combine(
        ComesFromAnotherCity,
        CityName,
        HadJudgmentInThatCity);

    /// <inheritdoc/>
    public static bool operator ==(OriginCityInfo? left, OriginCityInfo? right)
    {
        return Equals(left, right);
    }

    /// <inheritdoc/>
    public static bool operator !=(OriginCityInfo? left, OriginCityInfo? right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Creates an OriginCityInfo value object from the given parameters.
    /// </summary>
    /// <param name="comesFromAnotherCity">Indicates if the animal comes from another city.</param>
    /// <param name="cityName">The name of the city.</param>
    /// <param name="hadJudgmentInThatCity">Indicates if the animal had a judgment in that city.</param>
    /// <returns>An OriginCityInfo value object or null if any input is invalid.</returns>
    public static OriginCityInfo? From(bool? comesFromAnotherCity, string? cityName, bool? hadJudgmentInThatCity)
    {
        if (comesFromAnotherCity is null || hadJudgmentInThatCity is null || string.IsNullOrWhiteSpace(cityName))
            return null;
        return new OriginCityInfo(comesFromAnotherCity.Value, cityName, hadJudgmentInThatCity.Value);
    }
}
