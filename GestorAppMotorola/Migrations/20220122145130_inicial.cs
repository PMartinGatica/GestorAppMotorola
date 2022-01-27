using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace GestorAppMotorola.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App", x => x.AppId);
                });

            migrationBuilder.CreateTable(
                name: "Operario",
                columns: table => new
                {
                    OperarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellido = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operario", x => x.OperarioId);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    SensorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.SensorId);
                });

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    TelefonoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "text", nullable: true),
                    Modelo = table.Column<string>(type: "text", nullable: true),
                    Precio = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.TelefonoId);
                });

            migrationBuilder.CreateTable(
                name: "Instalacion",
                columns: table => new
                {
                    InstalacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Exitosa = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    OperarioId = table.Column<int>(type: "int", nullable: false),
                    TelefonoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalacion", x => x.InstalacionId);
                    table.ForeignKey(
                        name: "FK_Instalacion_App_AppId",
                        column: x => x.AppId,
                        principalTable: "App",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instalacion_Operario_OperarioId",
                        column: x => x.OperarioId,
                        principalTable: "Operario",
                        principalColumn: "OperarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instalacion_Telefono_TelefonoId",
                        column: x => x.TelefonoId,
                        principalTable: "Telefono",
                        principalColumn: "TelefonoId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "SensorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorTelefono_Telefono_TelefonoId",
                        column: x => x.TelefonoId,
                        principalTable: "Telefono",
                        principalColumn: "TelefonoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instalacion_AppId",
                table: "Instalacion",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacion_OperarioId",
                table: "Instalacion",
                column: "OperarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Instalacion_TelefonoId",
                table: "Instalacion",
                column: "TelefonoId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorTelefono_TelefonoId",
                table: "SensorTelefono",
                column: "TelefonoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instalacion");

            migrationBuilder.DropTable(
                name: "SensorTelefono");

            migrationBuilder.DropTable(
                name: "App");

            migrationBuilder.DropTable(
                name: "Operario");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "Telefono");
        }
    }
}
