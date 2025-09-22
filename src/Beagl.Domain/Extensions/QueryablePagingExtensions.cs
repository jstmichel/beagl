// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using System.Linq;

namespace Beagl.Domain.Extensions;

/// <summary>
/// Provides LINQ extension methods for applying paging to queries.
/// </summary>
public static class QueryablePagingExtensions
{
    /// <summary>
    /// Applies paging to the specified query using the provided filter.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <param name="query">The query to apply paging to.</param>
    /// <param name="pageNumber">The page number to retrieve (1-based).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>The query with paging applied.</returns>
    public static IQueryable<T> Paginate<T>(
        this IQueryable<T> query,
        int pageNumber,
        int pageSize)
    {
        ArgumentNullException.ThrowIfNull(query);
        ArgumentOutOfRangeException.ThrowIfLessThan(
            pageNumber, 1, nameof(pageNumber));
        ArgumentOutOfRangeException.ThrowIfLessThan(
            pageSize, 1, nameof(pageSize));

        int skip = (pageNumber - 1) * pageSize;
        return query.Skip(skip).Take(pageSize);
    }
}
