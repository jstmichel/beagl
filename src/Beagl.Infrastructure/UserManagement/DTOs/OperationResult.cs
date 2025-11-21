// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.Core.Helpers;

namespace Beagl.Infrastructure.UserManagement.DTOs;

/// <summary>
/// Represents the result of an operation, including success, error code, and message.
/// </summary>
public class OperationResult : Result<object>
{
	/// <summary>
	/// Creates a successful result.
	/// </summary>
	public static OperationResult Ok() => new() { Success = true };

	/// <summary>
	/// Creates a failed result with error code and message.
	/// </summary>
	public static OperationResult Fail(string errorCode, string errorMessage) => new()
    {
		Success = false,
		Errors = new List<(string, string)> { (errorCode, errorMessage) }
	};

	/// <summary>
	/// Creates a failed result with multiple errors.
	/// </summary>
	public static OperationResult Fail(IEnumerable<(string ErrorCode, string ErrorMessage)> errors) => new()
    {
		Success = false,
		Errors = new List<(string, string)>(errors)
	};
}
