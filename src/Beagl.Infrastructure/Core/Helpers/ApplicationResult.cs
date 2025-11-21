// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.Core.Helpers;

namespace Beagl.Infrastructure.Core.Helpers;

/// <summary>
/// Represents the result of an operation, including success, error code, and message.
/// </summary>
public static class ApplicationResult
{
	/// <summary>
	/// Creates a successful result.
	/// </summary>
	public static Result<T> Ok<T>(T value) => new() { Success = true, Value = value };

	/// <summary>
	/// Creates a failed result with error code and message.
	/// </summary>
	public static Result<T> Fail<T>(string errorCode, string errorMessage) => new()
    {
		Success = false,
		Errors = new List<(string, string)> { (errorCode, errorMessage) }
	};

	/// <summary>
	/// Creates a failed result with multiple errors.
	/// </summary>
	public static Result<T> Fail<T>(IEnumerable<(string ErrorCode, string ErrorMessage)> errors) => new()
    {
		Success = false,
		Errors = new List<(string, string)>(errors)
	};
}
