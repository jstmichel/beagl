// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.Interfaces;
using Beagl.Infrastructure.AnimalManagement.DTOs;

namespace Beagl.Infrastructure.AnimalManagement.Services;

/// <summary>
/// Service interface for querying paginated animal list DTOs.
/// </summary>
public interface IAnimalQueryService :
    IPagedService<AnimalListDto, AnimalPagedFilterDto>
{

}
