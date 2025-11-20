// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Extension methods for <see cref="DomainErrorCode"/>.
/// </summary>
public static class DomainErrorCodeExtensions
{
    /// <summary>
    /// Converts the <see cref="DomainErrorCode"/> to a resource key string.
    /// </summary>
    public static string ToResourceKey(this DomainErrorCode errorCode)
    {
        return errorCode.ToString();
    }
}
