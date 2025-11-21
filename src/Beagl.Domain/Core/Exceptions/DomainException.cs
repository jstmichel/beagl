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
    public string ErrorCode { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class.
    /// </summary>
    protected DomainException() : base()
    {
        ErrorCode = DomainErrorCode.None;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The exception message.</param>
    protected DomainException(string message) : base(message)
    {
        ErrorCode = DomainErrorCode.None;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The exception message.</param>
    public DomainException(string errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message and inner exception.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    protected DomainException(string errorCode, string message, Exception innerException) : base(message, innerException)
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
        ErrorCode = DomainErrorCode.None;
    }

    /// <summary>
    /// Throws a <see cref="DomainException"/> if the provided string is null or whitespace.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <param name="errorCode">The error code.</param>
    /// <exception cref="DomainException">Thrown when the string is null or whitespace.</exception>
    public static void ThrowIfNullOrWhiteSpace(string? value, string paramName, string errorCode)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException(errorCode, $"{paramName} cannot be null or empty.");
        }
    }

    /// <summary>
    /// Throws a <see cref="DomainException"/> if the provided object is null.
    /// </summary>
    /// <param name="value">The object to check.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <param name="errorCode">The error code.</param>
    /// <exception cref="DomainException">Thrown when the object is null.</exception>
    public static void ThrowIfNull(object? value, string paramName, string errorCode)
    {
        if (value == null)
        {
            throw new DomainException(errorCode, $"{paramName} cannot be null or empty.");
        }
    }
}
