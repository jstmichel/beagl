// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when a business rule related to person names is violated.
/// </summary>
public class PersonNameDomainException : DomainException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="PersonNameDomainException"/> class.
	/// </summary>
	public PersonNameDomainException() { }

	/// <summary>
	/// Initializes a new instance of the <see cref="PersonNameDomainException"/> class with a specific error message.
	/// </summary>
	/// <param name="message">The error message.</param>
	public PersonNameDomainException(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="PersonNameDomainException"/> class with a specific error message and an inner exception.
	/// </summary>
	/// <param name="message">The error message.</param>
	/// <param name="innerException">The inner exception.</param>
	public PersonNameDomainException(string message, Exception innerException) : base(message, innerException) { }

	/// <summary>
	/// Throws a <see cref="PersonNameDomainException"/> if the provided string is null or empty.
	/// </summary>
	/// <param name="value">The string value to check.</param>
	/// <param name="paramName">The name of the parameter.</param>
	public static void ThrowIfNullOrEmpty(string? value, string paramName)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new PersonNameDomainException($"Parameter '{paramName}' cannot be null or empty.");
		}
	}
}
