// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Exceptions.Users;

/// <summary>
/// Exception thrown when attempting to delete the last user in the system.
/// </summary>
public class LastUserDeleteException : DomainException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="LastUserDeleteException"/> class.
	/// </summary>
	public LastUserDeleteException() { }

	/// <summary>
	/// Initializes a new instance of the <see cref="LastUserDeleteException"/> class with a specified error message.
	/// </summary>
	/// <param name="message">The exception message.</param>
	public LastUserDeleteException(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="LastUserDeleteException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="innerException">The inner exception reference.</param>
	public LastUserDeleteException(string message, Exception innerException) : base(message, innerException) { }
}
