// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;

namespace Beagl.Domain.Core.ValueObjects;

/// <summary>
/// Represents audit information for entity creation.
/// </summary>
/// <typeparam name="TId">The type of the user identifier.</typeparam>
public record class Audit<TId>(TId userId, DateTimeOffset at);
