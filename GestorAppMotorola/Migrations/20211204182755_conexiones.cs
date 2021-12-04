using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorAppMotorola.Migrations
{
    public partial class conexiones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Operario",
                table: "Operario");

            migrationBuilder.RenameTable(
                name: "Operario",
                newName: "operario");

            migrationBuilder.AddColumn<int>(
                name: "instalacionId",
                table: "operario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "instalacionId",
                table: "App",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_operario",
                table: "operario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_operario_instalacionId",
                table: "operario",
                column: "instalacionId");

            migrationBuilder.CreateIndex(
                name: "IX_App_instalacionId",
                table: "App",
                column: "instalacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_App_Instalacion_instalacionId",
                table: "App",
                column: "instalacionId",
                principalTable: "Instalacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_operario_Instalacion_instalacionId",
                table: "operario",
                column: "instalacionId",
                principalTable: "Instalacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App_Instalacion_instalacionId",
                table: "App");

            migrationBuilder.DropForeignKey(
                name: "FK_operario_Instalacion_instalacionId",
                table: "operario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operario",
                table: "operario");

            migrationBuilder.DropIndex(
                name: "IX_operario_instalacionId",
                table: "operario");

            migrationBuilder.DropIndex(
                name: "IX_App_instalacionId",
                table: "App");

            migrationBuilder.DropColumn(
                name: "instalacionId",
                table: "operario");

            migrationBuilder.DropColumn(
                name: "instalacionId",
                table: "App");

            migrationBuilder.RenameTable(
                name: "operario",
                newName: "Operario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operario",
                table: "Operario",
                column: "Id");
        }
    }
}
