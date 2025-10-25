// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.Core.DTOs;
using Beagl.Domain.Core.Interfaces;

namespace Beagl.Application.CitizenManagement.DTOs;

/// <summary>
/// DTO for citizen paging and filtering parameters.
/// </summary>
public class CitizenPagedFilterDto : PagedRequestDto, IPagedFilter
{

}
