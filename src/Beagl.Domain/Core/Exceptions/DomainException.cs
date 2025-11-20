// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Base exception type for domain-specific errors.
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class.
    /// </summary>
    public DomainErrorCode ErrorCode { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class.
    /// </summary>
    protected DomainException() : base()
    {
        ErrorCode = DomainErrorCode.Unknown;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The exception message.</param>
    protected DomainException(string message) : base(message)
    {
        ErrorCode = DomainErrorCode.Unknown;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The exception message.</param>
    public DomainException(DomainErrorCode errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message and inner exception.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    protected DomainException(DomainErrorCode errorCode, string message, Exception innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    protected DomainException(string message, Exception innerException) : base(message, innerException)
    {
        ErrorCode = DomainErrorCode.Unknown;
    }
}
