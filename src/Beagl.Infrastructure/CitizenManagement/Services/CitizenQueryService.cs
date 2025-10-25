// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.ObjectModel;
using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Services;
using Beagl.Domain.AnimalManagement.Entities;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Beagl.Infrastructure.CitizenManagement.Services;

/// <summary>
/// Concrete implementation of ICitizenQueryService for querying paginated citizen list DTOs.
/// </summary>
public sealed class CitizenQueryService : ICitizenQueryService
{
    /// <inheritdoc/>
    public async Task<(IList<CitizenListDto> Items, int TotalCount)> GetPagedAsync(CitizenPagedFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        // IQueryable<Citizen> query = dbContext.Citizens;
        // int totalCount = await query.CountAsync();

        // IQueryable<AnimalListDto> projected = query
        //     .Select(a => new AnimalListDto
        //     {
        //         Id = a.Id,
        //         Name = a.Name,
        //         Breed = a.PrimaryBreed != null ? a.PrimaryBreed.Name : string.Empty,
        //         Color = a.Color != null ? a.Color.Name : string.Empty,
        //         BirthDate = a.DateOfBirth,
        //         MicrochipNumber = a.Microchip != null ? a.Microchip.Value : null,
        //         Species = a.SpeciesType,
        //         Gender = a.Gender,
        //     });

        // IList<AnimalListDto> items = await projected
        //     .Skip((filter.PageNumber - 1) * filter.PageSize)
        //     .Take(filter.PageSize)
        //     .ToListAsync();

        // return (items, totalCount);

        return await Task.FromResult((new List<CitizenListDto> { new CitizenListDto
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            PhoneNumbers = ["123-456-7890"],
            Email = "john.doe@example.com",
            AnimalsCount = 2
        } }, 0));
    }
}
