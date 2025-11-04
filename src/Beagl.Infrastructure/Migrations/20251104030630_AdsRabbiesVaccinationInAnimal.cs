// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beagl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdsRabbiesVaccinationInAnimal : Migration
    {
        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRabiesVaccinated",
                table: "Animals",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSterilized",
                table: "Animals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "RabiesVaccinationDate",
                table: "Animals",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRabiesVaccinated",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "IsSterilized",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "RabiesVaccinationDate",
                table: "Animals");
        }
    }
}
