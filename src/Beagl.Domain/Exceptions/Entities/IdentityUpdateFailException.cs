// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Beagl.Domain.Exceptions.Entities;

/// <summary>
/// Represents an exception that is thrown when an entity update operation fails.
/// </summary>
[Serializable]
public class IdentityUpdateFailedException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IdentityUpdateFailedException"/> class.
    /// </summary>
    public IdentityUpdateFailedException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdentityUpdateFailedException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public IdentityUpdateFailedException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdentityUpdateFailedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public IdentityUpdateFailedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    /// Throws an <see cref="IdentityUpdateFailedException"/> if the specified <paramref name="result"/> indicates a failed identity operation.
    /// </summary>
    /// <param name="result">The <see cref="IdentityResult"/> to check for success.</param>
    /// <exception cref="IdentityUpdateFailedException">Thrown when the identity operation did not succeed.</exception>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="result"/> is null.</exception>
    public static void ThrowIfNotSucceeded(IdentityResult result)
    {
        ArgumentNullException.ThrowIfNull(result);

        if (!result.Succeeded)
        {
            throw new IdentityUpdateFailedException(
                "Identity operation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
