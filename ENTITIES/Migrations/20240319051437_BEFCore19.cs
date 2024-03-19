using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ENTITIES.Migrations
{
    /// <inheritdoc />
    public partial class BEFCore19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Doctors_DoctorsDoctorID",
                table: "Availabilities");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AvailabilityID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Availabilities_DoctorsDoctorID",
                table: "Availabilities");

            migrationBuilder.DropColumn(
                name: "AvailabilityID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DoctorsDoctorID",
                table: "Availabilities");

            migrationBuilder.AlterColumn<int>(
                name: "AvailabilitiesAvailabilityID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DoctorAvailability",
                columns: table => new
                {
                    AvailabilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAvailability", x => x.AvailabilityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AvailabilitiesAvailabilityID",
                table: "Bookings",
                column: "AvailabilitiesAvailabilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_DoctorID",
                table: "Availabilities",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Doctors_DoctorID",
                table: "Availabilities",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Doctors_DoctorID",
                table: "Availabilities");

            migrationBuilder.DropTable(
                name: "DoctorAvailability");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AvailabilitiesAvailabilityID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Availabilities_DoctorID",
                table: "Availabilities");

            migrationBuilder.AlterColumn<int>(
                name: "AvailabilitiesAvailabilityID",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AvailabilityID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorsDoctorID",
                table: "Availabilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AvailabilityID",
                table: "Bookings",
                column: "AvailabilityID");

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
        }
    }
}
