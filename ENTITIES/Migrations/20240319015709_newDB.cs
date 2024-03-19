using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class newDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Doctors_DoctorID",
                table: "Availabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Availabilities_AvailabilityID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Doctors_DoctorID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Availabilities_DoctorID",
                table: "Availabilities");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Bookings",
                newName: "DoctorsDoctorID");

            migrationBuilder.RenameColumn(
                name: "AvailabilityID",
                table: "Bookings",
                newName: "AvailabilitiesAvailabilityID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_DoctorID",
                table: "Bookings",
                newName: "IX_Bookings_DoctorsDoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AvailabilityID",
                table: "Bookings",
                newName: "IX_Bookings_AvailabilitiesAvailabilityID");

            migrationBuilder.AddColumn<int>(
                name: "DoctorsDoctorID",
                table: "Availabilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_DoctorsDoctorID",
                table: "Availabilities",
                column: "DoctorsDoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Doctors_DoctorsDoctorID",
                table: "Availabilities",
                column: "DoctorsDoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Availabilities_AvailabilitiesAvailabilityID",
                table: "Bookings",
                column: "AvailabilitiesAvailabilityID",
                principalTable: "Availabilities",
                principalColumn: "AvailabilityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Doctors_DoctorsDoctorID",
                table: "Bookings",
                column: "DoctorsDoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Doctors_DoctorsDoctorID",
                table: "Availabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Availabilities_AvailabilitiesAvailabilityID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Doctors_DoctorsDoctorID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Availabilities_DoctorsDoctorID",
                table: "Availabilities");

            migrationBuilder.DropColumn(
                name: "DoctorsDoctorID",
                table: "Availabilities");

            migrationBuilder.RenameColumn(
                name: "DoctorsDoctorID",
                table: "Bookings",
                newName: "DoctorID");

            migrationBuilder.RenameColumn(
                name: "AvailabilitiesAvailabilityID",
                table: "Bookings",
                newName: "AvailabilityID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_DoctorsDoctorID",
                table: "Bookings",
                newName: "IX_Bookings_DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AvailabilitiesAvailabilityID",
                table: "Bookings",
                newName: "IX_Bookings_AvailabilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_DoctorID",
                table: "Availabilities",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Doctors_DoctorID",
                table: "Availabilities",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Availabilities_AvailabilityID",
                table: "Bookings",
                column: "AvailabilityID",
                principalTable: "Availabilities",
                principalColumn: "AvailabilityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Doctors_DoctorID",
                table: "Bookings",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID");
        }
    }
}
