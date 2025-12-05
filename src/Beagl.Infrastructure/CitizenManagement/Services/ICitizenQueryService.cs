// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.Interfaces;
using Beagl.Infrastructure.CitizenManagement.DTOs;

namespace Beagl.Infrastructure.CitizenManagement.Services;

/// <summary>
/// Service interface for querying paginated citizen list DTOs.
/// </summary>
public interface ICitizenQueryService :
    IPagedService<CitizenListDto, CitizenPagedFilterDto>
{
    /// <summary>
    /// Retrieves all citizens as a lookup list.
    /// </summary>
    public Task<IList<CitizenLookupDto>> GetAllLookupAsync();
}
