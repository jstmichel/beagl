// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.Core.DTOs;
using Beagl.Domain.Core.Interfaces;

namespace Beagl.Application.AnimalManagement.DTOs;

/// <summary>
/// DTO for animal paging and filtering parameters.
/// </summary>
public class AnimalPagedFilterDto : PagedRequestDto, IPagedFilter
{

}
