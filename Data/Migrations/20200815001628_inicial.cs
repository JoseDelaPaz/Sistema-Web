using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapaDatos.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    marca_vehiculo = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: false),
                    Roles = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleado", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "automiviles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(nullable: false),
                    Tipo_Transmision = table.Column<string>(nullable: false),
                    Descripcion_Problema = table.Column<string>(nullable: false),
                    Fecha_Entrada = table.Column<DateTime>(nullable: false),
                    Lugar_Fabricacion = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Matricula = table.Column<string>(maxLength: 10, nullable: false),
                    ClienteID = table.Column<int>(nullable: false),
                    Modelo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_automiviles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_automiviles_clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "empleadosVehiculos",
                columns: table => new
                {
                    EmpleadoVehiculosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoID = table.Column<int>(nullable: false),
                    AutomivilID = table.Column<int>(nullable: false),
                    Detalle_Reparaciion = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Validacion = table.Column<bool>(nullable: false),
                    Remitido = table.Column<bool>(nullable: false),
                    empleadoVehiculofID = table.Column<int>(nullable: true),
                    automovilEmpleadofID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleadosVehiculos", x => new { x.EmpleadoVehiculosID });
                    table.ForeignKey(
                        name: "FK_empleadosVehiculos_automiviles_automovilEmpleadofID",
                        column: x => x.automovilEmpleadofID,
                        principalTable: "automiviles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_empleadosVehiculos_empleado_empleadoVehiculofID",
                        column: x => x.empleadoVehiculofID,
                        principalTable: "empleado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "entregas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Entrega = table.Column<DateTime>(nullable: false),
                    Detalles = table.Column<string>(nullable: false),
                    AutomovilID = table.Column<int>(nullable: false),
                    estado = table.Column<string>(nullable: false),
                    precio = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entregas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_entregas_automiviles_AutomovilID",
                        column: x => x.AutomovilID,
                        principalTable: "automiviles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_automiviles_ClienteID",
                table: "automiviles",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_empleadosVehiculos_automovilEmpleadofID",
                table: "empleadosVehiculos",
                column: "automovilEmpleadofID");

            migrationBuilder.CreateIndex(
                name: "IX_empleadosVehiculos_empleadoVehiculofID",
                table: "empleadosVehiculos",
                column: "empleadoVehiculofID");

            migrationBuilder.CreateIndex(
                name: "IX_entregas_AutomovilID",
                table: "entregas",
                column: "AutomovilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empleadosVehiculos");

            migrationBuilder.DropTable(
                name: "entregas");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "automiviles");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
