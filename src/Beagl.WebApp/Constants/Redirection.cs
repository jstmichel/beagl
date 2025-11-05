// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Constants;

/// <summary>
/// Constants for local redirection paths.
/// </summary>
internal sealed class Redirection
{
    /// <summary>
    /// Gets the login page path.
    /// </summary>
    public const string ToLogin = "/Login";

    /// <summary>
    /// Gets the register page path.
    /// </summary>
    public const string ToRegistration = "/Register";

    /// <summary>
    /// Gets the index page path.
    /// </summary>
    public const string ToIndex = "/Index";

    /// <summary>
    /// Gets the users management page path.
    /// </summary>
    public const string ToUserList = "/Users/Index";

    /// <summary>
    /// Gets the create user page path.
    /// </summary>
    public const string ToCreateUser = "/Users/Create";

    /// <summary>
    /// Gets the roles management page path.
    /// </summary>
    public const string ToAnimalList = "/Animals/Index";

    /// <summary>
    /// Gets the roles management page path.
    /// </summary>
    public const string ToCreateCat = "/Animals/CreateCat";

    /// <summary>
    /// Gets the roles management page path.
    /// </summary>
    public const string ToCreateDog = "/Animals/CreateDog";

    /// <summary>
    /// Gets the roles management page path.
    /// </summary>
    public const string ToCitizenList = "/Citizens/Index";

    /// <summary>
    /// Gets the roles management page path.
    /// </summary>
    public const string ToCreateCitizen = "/Citizens/Create";
}
