// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when an invalid medal value is provided.
/// </summary>
public sealed class InvalidMedalException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidMedalException"/> class.
    /// </summary>
    public InvalidMedalException()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidMedalException"/> class with a specified error code and message.
    /// </summary>
    public InvalidMedalException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidMedalException"/> class with a specified error code, message, and inner exception.
    /// </summary>
    public InvalidMedalException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
