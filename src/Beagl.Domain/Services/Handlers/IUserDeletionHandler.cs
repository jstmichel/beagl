// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Threading.Tasks;

namespace Beagl.Domain.Services.Handlers;

/// <summary>
/// Handler for user deletion logic.
/// </summary>
public interface IUserDeletionHandler
{
    /// <summary>
    /// Handles the user deletion process.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task HandleAsync(string userId);
}
