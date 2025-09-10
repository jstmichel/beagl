using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beagl.Domain.Services;

/// <summary>
/// Defines a service for retrieving paginated data.
/// </summary>
public interface IPagedService<TData, TFilter>
{
    /// <summary>
    /// Retrieves a paginated list of items.
    /// </summary>
    /// <param name="filter">The filter to apply for pagination and searching.</param>
    /// <returns>A task representing the asynchronous operation, with a tuple containing the list of items and the total count.</returns>
    public Task<(IList<TData> Items, int TotalCount)> GetPagedAsync(
        TFilter filter);
}
