// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when a dog value object or entity is invalid or cannot be created.
/// </summary>
public sealed class InvalidDogException : DomainException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="InvalidDogException"/> class.
	/// </summary>
	public InvalidDogException() { }

	/// <summary>
	/// Initializes a new instance of the <see cref="InvalidDogException"/> class with a specified error message.
	/// </summary>
	/// <param name="message">The exception message.</param>
	public InvalidDogException(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="InvalidDogException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="innerException">The inner exception reference.</param>
	public InvalidDogException(string message, Exception innerException) : base(message, innerException) { }
}
