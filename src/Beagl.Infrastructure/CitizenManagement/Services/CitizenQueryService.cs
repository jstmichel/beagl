// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Application.CitizenManagement.Mappers;
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
    public async Task<IList<CitizenLookupDto>> GetAllLookupAsync()
    {
        IQueryable<Citizen> query = dbContext.Citizens
            .AsNoTracking();

        IQueryable<CitizenLookupDto> projected = query
            .Select(a => a.ToLookupDto());

        IList<CitizenLookupDto> result = await projected.ToListAsync();
        return result;
    }

    /// <inheritdoc/>
    public async Task<(IList<CitizenListDto> Items, int TotalCount)> GetPagedAsync(CitizenPagedFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        IQueryable<Citizen> query = dbContext.Citizens
            .Include(c => c.Animals)
            .AsNoTracking();

        query = ApplyFiltersToQuery(query, filter);

        int totalCount = await query.CountAsync();

        IQueryable<CitizenListDto> projected = query
            .Select(a => a.ToListDto());

        IList<CitizenListDto> items = await projected
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return (items, totalCount);
    }

    private static IQueryable<Citizen> ApplyFiltersToQuery(
        IQueryable<Citizen> query,
        CitizenPagedFilterDto filter)
    {
        ArgumentNullException.ThrowIfNull(query);
        ArgumentNullException.ThrowIfNull(filter);

        query = ApplyNameFilterToQuery(query, filter.Name); //TODO: Probably need to separate first and last name filters
        query = ApplyEmailFilterToQuery(query, filter.Email);
        query = ApplyPhoneFilterToQuery(query, filter.PhoneNumber);
        query = ApplyAddressFilterToQuery(query, filter.StreetAddress);
        query = ApplyCityFilterToQuery(query, filter.City);
        query = ApplyPostalCodeFilterToQuery(query, filter.PostalCode);

        return query;
    }

    private static IQueryable<Citizen> ApplyNameFilterToQuery(
        IQueryable<Citizen> query,
        string? name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(u => u.Person!.FirstName!.Contains(name) ||
                                     u.Person!.LastName!.Contains(name));
        }

        return query;
    }

    private static IQueryable<Citizen> ApplyEmailFilterToQuery(
        IQueryable<Citizen> query,
        string? email)
    {
        if (!string.IsNullOrWhiteSpace(email))
        {
            query = query.Where(u => u.Email! == email);
        }

        return query;
    }

    private static IQueryable<Citizen> ApplyPhoneFilterToQuery(
        IQueryable<Citizen> query,
        string? phone)
    {
        if (!string.IsNullOrWhiteSpace(phone))
        {
            query = query.Where(u => u.Phone!.Value.Contains(phone) ||
                                     u.CellPhone!.Value.Contains(phone));
        }

        return query;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<Pending>")]
    private static IQueryable<Citizen> ApplyAddressFilterToQuery(
        IQueryable<Citizen> query,
        string? streetAddress)
    {
        if (!string.IsNullOrWhiteSpace(streetAddress))
        {
            query = query.Where(u => u.Address!.StreetAddress.Contains(streetAddress));
        }

        return query;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<Pending>")]
    private static IQueryable<Citizen> ApplyCityFilterToQuery(
        IQueryable<Citizen> query,
        string? city)
    {
        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query.Where(u => u.Address!.City!.Contains(city));
        }

        return query;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "<Pending>")]
    private static IQueryable<Citizen> ApplyPostalCodeFilterToQuery(
        IQueryable<Citizen> query,
        string? postalCode)
    {
        if (!string.IsNullOrWhiteSpace(postalCode))
        {
            query = query.Where(u => u.Address!.PostalCode!.Contains(postalCode));
        }

        return query;
    }
}
