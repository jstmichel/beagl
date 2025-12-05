using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.Specifications;

namespace Beagl.Domain.AnimalManagement.Specifications;

/// <summary>
/// Specification for validating OriginCityInfo business rules.
/// </summary>
public class OriginCityInfoSpecification : ISpecification<OriginCityInfo>
{
    /// <summary>
    /// Checks if the OriginCityInfo satisfies all business rules.
    /// </summary>
    public bool IsSatisfiedBy(OriginCityInfo info)
    {
        if (info is null) return false;

        return IsSatisfiedBy(
            info.ComesFromAnotherCity,
            info.CityName,
            info.HadJudgmentInThatCity);
    }

    /// <summary>
    /// Checks if the OriginCityInfo satisfies all business rules.
    /// </summary>
    /// <param name="comesFromAnotherCity">Indicates if the animal comes from another city.</param>
    /// <param name="cityName">The name of the city.</param>
    /// <param name="hadJudgmentInThatCity">Indicates if the animal had a judgment in that city.</param>
    /// <returns>True if all business rules are satisfied; otherwise, false.</returns>
    public static bool IsSatisfiedBy(bool comesFromAnotherCity, string cityName, bool hadJudgmentInThatCity)
    {
        // Rule 1: If ComesFromAnotherCity is true, CityName must be filled
        if (comesFromAnotherCity && string.IsNullOrWhiteSpace(cityName))
        {
            return false;
        }

        // Rule 2: If HadJudgmentInThatCity is true, ComesFromAnotherCity must be true and CityName filled
        if (hadJudgmentInThatCity && (!comesFromAnotherCity || string.IsNullOrWhiteSpace(cityName)))
        {
            return false;
        }

        // Rule 3: If CityName is filled, ComesFromAnotherCity should be true
        if (!string.IsNullOrWhiteSpace(cityName) && !comesFromAnotherCity)
        {
            return false;
        }

        return true;
    }
}
