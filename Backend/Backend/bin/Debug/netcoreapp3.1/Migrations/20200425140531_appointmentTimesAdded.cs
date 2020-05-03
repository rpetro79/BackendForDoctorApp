using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class appointmentTimesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "doctorAppointmentTimes",
                columns: table => new
                {
                    doctorId = table.Column<string>(nullable: false),
                    appointmentTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorAppointmentTimes", x => new { x.doctorId, x.appointmentTime });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctorAppointmentTimes");
        }
    }
}
