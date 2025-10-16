// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beagl.Infrastructure.Migrations;

/// <inheritdoc />
public partial class UpdateAnimalAggregateRoot : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        migrationBuilder.RenameColumn(
            name: "PermitExpirationDate",
            table: "Animals",
            newName: "ModifiedAt");
#pragma warning restore CA1062 // Validate arguments of public methods

        migrationBuilder.RenameColumn(
            name: "MedalNumber",
            table: "Animals",
            newName: "OriginCityInfo_CityName");

        migrationBuilder.AddColumn<DateTime>(
            name: "ModifiedAt",
            table: "HealthRecords",
            type: "timestamp with time zone",
            nullable: true);

        migrationBuilder.AddColumn<Guid>(
            name: "ModifiedByUserId",
            table: "HealthRecords",
            type: "uuid",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            name: "CreatedAt",
            table: "Animals",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        migrationBuilder.AddColumn<Guid>(
            name: "CreatedByUserId",
            table: "Animals",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.AddColumn<Guid>(
            name: "ModifiedByUserId",
            table: "Animals",
            type: "uuid",
            nullable: true);

        migrationBuilder.CreateTable(
            name: "MedalRecords",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                MedalNumber = table.Column<string>(type: "text", nullable: false),
                AssignedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                AnimalId = table.Column<Guid>(type: "uuid", nullable: false),
                Reason = table.Column<string>(type: "text", nullable: true),
                CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                ModifiedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MedalRecords", x => x.Id);
                table.ForeignKey(
                    name: "FK_MedalRecords_Animals_AnimalId",
                    column: x => x.AnimalId,
                    principalTable: "Animals",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_MedalRecords_AnimalId",
            table: "MedalRecords",
            column: "AnimalId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
#pragma warning disable CA1062 // Validate arguments of public methods
        migrationBuilder.DropTable(
            name: "MedalRecords");
#pragma warning restore CA1062 // Validate arguments of public methods

        migrationBuilder.DropColumn(
            name: "ModifiedAt",
            table: "HealthRecords");

        migrationBuilder.DropColumn(
            name: "ModifiedByUserId",
            table: "HealthRecords");

        migrationBuilder.DropColumn(
            name: "CreatedAt",
            table: "Animals");

        migrationBuilder.DropColumn(
            name: "CreatedByUserId",
            table: "Animals");

        migrationBuilder.DropColumn(
            name: "ModifiedByUserId",
            table: "Animals");

        migrationBuilder.RenameColumn(
            name: "OriginCityInfo_CityName",
            table: "Animals",
            newName: "MedalNumber");

        migrationBuilder.RenameColumn(
            name: "ModifiedAt",
            table: "Animals",
            newName: "PermitExpirationDate");
    }
}
