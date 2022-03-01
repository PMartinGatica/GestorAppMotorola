using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorAppMotorola.Migrations
{
    public partial class sensorinstalacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SensorId",
                table: "Telefono",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefono_SensorId",
                table: "Telefono",
                column: "SensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefono_Sensor_SensorId",
                table: "Telefono",
                column: "SensorId",
                principalTable: "Sensor",
                principalColumn: "SensorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefono_Sensor_SensorId",
                table: "Telefono");

            migrationBuilder.DropIndex(
                name: "IX_Telefono_SensorId",
                table: "Telefono");

            migrationBuilder.DropColumn(
                name: "SensorId",
                table: "Telefono");
        }
    }
}
