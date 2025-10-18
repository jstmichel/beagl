// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.Specifications;
using Beagl.Domain.AnimalManagement.ValueObjects;

namespace Beagl.Domain.AnimalManagement.Specifications;

/// <summary>
/// Ensures the animal breed is not null.
/// </summary>
public sealed class AnimalBreedRequiredSpecification : ISpecification<Breed>
{
    /// <summary>
    /// Determines whether the candidate satisfies the specification.
    /// </summary>
    /// <param name="candidate">The breed to evaluate.</param>
    /// <returns>A boolean indicating whether the candidate satisfies the specification.</returns>
    public bool IsSatisfiedBy(Breed candidate) => candidate is not null;
}
