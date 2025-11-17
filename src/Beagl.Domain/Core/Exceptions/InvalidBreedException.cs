// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when an invalid breed value is provided.
/// </summary>
public sealed class InvalidBreedException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidBreedException"/> class.
    /// </summary>
    public InvalidBreedException()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidBreedException"/> class with a specified error code and message.
    /// </summary>
    public InvalidBreedException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidBreedException"/> class with a specified error code, message, and inner exception.
    /// </summary>
    public InvalidBreedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Throws an <see cref="InvalidBreedException"/> if the provided value is null or empty.
    /// </summary>
    /// <param name="value">The breed value to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="InvalidBreedException">Thrown when the value is null or empty.</exception>
    public static void ThrowIfNullOrWhiteSpace(string? value, string paramName)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidBreedException($"Parameter '{paramName}' cannot be null or empty.");
		}
	}
}
