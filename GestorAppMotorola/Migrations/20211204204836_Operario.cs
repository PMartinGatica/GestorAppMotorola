using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorAppMotorola.Migrations
{
    public partial class Operario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_operario_Instalacion_instalacionId",
                table: "operario");

            migrationBuilder.DropIndex(
                name: "IX_operario_instalacionId",
                table: "operario");

            migrationBuilder.DropColumn(
                name: "instalacionId",
                table: "operario");

            migrationBuilder.AddColumn<int>(
                name: "OperarioId",
                table: "Instalacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_InstalacionOperario_OperarioId",
                table: "InstalacionOperario",
                column: "OperarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstalacionOperario");

            migrationBuilder.DropColumn(
                name: "OperarioId",
                table: "Instalacion");

            migrationBuilder.AddColumn<int>(
                name: "instalacionId",
                table: "operario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_operario_instalacionId",
                table: "operario",
                column: "instalacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_operario_Instalacion_instalacionId",
                table: "operario",
                column: "instalacionId",
                principalTable: "Instalacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
