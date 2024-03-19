using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class BEFCore20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Availabilities2_Availability2AvailabilityID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_Availability2AvailabilityID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Availability2AvailabilityID",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "Availability2AvailabilityID",
                table: "DoctorAvailability",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAvailability_Availability2AvailabilityID",
                table: "DoctorAvailability",
                column: "Availability2AvailabilityID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAvailability_Availabilities2_Availability2AvailabilityID",
                table: "DoctorAvailability",
                column: "Availability2AvailabilityID",
                principalTable: "Availabilities2",
                principalColumn: "AvailabilityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAvailability_Availabilities2_Availability2AvailabilityID",
                table: "DoctorAvailability");

            migrationBuilder.DropIndex(
                name: "IX_DoctorAvailability_Availability2AvailabilityID",
                table: "DoctorAvailability");

            migrationBuilder.DropColumn(
                name: "Availability2AvailabilityID",
                table: "DoctorAvailability");

            migrationBuilder.AddColumn<int>(
                name: "Availability2AvailabilityID",
                table: "Bookings",
                type: "int",
                nullable: true);

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
    }
}
