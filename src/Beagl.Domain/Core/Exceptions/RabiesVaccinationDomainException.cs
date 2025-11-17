// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when RabiesVaccination business rules are violated.
/// </summary>
public class RabiesVaccinationDomainException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RabiesVaccinationDomainException"/> class.
    /// </summary>
    public RabiesVaccinationDomainException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="RabiesVaccinationDomainException"/> class with a specified error message.
    /// </summary>
    public RabiesVaccinationDomainException(string message)
        : base(message)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="RabiesVaccinationDomainException"/> class with a specified error message and inner exception.
    /// </summary>
    public RabiesVaccinationDomainException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
