// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.Collections.Generic;

namespace Beagl.Application.Core.Helpers;

/// <summary>
/// Represents the result of an operation, with optional value, generic error code(s), and message(s).
/// </summary>
/// <typeparam name="T">Type of the value returned on success.</typeparam>
public class Result<T>
{
	/// <summary>
	/// Indicates whether the operation was successful.
	/// </summary>
	public bool Success { get; init; }

	/// <summary>
	/// Optional value returned on success.
	/// </summary>
	public T? Value { get; init; }

	/// <summary>
	/// Optional single error code for failed operations (convenience).
	/// </summary>
	public string? ErrorCode => Errors.Count > 0 ? Errors[0].ErrorCode : default;

	/// <summary>
	/// Optional single error message for failed operations (convenience).
	/// </summary>
	public string? ErrorMessage => Errors.Count > 0 ? Errors[0].ErrorMessage : null;

	/// <summary>
	/// List of errors (code, message) for failed operations.
	/// </summary>
	public IReadOnlyList<(string ErrorCode, string ErrorMessage)> Errors { get; init; } = [];
}

/// <summary>
/// Static helper methods for creating Result instances.
/// </summary>
public static class Result
{
	/// <summary>
	/// Creates a successful result with value.
	/// </summary>
	public static Result<T> Ok<T, TErrorCode>(T value) => new() { Success = true, Value = value };

	/// <summary>
	/// Creates a successful result without value.
	/// </summary>
	public static Result<T> Ok<T>() => new() { Success = true };

	/// <summary>
	/// Creates a failed result with a single error code and message.
	/// </summary>
	public static Result<T> Fail<T>(string errorCode, string errorMessage) => new()
	{
		Success = false,
		Errors = [(errorCode, errorMessage)]
	};

	/// <summary>
	/// Creates a failed result with multiple errors.
	/// </summary>
	public static Result<T> Fail<T>(IEnumerable<(string ErrorCode, string ErrorMessage)> errors) => new()
	{
		Success = false,
		Errors = [.. errors]
    };
}
