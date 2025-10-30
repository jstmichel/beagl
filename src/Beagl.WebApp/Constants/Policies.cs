// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Constants;

/// <summary>
/// Defines authorization policy names used in the application.
/// </summary>
internal static class Policies
{
    internal static class SideMenu
    {
        /// <summary>
        /// The policy name for side menu access.
        /// </summary>
        public const string CanView = "SideMenu.CanView";
    }

    internal static class Users
    {
        /// <summary>
        /// The policy name for viewing user details.
        /// </summary>
        public const string CanView = "Users.CanView";

        /// <summary>
        /// The policy name for editing user details.
        /// </summary>
        public const string CanEdit = "Users.CanEdit";

        /// <summary>
        /// The policy name for deleting user details.
        /// </summary>
        public const string CanDelete = "Users.CanDelete";

        /// <summary>
        /// The policy name for creating user details.
        /// </summary>
        public const string CanCreate = "Users.CanCreate";
    }

    /// <summary>
    /// Policies related to citizen management.
    /// </summary>
    internal static class Citizens
    {
        /// <summary>
        /// The policy name for viewing citizen details.
        /// </summary>
        public const string CanView = "Citizens.CanView";

        /// <summary>
        /// The policy name for editing citizen details.
        /// </summary>
        public const string CanEdit = "Citizens.CanEdit";

        /// <summary>
        /// The policy name for deleting citizen details.
        /// </summary>
        public const string CanDelete = "Citizens.CanDelete";

        /// <summary>
        /// The policy name for creating citizen details.
        /// </summary>
        public const string CanCreate = "Citizens.CanCreate";
    }

    /// <summary>
    /// Policies related to animal management.
    /// </summary>
    internal static class Animals
    {
        /// <summary>
        /// The policy name for viewing animal details.
        /// </summary>
        public const string CanView = "Animals.CanView";

        /// <summary>
        /// The policy name for editing animal details.
        /// </summary>
        public const string CanEdit = "Animals.CanEdit";

        /// <summary>
        /// The policy name for deleting animal details.
        /// </summary>
        public const string CanDelete = "Animals.CanDelete";

        /// <summary>
        /// The policy name for creating animal details.
        /// </summary>
        public const string CanCreate = "Animals.CanCreate";
    }
}
