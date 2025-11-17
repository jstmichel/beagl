// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.Exceptions;

/// <summary>
/// Exception thrown when OriginCityInfo business rules are violated.
/// </summary>
public class OriginCityInfoDomainException : DomainException
{
/// <summary>
/// Initializes a new instance of the <see cref="OriginCityInfoDomainException"/> class.
/// </summary>
public OriginCityInfoDomainException() { }

/// <summary>
/// Initializes a new instance of the <see cref="OriginCityInfoDomainException"/> class with a specified error message.
/// </summary>
    public OriginCityInfoDomainException(string message)
        : base(message)
    {
    }

/// <summary>
/// Initializes a new instance of the <see cref="OriginCityInfoDomainException"/> class with a specified error message and inner exception.
/// </summary>
    public OriginCityInfoDomainException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
