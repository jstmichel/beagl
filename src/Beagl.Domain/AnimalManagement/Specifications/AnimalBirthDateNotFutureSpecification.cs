// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Beagl.Domain.Core.Specifications;

namespace Beagl.Domain.AnimalManagement.Specifications;

/// <summary>
/// Ensures the animal birth date is not in the future.
/// </summary>
public sealed class AnimalBirthDateNotFutureSpecification : ISpecification<DateTimeOffset>
{
    /// <summary>
    /// Determines whether the candidate satisfies the specification.
    /// </summary>
    /// <param name="candidate">The birth date to evaluate.</param>
    /// <returns>A boolean indicating whether the candidate satisfies the specification.</returns>
    public bool IsSatisfiedBy(DateTimeOffset candidate)
        => candidate <= DateTimeOffset.UtcNow;
}
