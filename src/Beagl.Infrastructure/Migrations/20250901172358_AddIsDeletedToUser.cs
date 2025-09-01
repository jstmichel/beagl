using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beagl.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddIsDeletedToUser : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        migrationBuilder.AddColumn<bool>(
            name: "IsDeleted",
            table: "AspNetUsers",
            type: "boolean",
            nullable: false,
            defaultValue: false);
#pragma warning restore CA1062 // Validate arguments of public methods
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        migrationBuilder.DropColumn(
            name: "IsDeleted",
            table: "AspNetUsers");
#pragma warning restore CA1062 // Validate arguments of public methods
    }
}
