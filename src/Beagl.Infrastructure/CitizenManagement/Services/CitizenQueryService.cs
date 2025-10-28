// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Domain.CitizenManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.CitizenManagement.Services;

/// <summary>
/// Concrete implementation of ICitizenQueryService for querying paginated citizen list DTOs.
/// </summary>
public sealed class CitizenQueryService
    (ApplicationDbContext dbContext) : ICitizenQueryService
{
    /// <inheritdoc/>
    public async Task<(IList<CitizenListDto> Items, int TotalCount)> GetPagedAsync(CitizenPagedFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        IQueryable<Citizen> query = dbContext.Citizens;
        int totalCount = await query.CountAsync();

        IQueryable<CitizenListDto> projected = query
            .Select(a => new CitizenListDto
            {
                Id = a.Id,
                Name = a.Person.FirstName,
                Phone = a.Phone,
                CellPhone = a.CellPhone,
                Email = a.Email,
                AnimalsCount = 0,
            });

        IList<CitizenListDto> items = await projected
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return (items, totalCount);
    }
}
