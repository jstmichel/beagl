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
public sealed class DangerousDog(bool isDangerous, bool hasResponsibilityInsurance, string? comment = null)
{
    /// <summary>
    /// Gets a value indicating whether the dog is classified as dangerous.
    /// </summary>
    public bool IsDangerous { get; } = isDangerous;

    /// <summary>
    /// Gets a value indicating whether the dog has a responsibility insurance.
    /// </summary>
    public bool HasResponsibilityInsurance { get; } = hasResponsibilityInsurance;

    /// <summary>
    /// Gets an optional comment regarding the dangerous dog status.
    /// </summary>
    public string? Comment { get; } = comment;
}
