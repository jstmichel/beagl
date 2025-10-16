// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Domain.Core.Interfaces;

namespace Beagl.Infrastructure.Core.Helpers;

/// <summary>
/// Helper class for casting IPagedFilter to specific filter types.
/// </summary>
public static class FilterCastingHelper
{
    /// <summary>
    /// Safely casts an IPagedFilter to the expected concrete type.
    /// Throws an ArgumentException if the cast fails.
    /// </summary>
    public static TFilter CastFilterTo<TFilter>(IPagedFilter filter)
        where TFilter : class, IPagedFilter
    {
        if (filter is TFilter typedFilter)
            return typedFilter;

        throw new ArgumentException(
            $"Invalid filter type. Expected {typeof(TFilter).Name}.",
            nameof(filter));
    }
}
