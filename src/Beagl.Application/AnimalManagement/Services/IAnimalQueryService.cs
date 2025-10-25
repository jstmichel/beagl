// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Domain.Core.Interfaces;

namespace Beagl.Application.AnimalManagement.Services;

/// <summary>
/// Service interface for querying paginated animal list DTOs.
/// </summary>
public interface IAnimalQueryService :
    IPagedService<AnimalListDto, AnimalPagedFilterDto>
{

}
