using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class BEFCore8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Availability2AvailabilityID",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Availabilities2",
                columns: table => new
                {
                    AvailabilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailabilityDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities2", x => x.AvailabilityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Availability2AvailabilityID",
                table: "Bookings",
                column: "Availability2AvailabilityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Availabilities2_Availability2AvailabilityID",
                table: "Bookings",
                column: "Availability2AvailabilityID",
                principalTable: "Availabilities2",
                principalColumn: "AvailabilityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Availabilities2_Availability2AvailabilityID",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Availabilities2");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Availability2AvailabilityID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Availability2AvailabilityID",
                table: "Bookings");
        }
    }
}
