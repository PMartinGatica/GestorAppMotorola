using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorAppMotorola.Migrations
{
    public partial class SensorTelefono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorTelefono",
                columns: table => new
                {
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    TelefonoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorTelefono", x => new { x.SensorId, x.TelefonoId });
                    table.ForeignKey(
                        name: "FK_SensorTelefono_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorTelefono_Telefono_TelefonoId",
                        column: x => x.TelefonoId,
                        principalTable: "Telefono",
                        principalColumn: "TelefonoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorTelefono_TelefonoId",
                table: "SensorTelefono",
                column: "TelefonoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorTelefono");
        }
    }
}
