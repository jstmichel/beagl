// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Beagl.Application.Core.Helpers;

namespace Beagl.WebApp.Extensions;

/// <summary>
/// Extension methods for ModelStateDictionary.
/// </summary>
internal static class ModelStateExtensions
{
    /// <summary>
    /// Adds errors from a Result to the ModelStateDictionary.
    /// </summary>
    public static void AddResultErrors<T>(
        this ModelStateDictionary modelState,
        Result<T> result)
    {
        foreach ((string ErrorCode, string ErrorMessage) in result.Errors)
        {
            modelState.AddModelError(ErrorCode, ErrorMessage);
        }
    }
}
