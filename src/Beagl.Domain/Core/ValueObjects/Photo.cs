// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.ValueObjects;

/// <summary>
/// Represents a photo for an animal, stored as a base64-encoded PNG image.
/// </summary>
public sealed class Photo(string base64Png)
{
    /// <summary>
    /// Gets the base64-encoded PNG image string.
    /// </summary>
    public string Base64Png { get; } = base64Png;
}
