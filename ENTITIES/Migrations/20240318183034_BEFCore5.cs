using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class BEFCore5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AvailabilityTime",
                table: "Availabilities");

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailabilityDate",
                table: "Availabilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailabilityType",
                table: "Availabilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailabilityDate",
                table: "Availabilities");

            migrationBuilder.DropColumn(
                name: "AvailabilityType",
                table: "Availabilities");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AvailabilityTime",
                table: "Availabilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
