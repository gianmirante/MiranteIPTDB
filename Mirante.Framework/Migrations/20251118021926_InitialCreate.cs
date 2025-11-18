using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mirante.Framework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorAppointments",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAppointments", x => x.DoctorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorAppointments");
        }
    }
}
