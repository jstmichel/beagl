namespace Beagl.Domain.Models.DTOs;

/// <summary>
/// Data Transfer Object representing a role with an identifier and description.
/// </summary>
/// <remarks>
/// Used to transfer role data between application layers.
/// </remarks>
/// <property name="Name">The name of the role.</property>
public sealed class RoleDto
{
    /// <summary>
    /// Gets or sets the name of the role.
    /// </summary>
    public required string Name { get; set; }
}
