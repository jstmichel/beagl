// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Models.Results;

/// <summary>
/// Represents the result of an authentication attempt.
/// </summary>
public sealed class AuthenticationResult
{
    /// <summary>
    /// Gets a value indicating whether the authentication was successful.
    /// </summary>
    public bool Succeeded { get; init; }

    // Add more properties as needed for future extensibility (e.g., lockout, two-factor required, etc.)
}
