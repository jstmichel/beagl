// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.AnimalManagement.ValueObjects;

/// <summary>
/// Represents the dangerous dog status as a value object.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DangerousDog"/> class.
/// </remarks>
/// <param name="isDangerous">Indicates if the dog is dangerous.</param>
/// <param name="hasResponsibilityInsurance">Indicates if the dog has responsibility insurance.</param>
/// <param name="comment">Optional comment.</param>
public record class DangerousDog(
    bool isDangerous,
    bool hasResponsibilityInsurance,
    string? comment = null);
