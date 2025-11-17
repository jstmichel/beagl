// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when an invalid weight value is provided.
/// </summary>
public sealed class InvalidWeightException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidWeightException"/> class.
    /// </summary>
    public InvalidWeightException()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidWeightException"/> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    public InvalidWeightException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidWeightException"/> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    public InvalidWeightException(string message, System.Exception innerException) : base(message, innerException)
    {
    }
}
