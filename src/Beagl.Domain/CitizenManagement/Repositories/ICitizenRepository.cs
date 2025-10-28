// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Threading.Tasks;
using Beagl.Domain.CitizenManagement.Entities;

namespace Beagl.Domain.CitizenManagement.Repositories;

/// <summary>
/// Repository interface for managing Citizen entities.
/// </summary>
public interface ICitizenRepository
{
    /// <summary>
    /// Asynchronously creates a new Citizen entity in the data store.
    /// </summary>
    public Task<Guid> CreateAsync(Citizen citizen);
}
