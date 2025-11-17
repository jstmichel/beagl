// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when an audit date or timestamp is invalid.
/// </summary>
public sealed class InvalidAuditException : DomainException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="InvalidAuditException"/> class.
	/// </summary>
	public InvalidAuditException() { }

	/// <summary>
	/// Initializes a new instance of the <see cref="InvalidAuditException"/> class with a specified error message.
	/// </summary>
	/// <param name="message">The exception message.</param>
	public InvalidAuditException(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="InvalidAuditException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	/// <param name="message">The exception message.</param>
	/// <param name="innerException">The inner exception reference.</param>
	public InvalidAuditException(string message, Exception innerException) : base(message, innerException) { }
}
