// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Linq;
using Beagl.Domain.Models;

namespace Beagl.Domain.Services;

/// <summary>
/// Provides reusable paging logic for IQueryable queries.
/// </summary>
public static class PagingHelper
{
    /// <summary>
    /// Applies paging to the specified query using the provided filter.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <param name="filter">The paging filter containing page number and size.</param>
    /// <param name="query">The query to apply paging to.</param>
    public static void ApplyPagingToQuery<T>(
        PagedRequestDto filter,
        ref IQueryable<T> query)
    {
        ArgumentNullException.ThrowIfNull(filter);
        ArgumentNullException.ThrowIfNull(query);
        ArgumentOutOfRangeException.ThrowIfLessThan(filter.PageNumber, 1, nameof(filter.PageNumber));
        ArgumentOutOfRangeException.ThrowIfLessThan(filter.PageSize, 1, nameof(filter.PageSize));

        ApplySkipAndTakeToQuery(filter, ref query);
    }

    private static void ApplySkipAndTakeToQuery<T>(
        PagedRequestDto filter,
        ref IQueryable<T> query)
    {
        int skip = (filter.PageNumber - 1) * filter.PageSize;
        query = query.Skip(skip).Take(filter.PageSize);
    }
}
