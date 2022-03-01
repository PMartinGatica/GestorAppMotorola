using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorAppMotorola.Migrations
{
    public partial class buscar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Telefono_TelefonoId",
                table: "Sensor");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_TelefonoId",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "TelefonoId",
                table: "Sensor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TelefonoId",
                table: "Sensor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_TelefonoId",
                table: "Sensor",
                column: "TelefonoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Telefono_TelefonoId",
                table: "Sensor",
                column: "TelefonoId",
                principalTable: "Telefono",
                principalColumn: "TelefonoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
