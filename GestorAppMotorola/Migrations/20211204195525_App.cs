using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorAppMotorola.Migrations
{
    public partial class App : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_App_Instalacion_instalacionId",
                table: "App");

            migrationBuilder.DropIndex(
                name: "IX_App_instalacionId",
                table: "App");

            migrationBuilder.DropColumn(
                name: "instalacionId",
                table: "App");

            migrationBuilder.AddColumn<int>(
                name: "AppId",
                table: "Instalacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppInstalacion",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "int", nullable: false),
                    InstalacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInstalacion", x => new { x.AppId, x.InstalacionId });
                    table.ForeignKey(
                        name: "FK_AppInstalacion_App_AppId",
                        column: x => x.AppId,
                        principalTable: "App",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppInstalacion_Instalacion_InstalacionId",
                        column: x => x.InstalacionId,
                        principalTable: "Instalacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppInstalacion_InstalacionId",
                table: "AppInstalacion",
                column: "InstalacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInstalacion");

            migrationBuilder.DropColumn(
                name: "AppId",
                table: "Instalacion");

            migrationBuilder.AddColumn<int>(
                name: "instalacionId",
                table: "App",
                type: "int",
                nullable: true);

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
        }
    }
}
