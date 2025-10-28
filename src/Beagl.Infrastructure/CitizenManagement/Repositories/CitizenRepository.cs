// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.CitizenManagement.Entities;
using Beagl.Domain.CitizenManagement.Repositories;

namespace Beagl.Infrastructure.CitizenManagement.Repositories;

/// <summary>
/// Repository implementation for managing Citizen entities.
/// </summary>
public class CitizenRepository(
    ApplicationDbContext dbContext) : ICitizenRepository
{
    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(Citizen citizen)
    {
        ArgumentNullException.ThrowIfNull(citizen);

        dbContext.Citizens.Add(citizen);
        await dbContext.SaveChangesAsync();
        return citizen.Id;
    }
}
