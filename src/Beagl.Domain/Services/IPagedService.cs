using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beagl.Domain.Services;

/// <summary>
/// Defines a service for retrieving paginated data.
/// </summary>
public interface IPagedService<T>
{
    /// <summary>
    /// Retrieves a paginated list of items.
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A task representing the asynchronous operation, with a tuple containing the list of items and the total count.</returns>
    public Task<(IList<T> Users, int TotalCount)> GetPagedAsync(
        int pageNumber, int pageSize);
}
