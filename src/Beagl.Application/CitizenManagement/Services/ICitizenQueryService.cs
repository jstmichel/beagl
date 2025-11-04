// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.Generic;
using System.Threading.Tasks;
using Beagl.Application.CitizenManagement.DTOs;
using Beagl.Domain.Core.Interfaces;

namespace Beagl.Application.CitizenManagement.Services;

/// <summary>
/// Service interface for querying paginated citizen list DTOs.
/// </summary>
public interface ICitizenQueryService :
    IPagedService<CitizenListDto, CitizenPagedFilterDto>
{
    /// <summary>
    /// Retrieves all citizens as a list along with the total count.
    /// </summary>
    public Task<IList<CitizenListDto>> GetAllAsync();
}
