using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorAppMotorola.Migrations
{
    public partial class Instalacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppInstalacion");

            migrationBuilder.DropTable(
                name: "InstalacionOperario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operario",
                table: "operario");

            migrationBuilder.RenameTable(
                name: "operario",
                newName: "Operario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operario",
                table: "Operario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacion_AppId",
                table: "Instalacion",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacion_OperarioId",
                table: "Instalacion",
                column: "OperarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instalacion_App_AppId",
                table: "Instalacion",
                column: "AppId",
                principalTable: "App",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instalacion_Operario_OperarioId",
                table: "Instalacion",
                column: "OperarioId",
                principalTable: "Operario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instalacion_App_AppId",
                table: "Instalacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Instalacion_Operario_OperarioId",
                table: "Instalacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operario",
                table: "Operario");

            migrationBuilder.DropIndex(
                name: "IX_Instalacion_AppId",
                table: "Instalacion");

            migrationBuilder.DropIndex(
                name: "IX_Instalacion_OperarioId",
                table: "Instalacion");

            migrationBuilder.RenameTable(
                name: "Operario",
                newName: "operario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operario",
                table: "operario",
                column: "Id");

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

            migrationBuilder.CreateTable(
                name: "InstalacionOperario",
                columns: table => new
                {
                    InstalacionId = table.Column<int>(type: "int", nullable: false),
                    OperarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstalacionOperario", x => new { x.InstalacionId, x.OperarioId });
                    table.ForeignKey(
                        name: "FK_InstalacionOperario_Instalacion_InstalacionId",
                        column: x => x.InstalacionId,
                        principalTable: "Instalacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstalacionOperario_operario_OperarioId",
                        column: x => x.OperarioId,
                        principalTable: "operario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppInstalacion_InstalacionId",
                table: "AppInstalacion",
                column: "InstalacionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstalacionOperario_OperarioId",
                table: "InstalacionOperario",
                column: "OperarioId");
        }
    }
}
