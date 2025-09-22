// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Exceptions.Entities;

/// <summary>
/// Exception thrown when an entity cannot be deleted due to a failure.
/// </summary>
public class EntityDeleteFailedException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityDeleteFailedException"/> class.
    /// </summary>
    public EntityDeleteFailedException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityDeleteFailedException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The exception message.</param>
    public EntityDeleteFailedException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityDeleteFailedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception reference.</param>
    public EntityDeleteFailedException(string message, Exception innerException) : base(message, innerException) { }
}
