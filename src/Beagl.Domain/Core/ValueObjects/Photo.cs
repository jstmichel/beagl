// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.ValueObjects;

/// <summary>
/// Represents a photo for an animal, stored as a base64-encoded PNG image.
/// </summary>
public record class Photo(string base64Png);
