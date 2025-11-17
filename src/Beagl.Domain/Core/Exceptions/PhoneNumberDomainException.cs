// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when a business rule related to phone numbers is violated.
/// </summary>
public class PhoneNumberDomainException : DomainException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="PhoneNumberDomainException"/> class.
	/// </summary>
	public PhoneNumberDomainException() { }

	/// <summary>
	/// Initializes a new instance of the <see cref="PhoneNumberDomainException"/> class with a specific error message.
	/// </summary>
	/// <param name="message">The error message.</param>
	public PhoneNumberDomainException(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="PhoneNumberDomainException"/> class with a specific error message and an inner exception.
	/// </summary>
	/// <param name="message">The error message.</param>
	/// <param name="innerException">The inner exception.</param>
	public PhoneNumberDomainException(string message, Exception innerException) : base(message, innerException) { }
}
