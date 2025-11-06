using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beagl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterStreetFieldsInCitizen : Migration
    {
        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appartment",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Addresses",
                newName: "StreetAddress");
        }

        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "Addresses",
                newName: "StreetNumber");

            migrationBuilder.AddColumn<string>(
                name: "Appartment",
                table: "Addresses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Addresses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
