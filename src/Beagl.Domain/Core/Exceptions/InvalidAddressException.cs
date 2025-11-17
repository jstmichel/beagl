// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when an address value object is invalid or cannot be created.
/// </summary>
public sealed class InvalidAddressException : DomainException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="InvalidAddressException"/> class.
	/// </summary>
	public InvalidAddressException() { }

	/// <summary>
	/// Initializes a new instance of the <see cref="InvalidAddressException"/> class with a specified error message.
	/// </summary>
	/// <param name="message">The exception message.</param>
	public InvalidAddressException(string message)
		: base(message) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="InvalidAddressException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="innerException">The inner exception reference.</param>
	public InvalidAddressException(string message, Exception innerException)
		: base(message, innerException) { }

    /// <summary>
    /// Throws an <see cref="InvalidAddressException"/> if the provided string is null or whitespace.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <exception cref="InvalidAddressException">Thrown when the value is null or whitespace.</exception>
    public static void ThrowIfNullOrWhiteSpace(string? value, string paramName)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidAddressException($"Parameter '{paramName}' cannot be null or empty.");
		}
	}
}
