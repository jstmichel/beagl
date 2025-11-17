// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when an invalid color value is provided.
/// </summary>
public sealed class InvalidColorException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidColorException"/> class.
    /// </summary>
    public InvalidColorException()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidColorException"/> class with a specified error code and message.
    /// </summary>
    public InvalidColorException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidColorException"/> class with a specified error code, message, and inner exception.
    /// </summary>
    public InvalidColorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Throws an <see cref="InvalidColorException"/> if the provided value is null or empty.
    /// </summary>
    /// <param name="value">The color value to validate.</param>
    /// <param name="paramName">The name of the parameter being validated.</param>
    /// <exception cref="InvalidColorException">Thrown when the value is null or empty.</exception>
    public static void ThrowIfNullOrWhiteSpace(string? value, string paramName)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidColorException($"Parameter '{paramName}' cannot be null or empty.");
		}
	}
}
