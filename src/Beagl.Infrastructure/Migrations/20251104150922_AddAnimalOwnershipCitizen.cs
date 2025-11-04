// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beagl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAnimalOwnershipCitizen : Migration
    {
        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CitizenId",
                table: "Animals",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CitizenId",
                table: "Animals",
                column: "CitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Citizens_CitizenId",
                table: "Animals",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>")]
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Citizens_CitizenId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CitizenId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CitizenId",
                table: "Animals");
        }
    }
}
